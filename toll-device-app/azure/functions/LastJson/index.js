var fs = require('fs');

module.exports = async function (context, req) {
    if (req.method.toUpperCase() == 'POST') {
        fs.writeFile('./last.json', JSON.stringify(req.body), function (err) {
            context.res = {
                status: 400,
                body: err
            };
        });
    } else {
        context.res = {
            status: 200,
            headers: {
                'Content-Type': 'application/json'
            },
            body: fs.existsSync('./last.json') ? JSON.parse(fs.readFileSync('./last.json')) : {}
        };
        fs.unlink('./last.json', (err) => {})
    }
};