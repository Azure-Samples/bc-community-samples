pragma solidity ^0.4.15;

import 'openzeppelin-solidity/contracts/ownership/Ownable.sol';
//import './Galleas.sol';

contract WorldsRegistry is Ownable {

    mapping(bytes32 => address) public worlds;

    //event SetPermission(address _account,bytes32 _permission,bool _value);
    //event GalleasWorldRegistered(address galeassContract, address initiator, bytes32 indexed name, uint timestamp);

    function registerGalleasWorld(address galleasContract, address initiator, bytes32 name)
    public
    onlyOwner
    {
        //todo: how to verify that galleasContract is a real galleasContract ?
        require(worlds[name] == 0, 'A World with this name already exists!');
        worlds[name] = galleasContract;
        //emit GalleasWorldRegistered(galleasContract, initiator, name, now);
    }
}