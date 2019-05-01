pragma solidity ^0.5.0;

library AddressSet {
  // We define a new struct datatype that will be used to
  // hold its data in the calling contract.
  struct Data {
    address[] addresses;
    mapping(address => uint) indexes;
  }

  function insert(Data storage self, address value)
    public
    returns (uint index, bool success)
  {
    if (contains(self, value)) {
      success = false; //already exists
    } else {
      index = self.addresses.length;
      self.addresses.push(value);
      self.indexes[value] = index;
      success = true;
    }
  }

  function remove(Data storage self, address value)
    public
    returns (bool)
  {
    if (!contains(self, value)) {
      return false; //doesnt exist
    }
    delete self.addresses[self.indexes[value]];
    delete self.indexes[value];
    return true;
  }

  function contains(Data storage self, address value)
    public
    view
    returns (bool)
  {
    if (self.addresses.length == 0) {
      return false;
    }
    return self.addresses[self.indexes[value]] == value;
  }
}