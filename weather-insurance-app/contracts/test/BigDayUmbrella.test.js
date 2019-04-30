const BigNumber = web3.BigNumber;
require('chai')
  .use(require('chai-as-promised'))
  .use(require('chai-bignumber')(BigNumber))
  .should();

// import contracts
const BigDayUmbrella = artifacts.require("BigDayUmbrella.sol");

contract('BigDayUmbrella', async (accounts) => { 

    const [
        Temperature,
        WindSpeed,
        WindGustSpeed,
        UVIndex,
        Pressure,
        Humidity
    ] = Array.from(Array(6).keys());

    const [ Thunderstorm, RainSnow, Sleet, Icy, 
        Showers, Rain, Flurries, Snow, Dust, Fog, 
        Haze, Windy, Cloudy, MostlyCloudy, 
        Sunny, MostlySunny, Hot, ChanceOfTStorm, 
        ChanceOfRain, ChanceOfSnow ] = Array.from(Array(20).keys());

    const policy = {
        location: 'Ukraine, Kyiv',
        period: {
            start: new Date().getTime(),
            end: new Date().getTime() + 24 * 60 * 60 * 100
        },
        temperature: {
            min: 10,
            max: 30
        }
    };
    const insurant = accounts[0];
    const oracle = accounts[1];

    describe('can instantiate smart-contract', async () => {
        const app = await BigDayUmbrella.new(oracle, insurant);
        (await app.Insurant()).should.be.equal(insurant);
        (await app.State()).should.be.bignumber.equal(0);
    });

    describe('# Setup policy', async () => {

        let app;

        beforeEach(async () => {
            app = await BigDayUmbrella.new(oracle, insurant);
        });

        it('oracle cannot update policy', async () => {
            await app.setPolicyMeasuredValue(Temperature, 
                new BigNumber(15), new BigNumber(30),
                {from: oracle}).should.be.rejected;
        });

        it('can submit policy', async () => {
            await app.setPolicyMeasuredValue(Temperature, 15, 30, {from: insurant}).should.be.fulfilled;
            await app.setPolicyAllowedWeather(Flurries, {from: insurant}).should.be.fulfilled;

            const {logs} = await app.submitPolicy(
                policy.location,
                new BigNumber(policy.period.start), 
                new BigNumber(policy.period.end),
                {from: insurant}).should.be.fulfilled;
            logs[0].event.should.be.equal('PolicySubmitted');
            logs[0].args.should.be.deep.equal({
                location: policy.location,
                periodStart: new BigNumber(policy.period.start),
                periodEnd: new BigNumber(policy.period.end),
                insurant: insurant
            });
            (await app.State()).should.be.bignumber.equal(1);
        });

        it('cannot submit policy by oracle', async () => {
            await app.setPolicyAllowedWeather(Flurries, {from: insurant}).should.be.fulfilled;
            await app.setPolicyMeasuredValue(Temperature, 
                new BigNumber(15), new BigNumber(30),
                {from: insurant}).should.be.fulfilled;
            await app.submitPolicy(
                policy.location,
                new BigNumber(policy.period.start), 
                new BigNumber(policy.period.end),
                {from: oracle}
            ).should.be.rejected;
        });

        it('cannot submit policy two times', async () => {
            await app.setPolicyMeasuredValue(Temperature, 15, 30, {from: insurant}).should.be.fulfilled;
            await app.setPolicyAllowedWeather(Flurries, {from: insurant}).should.be.fulfilled;
            await app.submitPolicy(
                policy.location,
                new BigNumber(policy.period.start), 
                new BigNumber(policy.period.end),
                {from: insurant}
            ).should.be.fulfilled;
            await app.submitPolicy(
                policy.location,
                new BigNumber(policy.period.start), 
                new BigNumber(policy.period.end),
                {from: insurant}
            ).should.be.rejected;
        });

        it('can update measured value in policy', async () => {
            await app.setPolicyMeasuredValue(Temperature, policy.temperature.min, policy.temperature.max, {from: insurant}).should.be.fulfilled;
            
            const currentTemp = await app.getPolicyMeasuredValue(Temperature);
            currentTemp[0].should.be.bignumber.equal(policy.temperature.min);
            currentTemp[1].should.be.bignumber.equal(policy.temperature.max);
            currentTemp[2].should.be.equal(true);
        });

        it('can understand that requested measure wasn\'t set to the policy', async () => {
            const currentHumidity = await app.getPolicyMeasuredValue(Humidity);
            currentHumidity[2].should.be.equal(false);
        });

        it('should allow add new weather to policy', async () => {
            await app.setPolicyAllowedWeather(Flurries, {from: insurant}).should.be.fulfilled;
        });
    });

    describe("# Update weather conditions", async () => {
        let app;
        beforeEach(async () => {
            app = await BigDayUmbrella.new(oracle, insurant);
            await app.setPolicyAllowedWeather(Flurries, {from: insurant}).should.be.fulfilled;
            await app.setPolicyAllowedWeather(Thunderstorm, {from: insurant}).should.be.fulfilled;
            await app.setPolicyMeasuredValue(Temperature, 
                new BigNumber(15), new BigNumber(30),
                {from: insurant}).should.be.fulfilled;
            await app.submitPolicy(
                policy.location,
                new BigNumber(policy.period.start), 
                new BigNumber(policy.period.end),
                {from: insurant}
            );
        });

        it('should update temperature without fulfilling issue claim', async () => {
            await app.updateMeasuredConditions(Temperature, 25, new Date().getTime(), {from: oracle}).should.be.fulfilled;
            (await app.State()).should.be.bignumber.equal(1);
        });

        it('should automatically issue claim when temperature exceeds limits', async () => {
            const {logs} = await app.updateMeasuredConditions(Temperature, 31, new Date().getTime(), {from: oracle}).should.be.fulfilled;
            logs.length.should.be.equal(1);
            logs[0].event.should.be.equal('IssueClaim');
            logs[0].args.should.be.deep.equal({
                insurant: insurant,
                reason: 'Temperature limits exceeded'
            });
            (await app.State()).should.be.bignumber.equal(2);
        });

        it('should automatically issue claim when weather changed and violates policy', async () => {
            const {logs} = await app.updateWeather(Rain, new Date().getTime(), {from: oracle}).should.be.fulfilled;

            logs.length.should.be.equal(1);
            logs[0].event.should.be.equal('IssueClaim');
            logs[0].args.should.be.deep.equal({
                insurant: insurant,
                reason: 'Weather condition violation'
            });
            (await app.State()).should.be.bignumber.equal(2);
        });

        it('won\'t issue claim for measure that wasn\'t set to policy', async () => {
            await app.updateMeasuredConditions(Humidity, 1000, new Date().getTime(), {from: oracle}).should.be.fulfilled;
            (await app.State()).should.be.bignumber.equal(1);
        });

        it('won\'t issue claim for weather that was set to policy', async () => {
            await app.updateWeather(Flurries, new Date().getTime(), {from: oracle}).should.be.fulfilled;
            (await app.State()).should.be.bignumber.equal(1);

            await app.updateWeather(Thunderstorm, new Date().getTime(), {from: oracle}).should.be.fulfilled;
            (await app.State()).should.be.bignumber.equal(1);
        });

        it('cannot submit measured conditions that contract doesn\'t support', async () => {
            await app.updateMeasuredConditions(Humidity + 1, 31, new Date().getTime(), {from: oracle}).should.be.rejected;
        });

        it('should allow submit value for all supported measured conditions', async () => {
            await app.updateMeasuredConditions(Temperature, 16, new Date().getTime(), {from: oracle}).should.be.fulfilled;
            await app.updateMeasuredConditions(WindSpeed, 16, new Date().getTime(), {from: oracle}).should.be.fulfilled;
            await app.updateMeasuredConditions(WindGustSpeed, 16, new Date().getTime(), {from: oracle}).should.be.fulfilled;
            await app.updateMeasuredConditions(UVIndex, 16, new Date().getTime(), {from: oracle}).should.be.fulfilled;
            await app.updateMeasuredConditions(Pressure, 16, new Date().getTime(), {from: oracle}).should.be.fulfilled;
            await app.updateMeasuredConditions(Humidity, 16, new Date().getTime(), {from: oracle}).should.be.fulfilled;
        });

        it('should decline claim if oracle submitted weather condition after policy period ends', async () => {
            const {logs} = await app.updateMeasuredConditions(Pressure, 16, new BigNumber(policy.period.end + 10), {from: oracle}).should.be.fulfilled;            
            logs.length.should.be.equal(1);
            logs[0].event.should.be.equal('DeclineClaim');
            logs[0].args.insurant.should.be.equal(insurant);
            (await app.State()).should.be.bignumber.equal(3);
        });
    });

});