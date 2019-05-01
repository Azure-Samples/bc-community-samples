const GameItem = artifacts.require('GameItem');
const GameStore = artifacts.require('GameStore');
// const MockGameStore = artifacts.require('MockGameStore');
const GamePlayer = artifacts.require('GamePlayer');

const utils = require('web3-utils');
assert = {
  ...require('truffle-assertions'),
  ...assert
};

const ItemGameState = {
  NotRegistered: 0,
  Registered: 1
};

async function assertEnum(expected, actual, message) {
  if (actual === undefined) {
    assert.fail(message);    
  }
  assert.equal(expected, actual, `Expected enum [${expected}] == [${actual}] ${message}`);
}

async function get(item, prop, isnum) {
  const val = (await item.GetProps.call())[prop];
  if (isnum) {
    return utils.hexToNumber(val);
  } else {
    return val;
  }
}

contract('GameStore', (accounts) => {
  let store;
  let owner;
  let player;
  let gameAccounts;

  before(async () => {

    console.log('creating gamestore');
    // store = await GameStore.new();
    // player = await GamePlayer.new('playa', store.address);
    // await store.RegisterAccount(accounts[0]);
    // gameAccounts = await store.GetAllAccounts();
    // console.log('accounts', gameAccounts);
    // assert.equal(gameAccounts[0], accounts[0], 'should have a game account registered');

    // console.log(store.address);
    owner = accounts[0];
    console.log('owner', owner);
    assert.notEqual(owner, '0x0000000000000000000000000000000000000000');
  });

  it('GetAccount and RegisterAccount, GetMyAccount', async () => {
    const game = await GameStore.new();
    const account = await game.GetAccount.call(accounts[0]);
    assert.equal(account.exists, false, 'account should not exist');

    await game.RegisterAccount(accounts[1]);
    const account2 = await game.GetAccount.call(accounts[1]);
    assert.equal(account2.exists, true, 'account should exist');

    await game.GetMyAccount.call({ from: accounts[1] });
  });

  it('GetAllItems, RegisterMyItem, RegisterAccount', async () => {
    const game = await GameStore.new();
    const items = await game.GetAllItems.call();
    console.log(items);
    assert.equal(items.length, 0, 'should be no items yet');

    await game.RegisterAccount(accounts[0]);

    const item = await GameItem.new(game.address, 'x', 'x', 'x');
    await game.RegisterMyItem(item.address);

    const items1 = await game.GetAllItems.call();
    assert.equal(items1.length, 1, 'should be 1 items');

    const item2 = await GameItem.new(game.address, 'x', 'x', 'x');
    await game.RegisterMyItem(item2.address);

    const items2 = await game.GetAllItems.call();
    assert.equal(items2.length, 2, 'should be 2 items');
  });

  it('PurchaseItem', async () => {
    const game = await GameStore.new();
    await game.RegisterAccount(accounts[0]);
    await game.RegisterAccount(accounts[1]);

    const item = await GameItem.new(game.address, 'x', 'x', 'x');
    await item.SetPrice(1023);
    await game.RegisterMyItem(item.address);

    await game.PurchaseItem(item.address, { from: accounts[1], value: 1023 });
  });

  it('PurchaseItem:revert wrong-amount, item-not-registered, wrong-game, already-owned', async () => {
    const game = await GameStore.new();
    const game2 = await GameStore.new();
    await game.RegisterAccount(accounts[0]);

    const item = await GameItem.new(game.address, 'x', 'x', 'x');
    await item.SetPrice(1023);

    //try to purchase before it is registered
    assert.reverts(game.PurchaseItem(item.address, { from: accounts[0], value: 232 }), "Item must be marked registered");

    //try to purchase item that is registered to a different game
    await game2.RegisterMyItem(item.address);
    assert.reverts(game.PurchaseItem(item.address, { from: accounts[0], value: 232 }), "Item must be registered with this game");

    //try to purchase my own item
    assert.reverts(game.PurchaseItem(item.address, { from: accounts[0], value: 232 }), "Owner cannot purchase self-owned item")

    //try to purchase with the wrong amount
    assert.reverts(game.PurchaseItem(item.address, { from: accounts[1], value: 232 }), "Exact amount is required")

  });
});