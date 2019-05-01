import React, { Component, PureComponent } from "react";
import { IGameItem } from "../models/IGameItem";
import { Card } from "semantic-ui-react";
import { GameItemCard } from "./GameItemCard";

export interface IGameItemListProps {
  account?: string;
  busy: boolean;
  items: IGameItem[];
  purchaseItem: (item: IGameItem) => Promise<IGameItem>;
  setPrice: (item: IGameItem, price: number) => Promise<IGameItem>;
}

export class GameItemList extends PureComponent<IGameItemListProps> {
  renderItems() {
    return this.props.items.map(item => (
      <GameItemCard
        key={item.itemKey}
        busy={this.props.busy}
        item={item}
        account={this.props.account}
        purchaseItem={this.props.purchaseItem}
        setPrice={this.props.setPrice}
      />
    ));
  }

  render() {
    return <Card.Group centered>{this.renderItems()}</Card.Group>;
  }
}
