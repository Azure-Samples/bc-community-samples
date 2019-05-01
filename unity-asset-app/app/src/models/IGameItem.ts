import { Color, BackgroundColorProperty } from "csstype";
import { CSSProperties } from "react";
import { SemanticCOLORS } from "semantic-ui-react";
import { Address } from "cluster";
import { ItemCategoryKeys } from "../components/data";
import { Contract } from "web3-eth-contract";

export interface IGameStore {}

export interface IGameItemCategory {
  color: SemanticCOLORS;
  key: ItemCategoryKeys;
  name: string;
  src: string;
}

export interface IGameItem {
  busy: boolean;
  category: IGameItemCategory;
  contract: Contract;
  game: string;
  itemData: string;
  itemKey: ItemCategoryKeys;
  itemType: string;
  owner: string;
  price: number;
  gameState: number;
}

export interface IGameStoreAccount {
  address: string;
  exists: boolean;
  balance: number;
  totalSold: number;
}
