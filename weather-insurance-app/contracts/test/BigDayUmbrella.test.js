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
    ] = [0, 1, 2, 3, 4, 5];

    const policy = {
        location: {
            lat: 50.4637582,
            lon: 30.5071673
        },
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
        const app = await BigDayUmbrella.new(oracle, {from: insurant});
        (await app.Insurant()).should.be.equal(insurant);
        (await app.State()).should.be.bignumber.equal(0);
    });

    describe('# Setup policy', async () => {

        let app;

        beforeEach(async () => {
            app = await BigDayUmbrella.new(oracle, {from: insurant});
        });

        it('can set location for policy', async () => {
            await app.setPolicyLocation(
                new BigNumber(policy.location.lat * (10 ** 7)), 
                new BigNumber(policy.location.lon * (10 ** 7)), 
                {from: insurant}).should.be.fulfilled;
            
            const currentLocation = await app.getPolicyLocation();
            currentLocation[0].should.be.bignumber.equal(policy.location.lat * (10 ** 7))
            currentLocation[1].should.be.bignumber.equal(policy.location.lon * (10 ** 7))
        });

        it('can set timeframes for policy', async () => {
            await app.setPolicyTimeframes(
                new BigNumber(policy.period.start), 
                new BigNumber(policy.period.end), 
                {from: insurant}).should.be.fulfilled;
            const currentTimeframes = await app.getPolicyTimeframes();
            currentTimeframes[0].should.be.bignumber.equal(policy.period.start);
            currentTimeframes[1].should.be.bignumber.equal(policy.period.end);
        });

        it('oracle cannot update policy', async () => {
            await app.setPolicyLocation(new BigNumber(1), new BigNumber(1), {from: oracle}).should.be.rejected;
        });

        it('can submit policy', async () => {
            await app.setPolicyLocation(
                new BigNumber(policy.location.lat * (10 ** 7)), 
                new BigNumber(policy.location.lon * (10 ** 7)), 
                {from: insurant}).should.be.fulfilled;

            await app.setPolicyTimeframes(
                new BigNumber(policy.period.start), 
                new BigNumber(policy.period.end), 
                {from: insurant}).should.be.fulfilled;

            await app.setPolicyMeasuredValue(Temperature, 15, 30, {from: insurant}).should.be.fulfilled;

            const {logs} = await app.submitPolicy({from: insurant}).should.be.fulfilled;
            logs[0].event.should.be.equal('PolicySubmitted');
            logs[0].args.should.be.deep.equal({
                lat: new BigNumber(policy.location.lat * (10 ** 7)),
                lon: new BigNumber(policy.location.lon * (10 ** 7)),
                periodStart: new BigNumber(policy.period.start),
                periodEnd: new BigNumber(policy.period.end),
                insurant: insurant
            });
            (await app.State()).should.be.bignumber.equal(1);
        });

        it('cannot submit policy until weather conditions, time frames and location is not specified', async () => {
            await app.submitPolicy({from: insurant}).should.be.rejected;

            await app.setPolicyLocation(
                new BigNumber(policy.location.lat * (10 ** 7)), 
                new BigNumber(policy.location.lon * (10 ** 7)), 
                {from: insurant}).should.be.fulfilled;
            await app.submitPolicy({from: insurant}).should.be.rejected;

            await app.setPolicyTimeframes(
                new BigNumber(policy.period.start), 
                new BigNumber(policy.period.end), 
                {from: insurant}).should.be.fulfilled;
            await app.submitPolicy({from: insurant}).should.be.rejected;
        });

        it('cannot submit policy by oracle', async () => {
            await app.submitPolicy({from: oracle}).should.be.rejected;
        });

        it('cannot submit policy two times', async () => {
            await app.setPolicyLocation(
                new BigNumber(policy.location.lat * (10 ** 7)), 
                new BigNumber(policy.location.lon * (10 ** 7)), 
                {from: insurant}).should.be.fulfilled;

            await app.setPolicyTimeframes(
                new BigNumber(policy.period.start), 
                new BigNumber(policy.period.end), 
                {from: insurant}).should.be.fulfilled;

            await app.setPolicyMeasuredValue(Temperature, 15, 30, {from: insurant}).should.be.fulfilled;
            
            await app.submitPolicy({from: insurant}).should.be.fulfilled;
            await app.submitPolicy({from: insurant}).should.be.rejected;
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
    });

    describe("# Update weather conditions", async () => {
        let app;
        beforeEach(async () => {
            app = await BigDayUmbrella.new(oracle, {from: insurant});
            await app.setPolicyLocation(
                new BigNumber(policy.location.lat * (10 ** 7)), 
                new BigNumber(policy.location.lon * (10 ** 7)), 
                {from: insurant}).should.be.fulfilled;
            await app.setPolicyTimeframes(
                new BigNumber(policy.period.start), 
                new BigNumber(policy.period.end), 
                {from: insurant}).should.be.fulfilled;
            await app.setPolicyMeasuredValue(Temperature, 
                new BigNumber(15), new BigNumber(30),
                {from: insurant}).should.be.fulfilled;
            await app.submitPolicy({from: insurant});
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

        it('won\'t issue claim for measure that wasn\'t set to policy', async () => {
            await app.updateMeasuredConditions(Humidity, 1000, new Date().getTime(), {from: oracle}).should.be.fulfilled;
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