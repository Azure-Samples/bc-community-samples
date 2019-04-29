// from https://github.com/LinusU/array-buffer-to-hex/blob/master/index.js
function arrayBufferToHex (arrayBuffer) {
  if (typeof arrayBuffer !== 'object' || arrayBuffer === null || typeof arrayBuffer.byteLength !== 'number') {
    throw new TypeError('Expected input to be an ArrayBuffer')
  }

  var view = new Uint8Array(arrayBuffer)
  var result = ''
  var value

  for (var i = 0; i < view.length; i++) {
    value = view[i].toString(16)
    result += (value.length === 1 ? '0' + value : value)
  }

  return result
}

// Expects:  {'ledgerKey':..,'txs'.., 'lastPaymentUnixTime':.., "zoneAPrice":.., "zoneBPrice":.., "zoneCPrice":..}
//
// where txs are as per return from 'get-transactions' in overhide remuneration API.
//
// lastPaymentUnixTime is as per contract for current payer
//
// zone?Price are the prices for permit into indicated zone
//
// @returns 32 byte hex string prefixed with "0x" where:
//
//     | *syntax *             | *bytes*      | 
//     | ---                   | ---          | 
//     | zoneATimestamp        | 4            |
//     | zoneBTimestamp        | 4            | 
//     | zoneCTimestamp        | 4            |
//     | padding               | 20           |
module.exports = async function (context, req) {
    if (req.body.ledgerKey
        && req.body.topupPeriodMinutes
        && req.body.txs 
        && req.body.lastPaymentUnixTime
        && req.body.zoneAPrice
        && req.body.zoneBPrice
        && req.body.zoneCPrice) {

        var topupPeriodSeconds = req.body.topupPeriodMinutes * 60;
        var txs = req.body.txs;
        var cutoffTime = req.body.lastPaymentUnixTime;

        // [1] convert overhide remuneration result (ISO8601) to unix timestamps
        // [2] move the time stamps to indicate start + PERIOD (end time)
        // [3] filter out records from previous update (by cutofTime)
        var txEnds = txs.transactions.map((rec) => {return {value: rec["transaction-value"], time: parseInt((new Date(rec["transaction-date"]).getTime())/1000)}})
            .sort((recA, recB) => recA.time - recB.time)
            .map((rec) => {return {value: rec.value, time: rec.time + topupPeriodSeconds}})
            .filter((rec) => rec.time > cutoffTime);

        // filter time duplicates (is etherscan returning duplicates?)
        var lastTime = 0;
        txEnds = txEnds.filter((rec) => {
            var result = rec.time > lastTime;
            lastTime = rec.time;
            return result;
        });

        // tally up leftover records as the starting value for histogram (most money paid at beginning before end times)
        var maxAmount = txEnds.reduce((p, c) => p + c.value, 0);

        // histogram of (imagine):
        // x-axis: time; from call into remuneration API until period end (when most recent transaction times out)
        // y-axis: value of payments into car in this histogram time-period
        var histogram = txEnds.map((rec) => {
            let newValue = maxAmount;
            maxAmount -= rec.value;
            return { value: newValue, time: rec.time}
        });

        // adjust for currency
        var zoneAPrice = req.body.zoneAPrice * (req.body.ledgerKey == 'eth-web3' ? 1000000000000000000 : 100);
        var zoneBPrice = req.body.zoneBPrice * (req.body.ledgerKey == 'eth-web3' ? 1000000000000000000 : 100);
        var zoneCPrice = req.body.zoneCPrice * (req.body.ledgerKey == 'eth-web3' ? 1000000000000000000 : 100);

        var zoneATimestamp = histogram.reduce((p,c) => c.value >= zoneAPrice ? c.time : p, 0);
        var zoneBTimestamp = histogram.reduce((p, c) => c.value >= zoneBPrice ? c.time : p, 0);
        var zoneCTimestamp = histogram.reduce((p, c) => c.value >= zoneCPrice ? c.time : p, 0);

        // marshall into byte stream
        var result = new ArrayBuffer(32);
        var view = new DataView(result);
        view.setUint32(0, zoneATimestamp); 
        view.setUint32(4, zoneBTimestamp); 
        view.setUint32(8, zoneCTimestamp);


        context.res = {
            // status: 200, /* Defaults to 200 */
            body: `0x${arrayBufferToHex(result)}`,
            headers: {
                'Content-Type': 'text/plain'
            }
        };
    }
    else {
        context.res = {
            status: 400,
            body: `Expects:  {'txs'.., 'lastPaymentUnixTime':.., "zoneAPrice":.., "zoneBPrice":.., "zoneCPrice":..}`
        };
    }
};