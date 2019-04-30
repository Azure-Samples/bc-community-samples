// run by the browser each time your view template is loaded
console.log('[tollbooth-loaded]');

// our default array of dreams
const plates = ['(sample) abc-123'];

// define variables that reference elements on our page
const platesList = document.getElementById('plates');
const platesForm = document.forms[0];
const plateInput = platesForm.elements['plate'];
const boothInput = platesForm.elements['boothNumber'];
const valueInput = platesForm.elements['tollValue'];

// a helper function that creates a list item for a given dream
const appendNewPlate = function(plate) {
  const newListItem = document.createElement('li');
  newListItem.innerHTML = plate;
  platesList.appendChild(newListItem);
};

// a helper function that creates a list item for a given dream
const generateToll = async () => {
  try {
    window.ethereum.enable();
    console.log(window.web3.utils.sha3('Schoolbus'));
    var msg = window.web3.utils.sha3(valueInput, boothInput, plateInput);
    console.log("Hash for vehicle: "+ plateInput+ " for $"+valueInput+" at booth #"+boothInput+" is "+msg);
    window.web3.eth.getAccounts((error, accounts) => {   
    window.web3.eth.sign(msg, accounts[0], function(error, signature) {
      if (!error) {
        console.log(JSON.stringify(signature));
        var r = signature.slice(0, 66);
        var s = '0x' + signature.slice(66, 130);
        var v = '0x' + signature.slice(130, 132);
        v = window.web3.utils.toDecimal(v);
        // msg = '0x' + msg
        console.log(msg);
        console.log(v);
        console.log(r);
        console.log(s);

        var myContract = new window.web3.eth.Contract(
          abi,
          '0xbbc86d358de0b18d58224826f9943a26705158b5'
        );
        myContract.methods
          .verify(msg, v, r, s)
          .call()
          .then(response => {
            console.log(response);
          })
          .catch(err => {
            console.log(error);
          });
      } else console.error(error);
    });
       });
  } catch (err) {
    console.log(err);
  }
};

// iterate through every dream and add it to our page
plates.forEach(function(plate) {
  appendNewPlate(plate);
});

// listen for the form to be submitted and add a new dream when it is
platesForm.onsubmit = async event => {
  // stop our form submission from refreshing the page
  event.preventDefault();

  // get dream value and add it to the list
  plates.push(plateInput.value);
  appendNewPlate(plateInput.value);
  generateToll();
  
  // reset form
  // plateInpeInput.focus();
};
