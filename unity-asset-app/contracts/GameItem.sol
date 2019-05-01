pragma solidity ^0.5.0;

import { GameCommon } from "./GameCommon.sol";
import { IGameStore } from "./GameStore.sol";

interface IGameItem {
  function GetProps()
    external
    view
    returns (
      GameCommon.ItemGameState state,
      address owner,
      uint price,
      IGameStore game,
      string memory itemKey,
      string memory itemType,
      string memory itemData
    );

  function SetPrice(uint price) external;
  function ChangeOwner(address newOwner) external;
  function GameChangeOwner(address newOwner) external;
  function GameItemRegistered() external returns (bool);
}

contract GameItem is IGameItem {
  using GameCommon for GameCommon.ItemGameState;

  GameCommon.ItemGameState public GameState;
  address public Owner;
  uint public Price;
  IGameStore public Game;
  string public ItemKey;
  string public ItemType;
  string public ItemData;

  event ItemCreated(string itemKey, string itemType, address owner);
  event ItemPriceChanged(string itemType, uint price);
  event ItemGameRegistered(string itemType, address game);
  event ItemHasNewOwner(string itemType, address previousOwner, address newOwner);

  constructor(IGameStore game, string memory itemKey, string memory itemType, string memory itemData) public {
    GameState = GameCommon.ItemGameState.NotRegistered;
    Price = 0;
    Game = game;
    Owner = msg.sender;
    ItemKey = itemKey;
    ItemType = itemType;
    ItemData = itemData;

    emit ItemCreated(itemKey, itemType, msg.sender);
  }

  //ANYONE external can call

  function GetProps() external view returns (
    GameCommon.ItemGameState gameState,
    address owner,
    uint price,
    IGameStore game,
    string memory itemKey,
    string memory itemType,
    string memory itemData
  ) {
    gameState = GameState;
    owner = Owner;
    game = Game;
    price = Price;
    itemKey = ItemKey;
    itemType = ItemType;
    itemData = ItemData;
  }

  //modifiers
  modifier IsOwner() {
    require(address(msg.sender) != address(0x0), "You fedx");
    require(Owner == msg.sender, "Must be owner");
    _;
  }

  modifier IsGameStore() {
    require(address(Game) == msg.sender, "Must be the GameStore");
    _;
  }

  // internal methods
  function ChangeOwnerUnsafe(address newOwner) private {
    address previousOwner = Owner;
    Owner = newOwner;
    emit ItemHasNewOwner(ItemType, previousOwner, newOwner);
  }

  //OWNER only methods
  function ChangeOwner(address newOwner) external IsOwner {
    ChangeOwnerUnsafe(newOwner);
  }

  function SetPrice(uint price) external IsOwner {
    Price = price;
    emit ItemPriceChanged(ItemType, price);
  }

  // GAME methods
  function GameChangeOwner(address newOwner) external IsGameStore {
    ChangeOwnerUnsafe(newOwner);
  }

  function GameItemRegistered() external IsGameStore returns (bool) {
    GameState = GameCommon.ItemGameState.Registered;
    emit ItemGameRegistered(ItemType, address(Game));
    return true;
  }

  // helpers

  function toString(address x) public pure returns (string memory) {
    bytes memory b = new bytes(20);
    for (uint i = 0; i < 20; i++)
    b[i] = byte(uint8(uint(x) / (2**(8*(19 - i)))));
    return string(b);
  }
}
