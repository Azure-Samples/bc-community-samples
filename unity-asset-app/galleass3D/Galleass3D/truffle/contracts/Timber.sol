pragma solidity ^0.4.15;

/*

  https://galleass.io
  by Austin Thomas Griffith & Thomas Haller

  Timber is harvested from forest tiles and used to build ships and buildings.

*/

import './Galleasset.sol';
import './ERC677Token.sol';
import 'openzeppelin-solidity/contracts/token/ERC20/MintableToken.sol';

contract Timber is Galleasset, MintableToken, ERC677Token {

  string public constant name = "Galleass Timber";
  string public constant symbol = "G_TIMBER";
  uint8 public constant decimals = 0;

  uint256 public constant INITIAL_SUPPLY = 0;

  constructor(address _galleass) Galleasset(_galleass) public {
    totalSupply_ = INITIAL_SUPPLY;
  }

  function galleassTransferFrom(address _from, address _to, uint256 _value) public returns (bool) {
    require(_to != address(0));
    require(_value <= balances[_from]);
    require(hasPermission(msg.sender,"transferTimber"));

    balances[_from] = balances[_from].sub(_value);
    balances[_to] = balances[_to].add(_value);
    emit Transfer(_from, _to, _value);
    return true;
  }

  function galleassMint(address _to,uint _amount) public returns (bool){
    require(hasPermission(msg.sender,"mintTimber"));
    totalSupply_ = totalSupply_.add(_amount);
    balances[_to] = balances[_to].add(_amount);
    emit Mint(_to, _amount);
    emit Transfer(address(0), _to, _amount);
    return true;
  }

}
