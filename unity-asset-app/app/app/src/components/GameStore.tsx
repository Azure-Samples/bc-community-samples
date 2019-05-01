import React, { Component } from "react";
import { GameItemList } from "./GameItemList";
import { IGameItem, IGameStoreAccount } from "../models/IGameItem";
import Web3 from "web3";
import {
  Label,
  Card,
  Input,
  InputOnChangeData,
  Tab,
  MenuItemProps,
  Button,
  List,
  Icon
} from "semantic-ui-react";
import { statement } from "@babel/template";
import {
  getAccount,
  getBalance,
  updateGameStoreItemPrice,
  getGameStoreItems,
  getGameStoreItem,
  purchaseGameStoreItem,
  getGameStoreAccount
} from "./db";
import NumberFormat from "react-number-format";
import { ItemCategories, ItemCategoryKeys } from "./data";
import { connect } from "tls";

export interface IGameStoreProps {}

export interface IGameStoreState {
  isBusy: boolean;
  error?: string;
  isConnectingToEthereum: boolean;
  isConnectingToGameStore: boolean;
  isConnectedToEthereum: boolean;
  isConnectedToGameStore: boolean;
  gameStoreAddress?: string;
  gameStoreAccount?: IGameStoreAccount;
  account: string | null;
  balance: string | null;
  items: IGameItem[];
}

export class GameStore extends Component<IGameStoreProps, IGameStoreState> {
  state: IGameStoreState = {
    isBusy: true,
    account: null,
    balance: null,
    items: [],
    isConnectingToEthereum: false,
    isConnectingToGameStore: false,
    isConnectedToEthereum: false,
    isConnectedToGameStore: false
  };

  setItemBusyState = async (item: IGameItem, busy: boolean) => {
    let newItem: IGameItem | undefined;
    let noUpdate = false;
    const items = this.state.items.map(stateItem => {
      if (stateItem.contract.address === item.contract.address) {
        if (stateItem.busy === busy) {
          noUpdate = true;
        } else {
          newItem = {
            ...item,
            busy
          };
          return newItem;
        }
      }
      return stateItem;
    });
    if (noUpdate) {
      return item;
    }
    if (!newItem) {
      throw new Error("Item not found");
    }
    await this.setStateAsync({
      items
    });
    return newItem;
  };

  setPrice = async (item: IGameItem, price: number) => {
    try {
      item = await this.setItemBusyState(item, true);
      const confirmation = await updateGameStoreItemPrice(item, price);
      await this.loadGameStoreItem(item.contract.address);
      item = await this.setItemBusyState(item, false);
    } catch (e) {
      await this.setStateAsync({ error: e.message || e, isBusy: false });
    }
    return item;
  };

  purchaseItem = async (item: IGameItem) => {
    try {
      item = await this.setItemBusyState(item, true);
      const confirmation = await purchaseGameStoreItem(item);
      item = await this.loadGameStoreItem(item.contract.address);
      item = await this.setItemBusyState(item, false);
    } catch (e) {
      await this.setStateAsync({ error: e.message || e, isBusy: false });
    }
    return item;
  };

  setStateAsync = (newState: Partial<IGameStoreState>) => {
    return new Promise(resolve =>
      this.setState(newState as IGameStoreState, () => resolve())
    );
  };

  componentDidMount() {
    this.connect(this.state.gameStoreAddress).catch(e => {
      this.setState({
        error: e.message || e,
        isBusy: false,
        isConnectingToEthereum: false,
        isConnectingToGameStore: false
      });
    });
  }

