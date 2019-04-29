var fs = require('fs');

module.exports = async function (context, req) {
    if (req.method.toUpperCase() == 'POST') {
        fs.writeFile('./last.json', req.body, function (err) {
            context.res = {
                status: 400,
                body: err
            };
        });
    } else {
        context.res = {
            status: 200,
            body: fs.readFileSync('./last.json')
        };
    }
};