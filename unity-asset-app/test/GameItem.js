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

contract('GamePlayer  ', (accounts) => {
  let store;
  let owner;
  let player;
  let gameAccounts;

  before(async () => {

    console.log('creating gamestore');
    store = await GameStore.new();
    player = await GamePlayer.new('playa', store.address);
    await store.RegisterAccount(accounts[0]);
    gameAccounts = await store.GetAllAccounts();
    console.log('accounts', gameAccounts);
    assert.equal(gameAccounts[0], accounts[0], "should have a game account registered");

    console.log(store.address);
    owner = accounts[0];
    console.log('owner', owner);
    assert.notEqual(owner, '0x0000000000000000000000000000000000000000');
  });

  it('ANYONE:can get game item props', async () => {
    const item = await GameItem.new(store.address, 'item1', 'weapon', '{game:data}');
    const props = await item.GetProps.call();
    
    assert.strictEqual(utils.hexToNumber(props.gameState), ItemGameState.NotRegistered, 'expected not registred');
    assert.strictEqual(props.owner, owner, 'expected owner');
    assert.strictEqual(utils.hexToNumber(props.price), 0, 'expected price');
    assert.strictEqual(props.game, store.address, 'expected game address');
    assert.strictEqual(props.itemKey, 'item1', 'item key');
    assert.strictEqual(props.itemType, 'weapon', 'item type');
  });


  // OWNER change owner
  it('OWNER:ChangeOwner:succeed', async () => {
    const item = await GameItem.new(accounts[1], 'item1', 'weapon', '{game:data}');
    await item.ChangeOwner(accounts[2]);
    assert.equal(accounts[2], await get(item, 'owner'), 'Owner');
  });

  it('NOT-OWNER:ChangeOwner:revert - not the owner', async () => {
    const item = await GameItem.new(store.address, 'item1', 'weapon', '{game:data}');
    await assert.reverts(item.ChangeOwner(accounts[1], { from: accounts[2] }), "Must be owner");
  });


  // OWNER change price
  it('OWNER:SetPrice:succeed', async () => {
    const item = await GameItem.new(store.address, 'item1', 'weapon', '{game:data}');
    await item.SetPrice(200);
    assert.equal(200, await get(item, 'price'), 'Price');
  });
  it('NOT-OWNER:SetPrice:revert - not the owner', async () => {
    const item = await GameItem.new(store.address, 'item1', 'weapon', '{game:data}');
    await assert.reverts(item.SetPrice(200, { from: accounts[2] }), "Must be owner");
  });

  //game
  it('Game:GameChangeOwner:succeed', async () => {
    const item = await GameItem.new(accounts[1], 'item1', 'weapon', '{game:data}');
    await item.GameChangeOwner(accounts[2], { from: accounts[1] });
    assert.equal(accounts[2], await get(item, 'owner'), 'Owner');
  });
  it('Game:GameChangeOwner:revert - not the game', async () => {
    const item = await GameItem.new(accounts[1], 'item1', 'weapon', '{game:data}');
    await assert.reverts(item.GameChangeOwner(accounts[3], { from: accounts[2] }), "Must be the GameStore");
  });

  it('Game:GameItemRegistered:succeed', async () => {
    const item = await GameItem.new(accounts[1], 'item1', 'weapon', '{game:data}');
    await item.GameItemRegistered({ from: accounts[1] });
    assertEnum(ItemGameState.Registered, await get(item, 'gameState', true), 'Registered')
  });
  it('Game:GameItemRegistered:revert - not the game', async () => {
    const item = await GameItem.new(accounts[1], 'item1', 'weapon', '{game:data}');
    await assert.reverts(item.GameItemRegistered({ from: accounts[2] }), "Must be the GameStore");
  });


    // //change owners when owned
    // await item.ChangeOwner(accounts[1]);
    // //a
    // await mockStore.RegisterItemForSale(item.address);
    // assert.equal(ItemGameState.Owned, await get(item, 'gameState', true), 'Owned');
    // await item.ChangeOwner(accounts[2], { from: accounts[1]});                                                                                                       
    // await item.MakeOffer(20, { from: accounts[2] });
    // assert.equal(ItemGameState.ForSale, await get(item, 'gameState', true), 'ForSale');
    // await item.ChangeOwner(accounts[0], { from: store.address });
  //});

  // it('player can store and discard items', async () => {
  //   const player = await GamePlayer.new('Slash', store.address);
  //   const item = await GameItem.new(store.address, 'item1', 'weapon-sword');
  //   await player.StoreItem(item.address);
  //   const discarded = await player.DiscardItem(item.address);
  //   assert.equal(discarded.logs[0].event, 'ItemDiscarded', 'event should fire.');
  //   assert.equal(discarded.logs[0].args.itemAddress, item.address, 'item address should be in the event');
  // });

  // it('player can store and discard multiple items', async () => {
  //   const player = await GamePlayer.new('Slash', store.address);
  //   const item = await GameItem.new(store.address, 'item1', 'weapon-sword');
  //   const item2 = await GameItem.new(store.address, 'item1', 'weapon-sword');
  //   await player.StoreItem(item.address);
  //   await player.StoreItem(item2.address);
  //   const discarded = await player.DiscardItem.call(item.address);
  //   assert.strictEqual(discarded, true, 'Item should be discarded');
  //   const discarded2 = await player.DiscardItem.call(item2.address);
  //   assert.strictEqual(discarded2, true, 'Item2 should be discarded');
  // });

  // it('player can get items', async () => {
  //   const player = await GamePlayer.new('Slash', store.address);
  //   const item = await GameItem.new(store.address, 'item1', 'weapon-sword');
  //   const item2 = await GameItem.new(store.address, 'item1', 'weapon-sword');
  //   await player.StoreItem(item.address);
  //   await player.StoreItem(item2.address);
  //   const items = await player.GetItems.call();
  //   assert.strictEqual(items[0], item.address, 'expected item 1 address');
  //   assert.strictEqual(items[1], item2.address, 'expected item 2 address');
  // });


});