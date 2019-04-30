
//window is global only inside the browser
// var web3;

// if (typeof window !== 'undefined' && typeof window.web3 !== 'undefined') {
//   web3 = new Web3(window.web3.currentProvider);
//   console.log('MetaMask is running. You better go catch it!');
// } else {
//   // If loaded not in browser, or if metakamask in not running...
//   const provider = new Web3.providers.HttpProvider(
//     'providerURL'
//   );
//   web3 = new Web3(provider);
//   console.log('metamask is not running');
// }


    window.addEventListener('load', async () => {
          console.log("loaded page.");
            // Modern dapp browsers...
            if (window.ethereum) {
                window.web3 = new Web3(ethereum);
                  // var web3 = new Web3(new Web3.providers.HttpProvider('http://127.0.0.1:8545/'));
                try {
                  console.log("Modern dapp browser detected");
                    // Request account access if needed
                    await window.ethereum.enable();
                    // Acccounts now exposed
                    console.log(window.ethereum.accounts[0]);
                    //web3.eth.sendTransaction({/* ... */});
                } catch (error) {
                    // User denied account access...
                }
            }
            // Legacy dapp browsers...
            else if (window.web3) {
                window.web3 = new Web3(web3.currentProvider);
                // Acccounts always exposed
                //web3.eth.sendTransaction({/* ... */});
                console.log("current provider being used");
            }
            // Non-dapp browsers...
            else {
                console.log('Non-Ethereum browser detected. You should consider trying MetaMask!');
            }
        });