  async connect(gameStoreAddress?: string) {
    if (!gameStoreAddress && !this.state.gameStoreAddress && localStorage) {
      const storedAddress = localStorage.getItem("gameStoreAddress");
      if (storedAddress) {
        gameStoreAddress = storedAddress;
        await this.setStateAsync({
          gameStoreAddress
        });
      }
    }

    if (!this.state.isConnectedToEthereum) {
      await this.setStateAsync({
        isBusy: true,
        isConnectingToEthereum: true,
        isConnectedToEthereum: false,
        isConnectingToGameStore: false,
        isConnectedToGameStore: false
      });
      const connection = await this.connectToEthereum();
      await this.setStateAsync({
        balance: connection.balance,
        account: connection.account,
        isConnectingToEthereum: false,
        isConnectedToEthereum: true,
        isConnectingToGameStore: true
      });
      await this.connectToGameStore(
        gameStoreAddress || this.state.gameStoreAddress
      );
    } else {
      await this.setStateAsync({
        error: undefined,
        isBusy: true,
        isConnectedToGameStore: false,
        isConnectingToGameStore: true
      });
      await this.connectToGameStore(
        gameStoreAddress || this.state.gameStoreAddress
      );
      if (gameStoreAddress) {
        localStorage.setItem("gameStoreAddress", gameStoreAddress);
      }
    }
    await this.setStateAsync({
      error: undefined,
      isBusy: false,
      isConnectingToGameStore: false,
      isConnectedToGameStore: true,
      gameStoreAddress: gameStoreAddress || this.state.gameStoreAddress
    });
  }

  connectToEthereum = async () => {
    const account = await getAccount();
    const balance = await getBalance();
    return {
      account,
      balance
    };
  };

  connectToGameStore = async (gameStoreAddress?: string) => {
    if (!gameStoreAddress) {
      throw new Error("Please enter a valid GameStore address");
    }
    await this.setStateAsync({
      error: undefined,
      isBusy: true,
      isConnectingToGameStore: true,
      isConnectedToGameStore: false
    });
    await this.loadGameStoreItems(gameStoreAddress);
    await this.setStateAsync({
      error: undefined,
      isBusy: false,
      isConnectingToGameStore: false,
      isConnectedToGameStore: true
    });
  };

  createAccount = async () => {
    if (this.state.gameStoreAddress) {
      try {
        await this.setStateAsync({
          error: undefined,
          isBusy: true
        });
        const gameStoreAccount = await getGameStoreAccount(
          this.state.gameStoreAddress
        );
        await this.setStateAsync({
          error: undefined,
          isBusy: false,
          gameStoreAccount
        });
      } catch (ex) {
        await this.setStateAsync({
          error: ex.message || ex,
          isBusy: false
        });
      }
    }
  };

  loadGameStoreItems = async (gameStoreAddress: string) => {
    const gameItems = await getGameStoreItems(gameStoreAddress);
    await Promise.all(gameItems.map(this.loadGameStoreItem));
    await this.setStateAsync({
      gameStoreAddress: gameStoreAddress
    });
  };

  loadGameStoreItem = async (itemAddress: string) => {
    const item: IGameItem = await getGameStoreItem(itemAddress);
    const items = this.mergeGameStoreItem(this.state.items, item);
    await this.setStateAsync({ items });
    return item;
  };

  mergeGameStoreItem = (items: IGameItem[], item: IGameItem) => {
    let isNew = true;
    const updatedItems = items.map(existingItem => {
      if (existingItem.contract.address !== item.contract.address) {
        return existingItem;
      }
      isNew = false;
      return item;
    });
    if (isNew) {
      updatedItems.push(item);
    }
    const mergedItem = updatedItems.find(i => i == item);
    if (!mergedItem) {
      throw new Error("Item didnt make it");
    }
    return updatedItems;
  };

  onGameStoreAddressChange = (
    event: React.ChangeEvent<HTMLInputElement>,
    data: InputOnChangeData
  ) => {
    if (data.value.length === 42) {
      this.connect(data.value).catch(e => {
        this.setState({
          error: e.message || e,
          isBusy: false,
          isConnectingToEthereum: false,
          isConnectingToGameStore: false
        });
      });
    }
  };

