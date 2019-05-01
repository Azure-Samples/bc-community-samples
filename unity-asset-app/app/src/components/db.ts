import Web3 from "web3";
import { Eth } from "web3-eth";
import { Web3EthereumProvider, CustomProvider } from "web3-providers";

import GameStoreContract from "../contracts/GameStore.json";
import GameItemContract from "../contracts/GameItem.json";
import { IGameItem, IGameStoreAccount } from "../models/IGameItem";
import { AbiItem, hexToNumber, toBN } from "web3-utils";
import { ItemCategories } from "./data";

export async function getBalance() {
  const eth: Eth = await getWeb3();
  const balance = await eth.getBalance(await getAccount());
  return balance;
}

export async function getGameStoreItems(gameStoreAddress: string) {
  const eth: Eth = await getWeb3();
  const gameStore = await new eth.Contract(
    (GameStoreContract.abi as unknown) as AbiItem,
    gameStoreAddress
  );
  const itemAddresses: string[] = await gameStore.methods.GetAllItems().call();
  if (itemAddresses == null) {
    throw new Error("Invalid GameStore connection");
  }
  return itemAddresses;
}

export async function getGameStoreItem(gameItemAddress: string) {
  const eth: Eth = await getWeb3();
  const contract = await new eth.Contract(
    (GameItemContract.abi as unknown) as AbiItem,
    gameItemAddress
  );
  const props: IGameItem = await contract.methods.GetProps().call();
  props.price = hexToNumber(props.price);
  const category = ItemCategories.get(props.itemKey);
  if (!category) {
    throw new Error("An item exists with an unknown category. Nuke 'em");
  }
  return {
    busy: false,
    contract,
    category,
    ...props
  };
}

export async function updateGameStoreItemPrice(item: IGameItem, price: number) {
  const eth: Eth = await getWeb3();
  const contract = item.contract;
  if (!contract) {
    throw new Error("Item must be loaded from the GameStore");
  }

  const from = await getAccount();
  const gas = 3000000;

  const confirmation = await new Promise<string>(async (resolve, reject) => {
    try {
      console.log("updating gamestore item ", price);
      await contract.methods
        .SetPrice(price)
        .send({ from, gas })
        .on("transactionHash", (hash: string) => {
          console.log(hash);
        })
        .on("receipt", (receipt: string) => {
          console.log("receipt", receipt);
        })
        .on("confirmation", (confirmationNumber: string) => {
          console.log("confirmation", confirmationNumber);
          resolve(confirmationNumber);
        })
        .on("error", (e: Error) => {
          console.error(e);
          throw e;
        });
    } catch (ex) {
      reject(ex);
    }
  });

  return confirmation;
}

export async function purchaseGameStoreItem(item: IGameItem) {
  if (!item.contract) {
    throw new Error("Item must be loaded from the GameStore");
  }

  const eth: Eth = await getWeb3();
  const gameStore = await new eth.Contract(
    (GameStoreContract.abi as unknown) as AbiItem,
    item.game
  );
  const from = await getAccount();
  const value = toBN(item.price);
  const gas = 3000000;

  const confirmation = await new Promise<string>(async (resolve, reject) => {
    try {
      await gameStore.methods
        .PurchaseItem(item.contract.address)
        .send({ gas, value, from })
        .on("transactionHash", (hash: string) => {
          console.log(hash);
        })
        .on("receipt", (receipt: string) => {
          console.log("receipt", receipt);
        })
        .on("confirmation", (confirmationNumber: string) => {
          console.log("confirmation", confirmationNumber);
          resolve(confirmationNumber);
        })
        .on("error", (e: Error) => {
          console.error(e);
          reject(e);
        });
    } catch (ex) {
      reject(ex);
    }
  });

  return confirmation;
}

export async function registerGameStoreAccount(
  gameStoreAddress: string,
  newAccountAddress: string
) {
  const eth: Eth = await getWeb3();
  const contract = await new eth.Contract(
    (GameStoreContract.abi as unknown) as AbiItem,
    gameStoreAddress
  );
  const from = await getAccount();
  const gas = 3000000;

  const confirmation = await new Promise<string>(async (resolve, reject) => {
    try {
      await contract.methods
        .RegisterAccount(newAccountAddress)
        .send({ from, gas })
        .on("transactionHash", (hash: string) => {
          console.log(hash);
        })
        .on("receipt", (receipt: string) => {
          console.log("receipt", receipt);
        })
        .on("confirmation", (confirmationNumber: string) => {
          console.log("confirmation", confirmationNumber);
          resolve(confirmationNumber);
        })
        .on("error", (e: Error) => {
          console.error(e);
          throw e;
        });
    } catch (ex) {
      reject(ex);
    }
  });

  return confirmation;
}

export async function getGameStoreAccount(gameStoreAddress: string) {
  const eth: Eth = await getWeb3();
  const account = await getAccount();
  const contract = await new eth.Contract(
    (GameStoreContract.abi as unknown) as AbiItem,
    gameStoreAddress
  );
  let gameStoreAccount: IGameStoreAccount = await contract.methods
    .GetAccount(account)
    .call();

  if (!gameStoreAccount.exists) {
    await registerGameStoreAccount(gameStoreAddress, account);
    //try one more time
    gameStoreAccount = await contract.methods.GetAccount(account).call();
  }

  if (!gameStoreAccount.exists) {
    throw new Error("Failed to register game store account");
  }
  gameStoreAccount.address = account;
  gameStoreAccount.balance = hexToNumber(gameStoreAccount.balance);
  gameStoreAccount.totalSold = hexToNumber(gameStoreAccount.totalSold);
  return gameStoreAccount;
}

export async function getAccount() {
  const eth: Eth = await getWeb3();
  const accounts = await eth.getAccounts();
  if (accounts.length > 0) {
    return accounts[0];
  }
  throw new Error("MetaMask account is locked or not found");
}

export async function getWeb3() {
  const web3: Web3 = (window as any).web3;
  const ethereum: CustomProvider & {
    enable: () => Promise<boolean>;
  } = (window as any).ethereum;
  if (ethereum) {
    await ethereum.enable();
    return new Web3(ethereum).eth;
  }
  console.log("MetaMask is not installed");
  throw new Error("MetaMask is not installed or not configured");
}
