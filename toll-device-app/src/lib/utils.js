/**
 * Utilities to help with all the other components
 */
import {Accounts} from 'web3-eth-accounts';
import {keccak256} from 'web3-utils';
import config from "../config.json";

/** initialization **/

let accounts = new Accounts('http://localhost:8545');

/**
 * admin - from Azure (promise)
 */
let admin = fetch(config.adminData__AzureURL.replace('{formId}', config.admin__FormId), {
  method: "GET",
  headers: { "Content-Type": "application/json; charset=utf-8" }
})
.then(result => result.json())
.then(result => {console.log('new admin :: ' + JSON.stringify(result, null, 2)); return result;});

/**
 * @returns {Promise} admin from Azure
 */
export function getAdmin() {
  return admin;
}

/**
 * Creates a new Ethereum account
 * 
 * @returns {address:.., privateKey;..} the new account as per web3 lib
 */
export function getNewAccount() {
  return accounts.create();
}

/**
 * @returns {string} a make pretend challenge
 */
export function makePretendChallenge() {
  return `please sign this challenge proving you own this address :: ${(new Date()).getTime() / 1000}`; // make pretend challenge
}

/**
 * @param {string} privateKey - to sign with
 * 
 * @returns {messageHash, r, s, v} of signed (make pretend) challenge
 */
export function makePretendChallengeAndSign(privateKey) {
  var challenge = makePretendChallenge();
  var { messageHash, r, s, v } = accounts.sign(challenge, privateKey);
  v = parseInt(v);
  return { messageHash, r, s, v };
}

/**
 * @param {number} t - millis to delay
 * @returns {Promise} completing when delay is done
 */
export function delay(t) {
  return new Promise(resolve => setTimeout(resolve.bind(null), t));
};

/**
 * @params {string} s - to hash
 * @returns {string} hash
 */
export function hash(s) {
  return keccak256(s);
}