  render() {
    const acct = this.state.gameStoreAccount;
    const balance = (acct && acct.exists && acct.balance) || 0;
    const totalSold = (acct && acct.exists && acct.totalSold) || 0;

    return (
      <div style={{ padding: 20 }}>
        <List horizontal>
          <List.Item>
            <Card fluid>
              <Card.Header>MetaMask</Card.Header>
              <Card.Content>
                <Label icon="at" detail={this.state.account || "Loading..."} />
              </Card.Content>
              <Card.Content>
                <Label
                  icon="ethereum"
                  detail={
                    <NumberFormat
                      value={Number(this.state.balance || 0)}
                      displayType="text"
                      decimalScale={20}
                      thousandSeparator={true}
                    />
                  }
                />
              </Card.Content>
            </Card>
          </List.Item>
          <List.Item>
            <Card fluid>
              <Card.Header>GameStore</Card.Header>
              <Card.Content>
                <Label>
                  <Input
                    style={{ width: 400 }}
                    label={<Label icon="at" pointing="right" />}
                    placeholder="GameStore address"
                    loading={this.state.isConnectingToEthereum}
                    fluid
                    onChange={this.onGameStoreAddressChange}
                    value={this.state.gameStoreAddress}
                  />
                </Label>
              </Card.Content>

              <Card.Content>
                <List horizontal>
                  <List.Item>
                    <List.Content>
                      <Label>
                        <Icon name="ethereum" />
                        <NumberFormat
                          value={balance}
                          displayType="text"
                          decimalScale={20}
                          thousandSeparator={true}
                          prefix={"Banked "}
                        />
                      </Label>
                    </List.Content>
                  </List.Item>
                  <List.Item>
                    <List.Content>
                      <Label>
                        <Icon name="ethereum" />
                        <NumberFormat
                          value={totalSold}
                          displayType="text"
                          decimalScale={20}
                          thousandSeparator={true}
                          prefix={"Total Sold "}
                        />
                      </Label>
                    </List.Content>
                  </List.Item>
                </List>
              </Card.Content>
            </Card>
          </List.Item>
        </List>

        {this.renderGameStore()}
      </div>
    );
  }

  renderGameStore = () => {
    if (this.state.error) {
      return (
        <Card centered>
          <Card.Header>Action required</Card.Header>
          <Card.Content>{this.state.error}</Card.Content>
        </Card>
      );
    }
    if (!this.state.gameStoreAddress) {
      return (
        <Card centered fluid>
          <Card.Header>Action required</Card.Header>
          <Card.Content>
            Please enter a GameStore address to proceed
          </Card.Content>
        </Card>
      );
    }
    if (!this.state.gameStoreAccount) {
      return (
        <Card centered>
          <Card.Header>Action required</Card.Header>
          <Card.Content>
            If you don't have an account, MetaMask will prompt you to register.
            Otherwise you will be logged in instantly.
          </Card.Content>
          <Card.Content>
            <Button onClick={this.createAccount}>Login</Button>
          </Card.Content>
        </Card>
      );
    }

    const myItems = this.state.items.filter(
      i => i.owner === this.state.account
    );
    const saleItems = this.state.items.filter(
      i => i.owner !== this.state.account && i.price > 0
    );

    const tab1: MenuItemProps = {
      key: "myitems",
      content: (
        <>
          My Items
          {(myItems.length && (
            <Label content={myItems.length} circular color="blue" />
          )) ||
            null}
        </>
      )
    };
    const tab2: MenuItemProps = {
      key: "forsaleitems",
      content: (
        <>
          For Sale
          {(saleItems.length && (
            <Label content={saleItems.length} circular color="red" />
          )) ||
            null}
        </>
      )
    };
    const tab3: MenuItemProps = {
      key: "all",
      content: "All Items"
    };

    const panes = [
      {
        menuItem: tab1,
        render: () => (
          <Tab.Pane>
            <GameItemList
              busy={this.state.isBusy}
              items={myItems}
              account={this.state.account || undefined}
              purchaseItem={this.purchaseItem}
              setPrice={this.setPrice}
            />
          </Tab.Pane>
        )
      },
      {
        menuItem: tab2,
        render: () => (
          <Tab.Pane>
            <GameItemList
              busy={this.state.isBusy}
              items={saleItems}
              account={this.state.account || undefined}
              purchaseItem={this.purchaseItem}
              setPrice={this.setPrice}
            />
          </Tab.Pane>
        )
      },
      {
        menuItem: tab3,
        render: () => (
          <Tab.Pane>
            <GameItemList
              busy={this.state.isBusy}
              items={this.state.items}
              account={this.state.account || undefined}
              purchaseItem={this.purchaseItem}
              setPrice={this.setPrice}
            />
          </Tab.Pane>
        )
      }
    ];

    return <Tab panes={panes} />;
  };
}
