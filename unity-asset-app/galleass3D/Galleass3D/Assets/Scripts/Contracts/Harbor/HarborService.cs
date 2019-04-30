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
using Galleass3D.Contracts.Harbor.ContractDefinition;

namespace Galleass3D.Contracts.Harbor
{
    public partial class HarborService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, HarborDeployment harborDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<HarborDeployment>().SendRequestAndWaitForReceiptAsync(harborDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, HarborDeployment harborDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<HarborDeployment>().SendRequestAsync(harborDeployment);
        }

        public static async Task<HarborService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, HarborDeployment harborDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, harborDeployment, cancellationTokenSource);
            return new HarborService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public HarborService(Nethereum.Web3.Web3 web3, string contractAddress)
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

        public Task<ushort> TIMBERTOBUILDSCHOONERQueryAsync(TIMBERTOBUILDSCHOONERFunction tIMBERTOBUILDSCHOONERFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TIMBERTOBUILDSCHOONERFunction, ushort>(tIMBERTOBUILDSCHOONERFunction, blockParameter);
        }

        
        public Task<ushort> TIMBERTOBUILDSCHOONERQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TIMBERTOBUILDSCHOONERFunction, ushort>(null, blockParameter);
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

        public Task<ushort> TIMBERTOBUILDDOGGERQueryAsync(TIMBERTOBUILDDOGGERFunction tIMBERTOBUILDDOGGERFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TIMBERTOBUILDDOGGERFunction, ushort>(tIMBERTOBUILDDOGGERFunction, blockParameter);
        }

        
        public Task<ushort> TIMBERTOBUILDDOGGERQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TIMBERTOBUILDDOGGERFunction, ushort>(null, blockParameter);
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

        public Task<BigInteger> ShipStorageQueryAsync(ShipStorageFunction shipStorageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ShipStorageFunction, BigInteger>(shipStorageFunction, blockParameter);
        }

        
        public Task<BigInteger> ShipStorageQueryAsync(ushort returnValue1, ushort returnValue2, byte returnValue3, byte[] returnValue4, BigInteger returnValue5, BlockParameter blockParameter = null)
        {
            var shipStorageFunction = new ShipStorageFunction();
                shipStorageFunction.ReturnValue1 = returnValue1;
                shipStorageFunction.ReturnValue2 = returnValue2;
                shipStorageFunction.ReturnValue3 = returnValue3;
                shipStorageFunction.ReturnValue4 = returnValue4;
                shipStorageFunction.ReturnValue5 = returnValue5;
            
            return ContractHandler.QueryAsync<ShipStorageFunction, BigInteger>(shipStorageFunction, blockParameter);
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

        public Task<BigInteger> CurrentPriceQueryAsync(CurrentPriceFunction currentPriceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CurrentPriceFunction, BigInteger>(currentPriceFunction, blockParameter);
        }

        
        public Task<BigInteger> CurrentPriceQueryAsync(ushort returnValue1, ushort returnValue2, byte returnValue3, byte[] returnValue4, BlockParameter blockParameter = null)
        {
            var currentPriceFunction = new CurrentPriceFunction();
                currentPriceFunction.ReturnValue1 = returnValue1;
                currentPriceFunction.ReturnValue2 = returnValue2;
                currentPriceFunction.ReturnValue3 = returnValue3;
                currentPriceFunction.ReturnValue4 = returnValue4;
            
            return ContractHandler.QueryAsync<CurrentPriceFunction, BigInteger>(currentPriceFunction, blockParameter);
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

        public Task<string> BuildShipRequestAsync(BuildShipFunction buildShipFunction)
        {
             return ContractHandler.SendRequestAsync(buildShipFunction);
        }

        public Task<TransactionReceipt> BuildShipRequestAndWaitForReceiptAsync(BuildShipFunction buildShipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buildShipFunction, cancellationToken);
        }

        public Task<string> BuildShipRequestAsync(ushort x, ushort y, byte tile, byte[] model)
        {
            var buildShipFunction = new BuildShipFunction();
                buildShipFunction.X = x;
                buildShipFunction.Y = y;
                buildShipFunction.Tile = tile;
                buildShipFunction.Model = model;
            
             return ContractHandler.SendRequestAsync(buildShipFunction);
        }

        public Task<TransactionReceipt> BuildShipRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, byte[] model, CancellationTokenSource cancellationToken = null)
        {
            var buildShipFunction = new BuildShipFunction();
                buildShipFunction.X = x;
                buildShipFunction.Y = y;
                buildShipFunction.Tile = tile;
                buildShipFunction.Model = model;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buildShipFunction, cancellationToken);
        }

        public Task<string> BuyShipRequestAsync(BuyShipFunction buyShipFunction)
        {
             return ContractHandler.SendRequestAsync(buyShipFunction);
        }

        public Task<TransactionReceipt> BuyShipRequestAndWaitForReceiptAsync(BuyShipFunction buyShipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyShipFunction, cancellationToken);
        }

        public Task<string> BuyShipRequestAsync(ushort x, ushort y, byte tile, byte[] model)
        {
            var buyShipFunction = new BuyShipFunction();
                buyShipFunction.X = x;
                buyShipFunction.Y = y;
                buyShipFunction.Tile = tile;
                buyShipFunction.Model = model;
            
             return ContractHandler.SendRequestAsync(buyShipFunction);
        }

        public Task<TransactionReceipt> BuyShipRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, byte[] model, CancellationTokenSource cancellationToken = null)
        {
            var buyShipFunction = new BuyShipFunction();
                buyShipFunction.X = x;
                buyShipFunction.Y = y;
                buyShipFunction.Tile = tile;
                buyShipFunction.Model = model;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyShipFunction, cancellationToken);
        }

        public Task<string> SetPriceRequestAsync(SetPriceFunction setPriceFunction)
        {
             return ContractHandler.SendRequestAsync(setPriceFunction);
        }

        public Task<TransactionReceipt> SetPriceRequestAndWaitForReceiptAsync(SetPriceFunction setPriceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceFunction, cancellationToken);
        }

        public Task<string> SetPriceRequestAsync(ushort x, ushort y, byte tile, byte[] model, BigInteger amount)
        {
            var setPriceFunction = new SetPriceFunction();
                setPriceFunction.X = x;
                setPriceFunction.Y = y;
                setPriceFunction.Tile = tile;
                setPriceFunction.Model = model;
                setPriceFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(setPriceFunction);
        }

        public Task<TransactionReceipt> SetPriceRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, byte[] model, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var setPriceFunction = new SetPriceFunction();
                setPriceFunction.X = x;
                setPriceFunction.Y = y;
                setPriceFunction.Tile = tile;
                setPriceFunction.Model = model;
                setPriceFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceFunction, cancellationToken);
        }

        public Task<BigInteger> CountShipsQueryAsync(CountShipsFunction countShipsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CountShipsFunction, BigInteger>(countShipsFunction, blockParameter);
        }

        
        public Task<BigInteger> CountShipsQueryAsync(ushort x, ushort y, byte tile, byte[] model, BlockParameter blockParameter = null)
        {
            var countShipsFunction = new CountShipsFunction();
                countShipsFunction.X = x;
                countShipsFunction.Y = y;
                countShipsFunction.Tile = tile;
                countShipsFunction.Model = model;
            
            return ContractHandler.QueryAsync<CountShipsFunction, BigInteger>(countShipsFunction, blockParameter);
        }
    }
}
