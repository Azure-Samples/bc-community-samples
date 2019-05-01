var fs = require('fs');

module.exports = async function (context, req) {
    var entries = fs.existsSync('./last.json') ? JSON.parse(fs.readFileSync('./last.json')) : [];

    if (Array.isArray(entries)) {
        var cutoff = (new Date()).getTime() - (5 * 60 * 1000); // five minutes old entries get deleted
        entries = entries.filter(rec => rec.ts > cutoff);
    } else {
        entries = [];
    }

    if (req.body.isGet) {
        if (req.body.atCar) {
            var which = req.body.atCar.toLowerCase();
            var entry = entries.find(rec => rec.atCar == which);
        } else {
            var entry = {};
        }
        context.res = {
            status: 200,
            headers: {
                'Content-Type': 'application/json'
            },
            body: entry ? entry : {}
        };
    } else {
        var entry = req.body;
        entry.atCar = entry.forCar.toLowerCase();
        entry = { ts: (new Date()).getTime(), ...entry };
        entries = entries.filter(rec => rec.atCar != entry.atCar);
        entries.push(entry);
        fs.writeFile('./last.json', JSON.stringify(entries), function (err) {
            context.res = {
                status: 400,
                body: err
            };
        });
    }
};