pragma solidity >=0.4.21 <0.6.0;

contract NewRxContract {
  event NewRxCreated();

  string public NewRx;

  constructor(string memory newrx) public {
    NewRx = newrx;
  }
}
