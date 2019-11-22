//web3.personal.unlockAccount(addr, pass);

var fromAddress = (await web3.eth.personal.getAccounts())[0]
var toAddress = "0x44FAe35d8A77794F60d65D8346c37da4af923134";
var amount = '1000'; //willing to send 2 ethers
var amountToSend = web3.utils.toWei(amount);

var send = web3.eth.sendTransaction({from: fromAddress, to:toAddress, value:amountToSend});