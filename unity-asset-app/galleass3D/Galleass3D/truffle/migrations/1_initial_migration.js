//const Migrations = artifacts.require("Migrations");

const process = require('process');
const Registry = artifacts.require("WorldsRegistry");
const Galleass =  artifacts.require("Galleass");

module.exports = async function(deployer) {
  //deployer.deploy(Migrations);
  //console.log('start Deploy...');
  const __deployer = deployer;

  

  
  var accounts = await web3.eth.getAccounts();
  var deploymentAccount = accounts[0];
  console.log('deploying main contract with account:' + deploymentAccount); 


  //var registry = await Registry.at('0x6EB0fadc34060AF5EfB053b4cB413CE5809b6f16');
  //var registry = await deployer.deploy(Registry);

  var galleas = await deployer.deploy(Galleass, 'Thomas Haller');
  console.log('main account deployed!'); 

  var seconds = Math.round(new Date() / 1000);

  var secondsSinceGameBirth = seconds - 1556310063;

  console.log('seconds: ' + seconds);

  //await registry.registerGalleasWorld.sendTransaction(galleas.address, deploymentAccount, web3.utils.fromAscii('test - world sec:' + secondsSinceGameBirth));
  //const __mainContract = galleas;
  //const var gallAddr = Galleass.address;

  async function deployContract(contractName){
    console.log('Deploying ' + contractName);
    const contractArtifact = artifacts.require(contractName);
    const deployedContract = await deployer.deploy(contractArtifact, galleas.address);
    const setContractResult = await galleas.setContract.sendTransaction(web3.utils.fromAscii(contractName), deployedContract.address);
  
    if (setContractResult) {
      return deployedContract;
    } else {
      return null;
    }
  }

  async function setPermission(contract, permissionName) {
    
    console.log("setting " + contract.address + " " + contract.contractName + " permission:" + permissionName);

    // function setPermission(address _contract, bytes32 _permission, bool _value) 
    var setPermissionResult = await galleas.setPermission(contract.address, web3.utils.fromAscii(permissionName), true);
   
    if (!setPermissionResult.receipt.status) {
      console.error("FAILED: setting " + contract.address + " " + contract.contractName + " permission:" + permissionName);
    }
  }

  const timber = await deployContract('Timber');
  const fillet = await deployContract('Fillet');
  const dogger = await deployContract('Dogger');
  const copper = await deployContract('Copper');
  const bay = await deployContract('Bay');
  const citizen = await deployContract('Citizens');
  const citizenLib = await deployContract('CitizensLib');
  const land = await deployContract('Land');
  const timberCamp = await deployContract('TimberCamp');
  const landLib = await deployContract('LandLib');
  const harbor = await deployContract('Harbor');
  const fishMonger = await deployContract('Fishmonger');
  const village = await deployContract('Village');
  const market = await deployContract('Market');
  const sea = await deployContract('Sea');
  const catfish = await deployContract('Catfish');

  setPermission(bay, 'transferDogger');
  setPermission(bay, 'updateExperience');

  setPermission(landLib, 'useCitizens');
  setPermission(landLib, 'mintTimber');
  setPermission(landLib, 'mintStone');
  setPermission(landLib, 'mintGreens');
  setPermission(landLib, 'transferStone');
  setPermission(landLib, 'transferGreens');
  setPermission(landLib, 'transferTimber');

  setPermission(timberCamp, 'mintTimber');


  setPermission(harbor, 'buildDogger');
  setPermission(harbor, 'buildSchooner');
  setPermission(harbor, 'updateExperience');
  setPermission(harbor, 'embarkShips');
  
  
  setPermission(fishMonger, 'transferFish');
  setPermission(fishMonger, 'mintFillet');
  setPermission(fishMonger, 'updateExperience');


  setPermission(village, 'createCitizens');

  setPermission(citizenLib, 'transferFood');


  setPermission(market, 'transferTimber');

  catfish.mint.sendTransaction(deploymentAccount, 10);
  

  //console.log(copper);

  // console.log('Generating  Land...');
  // await landLib.generateLand.sendTransaction();



  // const fs = require('fs');
  // fs.writeFile("./build/latestGalleasAddress.txt", galleas.address, function(err) {
  //   if(err) {
  //       return console.log(err);
  //   }

  //   console.log("latest Galleass address written to: build/latestGalleasAddress.txt");
  // }); 
  // galleas.address

};
