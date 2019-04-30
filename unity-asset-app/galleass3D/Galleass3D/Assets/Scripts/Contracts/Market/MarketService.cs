using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Galleass3D.Contracts.Market.ContractDefinition;

namespace Galleass3D.Contracts.Market
{
    public partial class MarketService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, MarketDeployment marketDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<MarketDeployment>().SendRequestAndWaitForReceiptAsync(marketDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, MarketDeployment marketDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<MarketDeployment>().SendRequestAsync(marketDeployment);
        }

        public static async Task<MarketService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, MarketDeployment marketDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, marketDeployment, cancellationTokenSource);
            return new MarketService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public MarketService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> GalleassQueryAsync(GalleassFunction galleassFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GalleassFunction, string>(galleassFunction, blockParameter);
        }

        
        public Task<string> GalleassQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GalleassFunction, string>(null, blockParameter);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(BigInteger amount)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<string> UpgradeGalleassRequestAsync(UpgradeGalleassFunction upgradeGalleassFunction)
        {
             return ContractHandler.SendRequestAsync(upgradeGalleassFunction);
        }

        public Task<TransactionReceipt> UpgradeGalleassRequestAndWaitForReceiptAsync(UpgradeGalleassFunction upgradeGalleassFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeGalleassFunction, cancellationToken);
        }

        public Task<string> UpgradeGalleassRequestAsync(string galleass)
        {
            var upgradeGalleassFunction = new UpgradeGalleassFunction();
                upgradeGalleassFunction.Galleass = galleass;
            
             return ContractHandler.SendRequestAsync(upgradeGalleassFunction);
        }

        public Task<TransactionReceipt> UpgradeGalleassRequestAndWaitForReceiptAsync(string galleass, CancellationTokenSource cancellationToken = null)
        {
            var upgradeGalleassFunction = new UpgradeGalleassFunction();
                upgradeGalleassFunction.Galleass = galleass;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeGalleassFunction, cancellationToken);
        }

        public Task<BigInteger> BuyPricesQueryAsync(BuyPricesFunction buyPricesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BuyPricesFunction, BigInteger>(buyPricesFunction, blockParameter);
        }

        
        public Task<BigInteger> BuyPricesQueryAsync(ushort returnValue1, ushort returnValue2, byte returnValue3, string returnValue4, BlockParameter blockParameter = null)
        {
            var buyPricesFunction = new BuyPricesFunction();
                buyPricesFunction.ReturnValue1 = returnValue1;
                buyPricesFunction.ReturnValue2 = returnValue2;
                buyPricesFunction.ReturnValue3 = returnValue3;
                buyPricesFunction.ReturnValue4 = returnValue4;
            
            return ContractHandler.QueryAsync<BuyPricesFunction, BigInteger>(buyPricesFunction, blockParameter);
        }

        public Task<BigInteger> SellPricesQueryAsync(SellPricesFunction sellPricesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SellPricesFunction, BigInteger>(sellPricesFunction, blockParameter);
        }

        
        public Task<BigInteger> SellPricesQueryAsync(ushort returnValue1, ushort returnValue2, byte returnValue3, string returnValue4, BlockParameter blockParameter = null)
        {
            var sellPricesFunction = new SellPricesFunction();
                sellPricesFunction.ReturnValue1 = returnValue1;
                sellPricesFunction.ReturnValue2 = returnValue2;
                sellPricesFunction.ReturnValue3 = returnValue3;
                sellPricesFunction.ReturnValue4 = returnValue4;
            
            return ContractHandler.QueryAsync<SellPricesFunction, BigInteger>(sellPricesFunction, blockParameter);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TokenBalanceQueryAsync(TokenBalanceFunction tokenBalanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenBalanceFunction, BigInteger>(tokenBalanceFunction, blockParameter);
        }

        
        public Task<BigInteger> TokenBalanceQueryAsync(ushort returnValue1, ushort returnValue2, byte returnValue3, string returnValue4, BlockParameter blockParameter = null)
        {
            var tokenBalanceFunction = new TokenBalanceFunction();
                tokenBalanceFunction.ReturnValue1 = returnValue1;
                tokenBalanceFunction.ReturnValue2 = returnValue2;
                tokenBalanceFunction.ReturnValue3 = returnValue3;
                tokenBalanceFunction.ReturnValue4 = returnValue4;
            
            return ContractHandler.QueryAsync<TokenBalanceFunction, BigInteger>(tokenBalanceFunction, blockParameter);
        }

        public Task<string> WithdrawTokenRequestAsync(WithdrawTokenFunction withdrawTokenFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawTokenFunction);
        }

        public Task<TransactionReceipt> WithdrawTokenRequestAndWaitForReceiptAsync(WithdrawTokenFunction withdrawTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawTokenFunction, cancellationToken);
        }

        public Task<string> WithdrawTokenRequestAsync(string token, BigInteger amount)
        {
            var withdrawTokenFunction = new WithdrawTokenFunction();
                withdrawTokenFunction.Token = token;
                withdrawTokenFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(withdrawTokenFunction);
        }

        public Task<TransactionReceipt> WithdrawTokenRequestAndWaitForReceiptAsync(string token, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var withdrawTokenFunction = new WithdrawTokenFunction();
                withdrawTokenFunction.Token = token;
                withdrawTokenFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawTokenFunction, cancellationToken);
        }

        public Task<bool> HasPermissionQueryAsync(HasPermissionFunction hasPermissionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasPermissionFunction, bool>(hasPermissionFunction, blockParameter);
        }

        
        public Task<bool> HasPermissionQueryAsync(string contract, byte[] permission, BlockParameter blockParameter = null)
        {
            var hasPermissionFunction = new HasPermissionFunction();
                hasPermissionFunction.Contract = contract;
                hasPermissionFunction.Permission = permission;
            
            return ContractHandler.QueryAsync<HasPermissionFunction, bool>(hasPermissionFunction, blockParameter);
        }

        public Task<string> LandOwnersQueryAsync(LandOwnersFunction landOwnersFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LandOwnersFunction, string>(landOwnersFunction, blockParameter);
        }

        
        public Task<string> LandOwnersQueryAsync(ushort returnValue1, ushort returnValue2, byte returnValue3, BlockParameter blockParameter = null)
        {
            var landOwnersFunction = new LandOwnersFunction();
                landOwnersFunction.ReturnValue1 = returnValue1;
                landOwnersFunction.ReturnValue2 = returnValue2;
                landOwnersFunction.ReturnValue3 = returnValue3;
            
            return ContractHandler.QueryAsync<LandOwnersFunction, string>(landOwnersFunction, blockParameter);
        }

        public Task<string> OnPurchaseRequestAsync(OnPurchaseFunction onPurchaseFunction)
        {
             return ContractHandler.SendRequestAsync(onPurchaseFunction);
        }

        public Task<TransactionReceipt> OnPurchaseRequestAndWaitForReceiptAsync(OnPurchaseFunction onPurchaseFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onPurchaseFunction, cancellationToken);
        }

        public Task<string> OnPurchaseRequestAsync(ushort x, ushort y, byte tile, string owner, BigInteger amount)
        {
            var onPurchaseFunction = new OnPurchaseFunction();
                onPurchaseFunction.X = x;
                onPurchaseFunction.Y = y;
                onPurchaseFunction.Tile = tile;
                onPurchaseFunction.Owner = owner;
                onPurchaseFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(onPurchaseFunction);
        }

        public Task<TransactionReceipt> OnPurchaseRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, string owner, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var onPurchaseFunction = new OnPurchaseFunction();
                onPurchaseFunction.X = x;
                onPurchaseFunction.Y = y;
                onPurchaseFunction.Tile = tile;
                onPurchaseFunction.Owner = owner;
                onPurchaseFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onPurchaseFunction, cancellationToken);
        }

        public Task<string> GetContractQueryAsync(GetContractFunction getContractFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContractFunction, string>(getContractFunction, blockParameter);
        }

        
        public Task<string> GetContractQueryAsync(byte[] name, BlockParameter blockParameter = null)
        {
            var getContractFunction = new GetContractFunction();
                getContractFunction.Name = name;
            
            return ContractHandler.QueryAsync<GetContractFunction, string>(getContractFunction, blockParameter);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> SetBuyPriceRequestAsync(SetBuyPriceFunction setBuyPriceFunction)
        {
             return ContractHandler.SendRequestAsync(setBuyPriceFunction);
        }

        public Task<TransactionReceipt> SetBuyPriceRequestAndWaitForReceiptAsync(SetBuyPriceFunction setBuyPriceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBuyPriceFunction, cancellationToken);
        }

        public Task<string> SetBuyPriceRequestAsync(ushort x, ushort y, byte tile, string token, BigInteger price)
        {
            var setBuyPriceFunction = new SetBuyPriceFunction();
                setBuyPriceFunction.X = x;
                setBuyPriceFunction.Y = y;
                setBuyPriceFunction.Tile = tile;
                setBuyPriceFunction.Token = token;
                setBuyPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAsync(setBuyPriceFunction);
        }

        public Task<TransactionReceipt> SetBuyPriceRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, string token, BigInteger price, CancellationTokenSource cancellationToken = null)
        {
            var setBuyPriceFunction = new SetBuyPriceFunction();
                setBuyPriceFunction.X = x;
                setBuyPriceFunction.Y = y;
                setBuyPriceFunction.Tile = tile;
                setBuyPriceFunction.Token = token;
                setBuyPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setBuyPriceFunction, cancellationToken);
        }

        public Task<string> SetSellPriceRequestAsync(SetSellPriceFunction setSellPriceFunction)
        {
             return ContractHandler.SendRequestAsync(setSellPriceFunction);
        }

        public Task<TransactionReceipt> SetSellPriceRequestAndWaitForReceiptAsync(SetSellPriceFunction setSellPriceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSellPriceFunction, cancellationToken);
        }

        public Task<string> SetSellPriceRequestAsync(ushort x, ushort y, byte tile, string token, BigInteger price)
        {
            var setSellPriceFunction = new SetSellPriceFunction();
                setSellPriceFunction.X = x;
                setSellPriceFunction.Y = y;
                setSellPriceFunction.Tile = tile;
                setSellPriceFunction.Token = token;
                setSellPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAsync(setSellPriceFunction);
        }

        public Task<TransactionReceipt> SetSellPriceRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, string token, BigInteger price, CancellationTokenSource cancellationToken = null)
        {
            var setSellPriceFunction = new SetSellPriceFunction();
                setSellPriceFunction.X = x;
                setSellPriceFunction.Y = y;
                setSellPriceFunction.Tile = tile;
                setSellPriceFunction.Token = token;
                setSellPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSellPriceFunction, cancellationToken);
        }

        public Task<string> OnTokenTransferRequestAsync(OnTokenTransferFunction onTokenTransferFunction)
        {
             return ContractHandler.SendRequestAsync(onTokenTransferFunction);
        }

        public Task<TransactionReceipt> OnTokenTransferRequestAndWaitForReceiptAsync(OnTokenTransferFunction onTokenTransferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onTokenTransferFunction, cancellationToken);
        }

        public Task<string> OnTokenTransferRequestAsync(string sender, BigInteger amount, byte[] data)
        {
            var onTokenTransferFunction = new OnTokenTransferFunction();
                onTokenTransferFunction.Sender = sender;
                onTokenTransferFunction.Amount = amount;
                onTokenTransferFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(onTokenTransferFunction);
        }

        public Task<TransactionReceipt> OnTokenTransferRequestAndWaitForReceiptAsync(string sender, BigInteger amount, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var onTokenTransferFunction = new OnTokenTransferFunction();
                onTokenTransferFunction.Sender = sender;
                onTokenTransferFunction.Amount = amount;
                onTokenTransferFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onTokenTransferFunction, cancellationToken);
        }
    }
}
