const Asset = artifacts.require("./Asset.sol");

const utils = require('web3-utils');

module.exports = function(done) {

  tests().catch(e => console.log('failed', e)).finally(done);
}

async function tests() {

  const accounts = await web3.eth.getAccounts();
  const owner = accounts[0];
  const reserver = accounts[1];
  const product = await Asset.at('Producx', owner);

  // if testing against remote, provide addresses
  // const owner = '0x5F1a049579B01F1FBA5a01677377C67Ab2A8aBB9';
  // const reserver = '0x5F1a049579B01F1FBA5a01677377C67Ab2A8aBB9';
  // const product = '0x9719983C5eE4490FE9d14496f1AA25bd27541981';

  await testApprovals(product, owner, reserver);
}

async function testApprovals(product, owner, reserver) {
  
  const asset = await Asset.at(product);
  console.log(asset.address);

  const state = await asset.asset.call();
  console.log(state);

  const tx = await asset.RequestReservation(reserver, 12, 13, 123);
  console.log('requested', tx.tx);

  const tx2 = await asset.ApproveReservation();
  console.log('approved', tx2.tx);

  const state2 = await asset.asset.call();
  console.log(state2);

  try {
    console.log('trying to release as owner... EXPECTING TO FAIL');
    const tx3 = await asset.ReleaseReservation({ from: owner });
    console.log('released', tx3.tx);
  } catch (ex) {
    console.log('failed', ex.message);
  }

  console.log('trying to release as reserver... should succeed');
  const tx4 = await asset.ReleaseReservation({ from: reserver });
  console.log('released!', tx4.tx);

  const state4 = await asset.asset.call();
  console.log(state4);

}