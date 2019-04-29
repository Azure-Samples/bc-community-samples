module.exports = async function (context, req) {
    if (req.body.topupPeriodMinutes) {
        var topupPeriodSeconds = req.body.topupPeriodMinutes * 60;
        var time = new Date((new Date()).getTime() - (topupPeriodSeconds * 1000));
        context.res = {
            body: time.toISOString()
        };
    }
};