pragma solidity ^0.4.24;


interface StandardTokenInterface {
  function transferFrom(address /*_from*/, address /*_to*/, uint256 /*_value*/) external returns (bool);
  function galleassTransferFrom(address /*_from*/, address /*_to*/, uint256 /*_value*/) external returns (bool);
  function transfer(address /*_to*/, uint256 /*_value*/) external returns (bool);
  function approve(address /*_spender*/, uint256 /*_value*/) external returns (bool);
  function galleassMint(address, uint256 ) external returns (bool);
}