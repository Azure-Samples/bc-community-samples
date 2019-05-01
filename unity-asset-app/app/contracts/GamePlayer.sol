pragma solidity ^0.5.0;

import { GameCommon } from "./GameCommon.sol";
import { IGameStore } from "./GameStore.sol";
import { IGameItem } from "./GameItem.sol";
import { AddressSet } from "./AddressSet.sol";

interface IGamePlayer {
  function GetGame() external view returns (IGameStore);
  function GetItems() external view returns (address[] memory);
  function StoreItem(IGameItem gameItem) external returns (bool);
  function DiscardItem(IGameItem gameItem) external returns (bool);
}

contract GamePlayer is IGamePlayer {
  using GameCommon for GameCommon.ItemGameState;

  event PlayerCreated(address gameAddress, address playerAddress, string playerName);
  event ItemStored(address playerAddress, string playerName, address itemAddress);
  event ItemDiscarded(address playerAddress, string playerName, address itemAddress);

  string public Name;
  IGameStore public Game;
  GameCommon.ItemGameState public GameState;
  AddressSet.Data Items;

  constructor(string memory name, IGameStore game) public {
    Name = name;
    Game = game;
    emit PlayerCreated(address(game), address(this), name);
  }

  function GetGame() external view returns (IGameStore) {
    return Game;
  }

  function GetItems() external view returns (address[] memory) {
    return Items.addresses;
  }

  function StoreItem(IGameItem gameItem) external returns (bool) {
    (,address owner,,IGameStore itemGameStore,,,) = gameItem.GetProps();
    require(address(itemGameStore) == address(Game), "Item must belong to the same game");
    require(address(Game) == msg.sender || owner == msg.sender, "Must be the owner or the game");
    (, bool success) = AddressSet.insert(Items, address(gameItem));
    require(success, "Item was already stored");
    emit ItemStored(address(this), Name, address(gameItem));
    return true;
  }

  function DiscardItem(IGameItem gameItem) external returns (bool) {
    (,address owner,,IGameStore itemGameStore,,,) = gameItem.GetProps();
    require(address(itemGameStore) == address(Game), "Item must belong to the same game");
    require(address(Game) == msg.sender || owner == msg.sender, "Must be the owner or the game");
    require(
      AddressSet.remove(Items, address(gameItem)),
      "Item was not stored");
    emit ItemDiscarded(address(this), Name, address(gameItem));
    return true;
  }

}
