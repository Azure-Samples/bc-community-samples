pragma solidity ^0.5.0;

library GameCommon {
  enum ItemGameState { NotRegistered, Registered }

  struct StoreAccount {
    address Owner;
    uint Balance;
    uint TotalSold;
  }
}