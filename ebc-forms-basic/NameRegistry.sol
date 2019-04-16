pragma solidity >=0.4.22 <0.6.0;
contract NameRegistry {
    address owner;
    mapping(address => bytes32) public Nicknames;
    mapping(bytes32 => address) public Addresses;
    event NameSet(address addr, bytes32 nickname);
    function setNickname(address addr, bytes32 nickname) public {
        require(msg.sender == owner);
        Nicknames[addr] = nickname;
        Addresses[nickname] = addr;
        emit NameSet(addr, nickname);
    }
}