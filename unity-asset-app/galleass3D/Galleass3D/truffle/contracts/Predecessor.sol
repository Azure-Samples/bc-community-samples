pragma solidity ^0.4.15;

import 'openzeppelin-solidity/contracts/ownership/Ownable.sol';
import './Staged.sol';


contract Predecessor is Ownable, Staged{
    constructor () public {}
    address public descendant;
    function setDescendant(address _descendant) onlyOwner isNotProduction public {
      descendant=_descendant;
    }
    modifier hasNoDescendant() {
      require(descendant == address(0));
      _;
    }
}
