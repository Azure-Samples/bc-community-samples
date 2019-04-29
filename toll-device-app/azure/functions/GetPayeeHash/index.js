const crypto = require('crypto')

const ENCODING = 'utf-8';
const HASH_ALGO = 'sha256';
const DIGEST_FORMAT = 'hex';

/**
 * @param {string} what - to hash
 * @returns {string} the hash
 */
function hash(what) {
    return crypto.createHash(HASH_ALGO).update(what, ENCODING).digest(DIGEST_FORMAT);
}

/**
 * Takes {"address":..,"ledgerKey":..} and returns sha256 of "<address>@<ledgerKey>".
 */
module.exports = async function (context, req) {
    if (req.body) {        
        context.res = {
            body: hash(req.body.address + '@' + req.body.ledgerKey),
            headers: {
                'Content-Type': 'text/plain'
            }
        };
    }
    else {
        context.res = {
            status: 400,
            body: `Takes {"address":..,"ledgerKey":..} and returns sha256 of "<address>@<ledgerKey>"`
        };
    }
};