import React, { Component, RefObject } from "react";
import { IGameItem } from "../models/IGameItem";
import {
  Button,
  Card,
  Rating,
  Image,
  Statistic,
  Reveal,
  Loader,
  Confirm,
  Label,
  Input,
  InputOnChangeData,
  Dimmer,
  SemanticCOLORS,
  List,
  Icon
} from "semantic-ui-react";
import NumberFormat, { NumberFormatValues } from "react-number-format";
import { number } from "prop-types";

export interface IGameItemCardProps {
  busy: boolean;
  item: IGameItem;
  purchaseItem: (item: IGameItem) => Promise<IGameItem>;
  setPrice: (item: IGameItem, price: number) => Promise<IGameItem>;
  account?: string;
}
export interface IGameItemCardState {
  isPurchasing: boolean;
  isConfirming: boolean;
  priceChange?: number;
}
export class GameItemCard extends Component<
  IGameItemCardProps,
  IGameItemCardState
> {
  state: IGameItemCardState = {
    isPurchasing: false,
    isConfirming: false
  };
  constructor(props: IGameItemCardProps) {
    super(props);
  }

  confirmPurchaseClick = async () => {
    await this.props.purchaseItem(this.props.item);
    this.setState({
      isConfirming: false
    });
  };

  confirmSettingPriceClick = async () => {
    if (this.state.priceChange === undefined) {
      throw new Error("No price change");
    }
    await this.props.setPrice(this.props.item, this.state.priceChange);
  };

  cancelPurchaseClick = () => {
    this.setState({
      isConfirming: false
    });
  };

  purchaseClick = () => {
    this.setState({
      isConfirming: true
    });
  };

  cancelPriceChange = () => {
    this.setState({
      priceChange: undefined
    });
  };

  isPriceChanging = () => {
    return (
      (this.state.priceChange !== undefined &&
        this.state.priceChange !== this.props.item.price) ||
      false
    );
  };

  renderPurchaseButton = () => {
    if (this.props.busy || this.props.item.busy) {
    } else {
      if (this.props.item.owner === this.props.account) {
        const enableUpdatePriceButton = this.isPriceChanging();

        return (
          <>
            <Button
              onClick={this.cancelPriceChange}
              disabled={!enableUpdatePriceButton}
              content="Update"
            />
            <Button
              onClick={this.confirmSettingPriceClick}
              disabled={!enableUpdatePriceButton}
              content="Update"
            />
          </>
        );
      } else {
        return (
          <Button
            disabled={this.props.item.price === 0}
            onClick={this.purchaseClick}
          >
            Purchase Item
          </Button>
        );
      }
    }
  };

  isBusy = () => {
    return (
      this.props.item.busy || this.state.isPurchasing || this.state.isConfirming
    );
  };

  renderBusyImage = () => {
    return (
      <>
        <Loader active />
        <Image
          src="/images/blank.svg"
          height="300"
          style={{ backgroundColor: "silver" }}
        />
      </>
    );
  };

  renderCardRevealCoverImage = (item: IGameItem) => {
    if (this.state.isConfirming) {
      return this.renderItemCard(item);
    }
    if (this.isBusy()) {
      return this.renderBusyImage();
    }
    const backgroundColor =
      this.props.item && this.props.item.owner === this.props.account
        ? this.props.item.category.color
        : "silver";
    return (
      <Image
        src={`/images/${this.props.item.category.src}`}
        height="300"
        style={{ backgroundColor }}
      />
    );
  };

  inputPrice = 0;
  onPriceChanged = (
    event: React.ChangeEvent<HTMLInputElement>,
    data: InputOnChangeData
  ) => {
    this.setState({
      priceChange: Number(data.value)
    });
  };

  renderItemCard = (item: IGameItem) => {
    const isOwner = this.props.account === item.owner;
    const labelStyle = { width: 65, textAlign: "center" };
    return (
      <Card
        style={{
          width: "100%",
          height: 300,
          textAlign: "left"
        }}
      >
        <Dimmer active={this.isBusy()}>
          <Loader />
        </Dimmer>

        <Card.Content>
          <Input
            label={
              <Label style={labelStyle} pointing="right">
                Address
              </Label>
            }
            value={item.contract.address}
            size="small"
            type="text"
          />
        </Card.Content>
        <Card.Content>
          <Input
            label={
              <Label style={labelStyle} pointing="right">
                Owner
              </Label>
            }
            value={item.owner}
            size="small"
            type="text"
          />
        </Card.Content>
        <Card.Content>
          <Input
            label={<Label pointing="right" icon="ethereum" content="Price" />}
            disabled={!isOwner}
            size="small"
            type="number"
            value={
              this.state.priceChange === undefined
                ? this.props.item.price
                : this.state.priceChange
            }
            min={0}
            onChange={this.onPriceChanged}
          />
        </Card.Content>
        <Card.Content textAlign="center">
          {this.renderPurchaseButton()}
        </Card.Content>
      </Card>
    );
  };

  render() {
    const detail = this.props.item;

    const coverImage = this.renderCardRevealCoverImage(this.props.item);
    const content = this.renderItemCard(this.props.item);
    const isChangingPrice = this.isPriceChanging();

    const isOwner = detail.owner === this.props.account;
    const isForSale = !isOwner && detail.price > 0;
    const color: SemanticCOLORS = isForSale ? "red" : isOwner ? "blue" : "grey";
    const label =
      ((isOwner || isForSale) && <Label corner color={color} />) || null;

    return (
      <>
        <Confirm
          open={this.state.isConfirming}
          cancelButton="Never mind"
          confirmButton="Let's do it"
          onCancel={this.cancelPurchaseClick}
          onConfirm={this.confirmPurchaseClick}
        />
        <Card
          centered={true}
          raised={true}
          style={{ backgroundColor: "silver", cursor: "hand" }}
        >
          {label}
          <Card.Header>{detail.category.name}</Card.Header>
          <Card.Content>
            <Reveal
              animated="move down"
              instant={this.isBusy() || isChangingPrice}
              active={this.isBusy() || isChangingPrice}
            >
              <Reveal.Content visible>{coverImage}</Reveal.Content>
              <Reveal.Content hidden>{content}</Reveal.Content>
            </Reveal>
          </Card.Content>
          <Card.Content>
            <List horizontal size="massive">
              <List.Item>
                <Label size="massive" content={detail.itemKey} />
              </List.Item>
              <List.Item>
                <Label
                  icon="ethereum"
                  size="massive"
                  detail={
                    <NumberFormat
                      value={Number(detail.price)}
                      displayType="text"
                      decimalScale={20}
                      thousandSeparator={true}
                    />
                  }
                />
              </List.Item>
            </List>
          </Card.Content>
          <Card.Content>
            <Rating
              rating={3}
              maxRating={5}
              style={{ verticalAlign: "middle" }}
            />
          </Card.Content>
        </Card>
      </>
    );
  }
}
