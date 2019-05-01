import { IGameItemCategory, IGameItem } from "../models/IGameItem";

export const Images = {
  jump1: "jumping-dog.svg",
  jump2: "jump-across.svg",
  jump3: "kangaroo.svg",
  jump4: "running-ninja.svg"
};

export type ItemCategoryKeys = "jump1" | "jump2" | "jump3" | "jump4";
const jump1: IGameItemCategory = {
  key: "jump1",
  src: Images.jump1,
  name: "Jumping Dog",
  color: "olive"
};
const jump2: IGameItemCategory = {
  key: "jump2",
  src: Images.jump2,
  name: "Pole Vault",
  color: "teal"
};
const jump3: IGameItemCategory = {
  key: "jump3",
  src: Images.jump3,
  name: "Bouncy Kangaroo",
  color: "violet"
};
const jump4: IGameItemCategory = {
  key: "jump4",
  src: Images.jump4,
  name: "Flying Ninja",
  color: "red"
};
export const ItemCategories = new Map<ItemCategoryKeys, IGameItemCategory>([
  ["jump1", jump1],
  ["jump2", jump2],
  ["jump3", jump3],
  ["jump4", jump4]
]);
