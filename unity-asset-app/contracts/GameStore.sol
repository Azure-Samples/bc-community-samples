pragma solidity ^0.5.0;

import { GameCommon } from "./GameCommon.sol";
import { IGameItem, GameItem } from "./GameItem.sol";
import { IGamePlayer } from "./GamePlayer.sol";
import { AddressSet } from "./AddressSet.sol";


interface IGameFactory {
  function CreateGameItem(IGameStore gameStore, string calldata itemKey, string calldata itemType, string calldata itemData) external
  returns (IGameItem);
}

contract GameFactoryV1 is IGameFactory {
  // game master methods
  function CreateGameItem(IGameStore gameStore, string calldata itemKey, string calldata itemType, string calldata itemData) external
  returns (IGameItem)
  {
    return new GameItem(gameStore, itemKey, itemType, itemData);
  }
}


interface IGameStore {
  function TransferGameMaster(address newGameMaster) external;
  function CreateGameItem(string calldata itemKey, string calldata itemType, string calldata itemData) external;
  function SetGameFactory(IGameFactory factory) external;

  // info methods
  function GetAllItems() external view returns (address[] memory);
  function GetAllAccounts() external view returns (address[] memory);
  function GetAccount(address owner) external view
  returns (bool exists, uint balance, uint totalSold);

  // account methods
  function RegisterAccount(address owner) external;
  function RegisterMyItem(IGameItem item) external;
  function GetMyAccount() external view returns (uint balance, uint totalSold);
  function PurchaseItem(IGameItem gameItem) external payable;

  // account holders can withdraw funds for the items sold
  function WithdrawBalance() external returns (uint balance, uint withdrawn);
}

contract GameStore is IGameStore {
  using GameCommon for GameCommon.ItemGameState;

  event NewGameMaster(address gameMaster);
  event GameItemCreated(address item, string itemKey, string itemType);
  event GameItemRegistered(address item);
  event StoreAccountRegistered(address owner);
  event FundsWithdrawn(address owner, uint withdrawnAmount);
  event ItemPurchased(address item, address previousOwner, address newOwner);

  struct StoreAccount {
    address Owner;
    uint Balance;
    uint TotalSold;
  }

  address public GameMaster;
  IGameFactory public GameFactory;

  constructor(IGameFactory gameFactory) public {
    GameFactory = gameFactory;
    GameMaster = msg.sender;
    emit NewGameMaster(msg.sender);
  }

  AddressSet.Data AllItems;
  AddressSet.Data AllAccounts;
  mapping (address => StoreAccount) AccountsByOwner;

  // modifiers
  modifier HasStoreAccount() {
    (bool exists,) = _getAccount(msg.sender);
    require(exists, "Caller must have a store account");
    _;
  }
  modifier IsGameMaster() {
    require(msg.sender == GameMaster, "Must be the GameMaster");
    _;
  }

  // game master methods
  function CreateGameItem(string calldata itemKey, string calldata itemType, string calldata itemData) external IsGameMaster {
    IGameItem gameItem = GameFactory.CreateGameItem(this, itemKey, itemType, itemData);
    _ensureItem(gameItem);
    gameItem.GameChangeOwner(GameMaster);
    gameItem.GameItemRegistered();
    emit GameItemCreated(address(gameItem), itemKey, itemType);
  }

  function TransferGameMaster(address newGameMaster) external IsGameMaster {
    GameMaster = newGameMaster;
  }

  function SetGameFactory(IGameFactory factory) external IsGameMaster {
    GameFactory = factory;
  }

  // game info methods

  // get all items registered to this game
  function GetAllItems() external view returns (address[] memory)
  {
    return AllItems.addresses;
  }

  // get all account owners
  function GetAllAccounts() external view returns (address[] memory)
  {
    return AllAccounts.addresses;
  }

  // get account details
  function GetAccount(address owner)
    external
    view
    returns (bool exists, uint balance, uint totalSold)
  {
    StoreAccount memory account;
    (exists, account) = _getAccount(owner);
    balance = account.Balance;
    totalSold = account.TotalSold;
  }

  // account methods

  // register an account
  function RegisterAccount(address owner) external
  {
    require(!AddressSet.contains(AllAccounts, owner), "Account already exists");
    _pushAccountUnsafe(owner);
    emit StoreAccountRegistered(owner);
  }

  // register a game item with the sender's account
  function RegisterMyItem(IGameItem item) external HasStoreAccount
  {
    bool added = _ensureItem(item);
    require(added, "Item was already registered");
    require(item.GameItemRegistered(), "GameStore could not register the item");
    emit GameItemRegistered(address(item));
  }

  // get the sender's account
  function GetMyAccount()
    external
    view
    HasStoreAccount
    returns (uint balance, uint totalSold)
  {
    (,StoreAccount memory account) = _getAccount(msg.sender);
    balance = account.Balance;
    totalSold = account.TotalSold;
  }

  // purchase an item from another account
  function PurchaseItem(IGameItem gameItem)
    external
    HasStoreAccount
    payable
  {
    (
      GameCommon.ItemGameState itemGameState,
      address oldOwner,
      uint itemPrice,
      IGameStore itemGame,,,
    ) = gameItem.GetProps();
    require(itemPrice > 0, "Owner has not set a price - cannot be free");
    require(itemPrice == msg.value, "Exact amount is required");
    require(itemGameState == GameCommon.ItemGameState.Registered, "Item must be marked registered");
    require(itemGame == this, "Item must be registered with this game");
    require(oldOwner != msg.sender, "Owner cannot purchase self-owned item");

    //update the balance on the account
    AccountsByOwner[oldOwner].Balance += msg.value;
    AccountsByOwner[oldOwner].TotalSold += msg.value;

    //tell the item to change owners
    gameItem.GameChangeOwner(msg.sender);

    emit ItemPurchased(address(gameItem), oldOwner, msg.sender);
  }

  //withdraw funds from sold item
  function WithdrawBalance()
    external
    HasStoreAccount
    returns (uint balance, uint withdrawn)
  {
    (bool exists, StoreAccount memory account) = _getAccount(msg.sender);
    require(exists, "Store account does not exists - nothing to withdraw");
    balance = account.Balance;
    require(balance > 0, "Nothing to withdraw");
    withdrawn = balance;
    AccountsByOwner[msg.sender].Balance = 0;
    AccountsByOwner[msg.sender].TotalSold += balance;
    emit FundsWithdrawn(account.Owner, withdrawn);
    msg.sender.transfer(balance);
  }



  //private read functions
  function _ensureAccount(address owner)
    private
    returns (StoreAccount memory account)
  {
    bool exists;
    (exists, account) = _getAccount(owner);
    if (!exists) {
      bool success;
      (success, account) = _pushAccountUnsafe(owner);
      require(success, "Failed to store new account");
    }
  }

  function _ensureItem(IGameItem item)
    private
    returns (bool added)
  {
    bool exists = AddressSet.contains(AllItems, address(item));
    if (!exists) {
      (, added) = AddressSet.insert(AllItems, address(item));
    }
  }

  function _getAccount(address owner)
    private
    view
    returns (bool exists, StoreAccount memory account)
  {
    exists = AddressSet.contains(AllAccounts, owner);
    if (exists) {
      account = AccountsByOwner[owner];
    }
  }

  function _pushAccountUnsafe(address owner)
    private
    returns (bool success, StoreAccount memory account)
  {
    (, success) = AddressSet.insert(AllAccounts, owner);
    account.Owner = owner;
    AccountsByOwner[owner] = account;
  }
}
