const GameItem = artifacts.require('GameItem');
const GameStore = artifacts.require('GameStore');
const GamePlayer = artifacts.require('GamePlayer');

const utils = require('web3-utils');
contract('GamePlayer', (accounts) => {
  let store;
  let owner;
  let player;

  before(async () => {
    console.log('creating gamestore');
    store = await GameStore.new();
    console.log(store.address);
    owner = accounts[0];
  });

  it('can create game player', async () => {
    console.log('create new player');
    const player = await GamePlayer.new('Slash', store.address);
    console.log(player.address);

    assert.strictEqual(await player.Name.call(), 'Slash', 'Name should be Slash');
    assert.strictEqual(await player.Game.call(), store.address, 'expected Game address');
  });

  it('player can store items', async () => {
    const player = await GamePlayer.new('Slash', store.address);
    const item = await GameItem.new(store.address, 'item1', 'weapon-sword', '{game:data}');
    const stored = await player.StoreItem(item.address);
    // assert.equal(stored.logs[0].event, 'ItemStored', 'ItemStored event should fire.');
    // assert.equal(stored.logs[0].args.itemAddress, item.address, 'item address should be in the event');
  });

  it('player can store and discard items', async () => {
    const player = await GamePlayer.new('Slash', store.address);
    const item = await GameItem.new(store.address, 'item1', 'weapon-sword', '{game:data}');
    await player.StoreItem(item.address);
    const discarded = await player.DiscardItem(item.address);
    assert.equal(discarded.logs[0].event, 'ItemDiscarded', 'event should fire.');
    assert.equal(discarded.logs[0].args.itemAddress, item.address, 'item address should be in the event');
  });

  it('player can store and discard multiple items', async () => {
    const player = await GamePlayer.new('Slash', store.address);
    const item = await GameItem.new(store.address, 'item1', 'weapon-sword', '{game:data}');
    const item2 = await GameItem.new(store.address, 'item1', 'weapon-sword', '{game:data}');
    await player.StoreItem(item.address);
    await player.StoreItem(item2.address);
    const discarded = await player.DiscardItem.call(item.address);
    assert.strictEqual(discarded, true, 'Item should be discarded');
    const discarded2 = await player.DiscardItem.call(item2.address);
    assert.strictEqual(discarded2, true, 'Item2 should be discarded');
  });

  it('player can get items', async () => {
    const player = await GamePlayer.new('Slash', store.address);
    const item = await GameItem.new(store.address, 'item1', 'weapon-sword', '{game:data}');
    const item2 = await GameItem.new(store.address, 'item1', 'weapon-sword', '{game:data}');
    await player.StoreItem(item.address);
    await player.StoreItem(item2.address);
    const items = await player.GetItems.call();
    assert.strictEqual(items[0], item.address, 'expected item 1 address');
    assert.strictEqual(items[1], item2.address, 'expected item 2 address');
  });


});