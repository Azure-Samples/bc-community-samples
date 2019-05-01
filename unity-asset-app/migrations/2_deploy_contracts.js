const AddressSet = artifacts.require("./AddressSet");
const GameCommon = artifacts.require("./GameCommon");

const GameFactoryV1 = artifacts.require("./GameFactoryV1");
const GameStore = artifacts.require("./GameStore");
const GameItem = artifacts.require("./GameItem");

module.exports = function(deployer) {
  return deploy(deployer).then(d => {
    console.log(d);
  });
};

async function deploy(deployer) {
  await deployer.deploy(GameCommon);
  await deployer.deploy(AddressSet);
  await deployer.link(AddressSet, GameStore);
  await deployer.link(GameCommon, GameStore);

  const gameFactory = await deployer.deploy(GameFactoryV1);
  const gameStore = await deployer.deploy(GameStore, gameFactory.address);

  await deployer.link(GameCommon, GameItem);

  const result1 = await gameStore.CreateGameItem("jump1", "ability", "1.5");
  const result2 = await gameStore.CreateGameItem("jump2", "ability", "2");
  const result3 = await gameStore.CreateGameItem("jump3", "ability", "3");
  const result4 = await gameStore.CreateGameItem("jump4", "ability", "4");

  console.log(
    "=========================== game item1 ==========================",
    result1
  );
  console.log(
    "=========================== game item2 ==========================",
    result2
  );
  console.log(
    "=========================== game item3 ==========================",
    result3
  );
  console.log(
    "=========================== game item4 ==========================",
    result4
  );

  return deployer;
}
