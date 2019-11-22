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
using Galleass3D.Contracts.Fishmonger.ContractDefinition;

namespace Galleass3D.Contracts.Fishmonger
{
    public partial class FishmongerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, FishmongerDeployment fishmongerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<FishmongerDeployment>().SendRequestAndWaitForReceiptAsync(fishmongerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, FishmongerDeployment fishmongerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<FishmongerDeployment>().SendRequestAsync(fishmongerDeployment);
        }

        public static async Task<FishmongerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, FishmongerDeployment fishmongerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, fishmongerDeployment, cancellationTokenSource);
            return new FishmongerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public FishmongerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> FilletPriceQueryAsync(FilletPriceFunction filletPriceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FilletPriceFunction, BigInteger>(filletPriceFunction, blockParameter);
        }

        
        public Task<BigInteger> FilletPriceQueryAsync(ushort returnValue1, ushort returnValue2, byte returnValue3, BlockParameter blockParameter = null)
        {
            var filletPriceFunction = new FilletPriceFunction();
                filletPriceFunction.ReturnValue1 = returnValue1;
                filletPriceFunction.ReturnValue2 = returnValue2;
                filletPriceFunction.ReturnValue3 = returnValue3;
            
            return ContractHandler.QueryAsync<FilletPriceFunction, BigInteger>(filletPriceFunction, blockParameter);
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

        public Task<byte> FILLETSPERFISHQueryAsync(FILLETSPERFISHFunction fILLETSPERFISHFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FILLETSPERFISHFunction, byte>(fILLETSPERFISHFunction, blockParameter);
        }

        
        public Task<byte> FILLETSPERFISHQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FILLETSPERFISHFunction, byte>(null, blockParameter);
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

        public Task<BigInteger> PriceQueryAsync(PriceFunction priceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceFunction, BigInteger>(priceFunction, blockParameter);
        }

        
        public Task<BigInteger> PriceQueryAsync(ushort returnValue1, ushort returnValue2, byte returnValue3, string returnValue4, BlockParameter blockParameter = null)
        {
            var priceFunction = new PriceFunction();
                priceFunction.ReturnValue1 = returnValue1;
                priceFunction.ReturnValue2 = returnValue2;
                priceFunction.ReturnValue3 = returnValue3;
                priceFunction.ReturnValue4 = returnValue4;
            
            return ContractHandler.QueryAsync<PriceFunction, BigInteger>(priceFunction, blockParameter);
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

        public Task<string> SetPriceRequestAsync(SetPriceFunction setPriceFunction)
        {
             return ContractHandler.SendRequestAsync(setPriceFunction);
        }

        public Task<TransactionReceipt> SetPriceRequestAndWaitForReceiptAsync(SetPriceFunction setPriceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceFunction, cancellationToken);
        }

        public Task<string> SetPriceRequestAsync(ushort x, ushort y, byte tile, string species, BigInteger price)
        {
            var setPriceFunction = new SetPriceFunction();
                setPriceFunction.X = x;
                setPriceFunction.Y = y;
                setPriceFunction.Tile = tile;
                setPriceFunction.Species = species;
                setPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAsync(setPriceFunction);
        }

        public Task<TransactionReceipt> SetPriceRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, string species, BigInteger price, CancellationTokenSource cancellationToken = null)
        {
            var setPriceFunction = new SetPriceFunction();
                setPriceFunction.X = x;
                setPriceFunction.Y = y;
                setPriceFunction.Tile = tile;
                setPriceFunction.Species = species;
                setPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceFunction, cancellationToken);
        }

        public Task<string> SetFilletPriceRequestAsync(SetFilletPriceFunction setFilletPriceFunction)
        {
             return ContractHandler.SendRequestAsync(setFilletPriceFunction);
        }

        public Task<TransactionReceipt> SetFilletPriceRequestAndWaitForReceiptAsync(SetFilletPriceFunction setFilletPriceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFilletPriceFunction, cancellationToken);
        }

        public Task<string> SetFilletPriceRequestAsync(ushort x, ushort y, byte tile, BigInteger price)
        {
            var setFilletPriceFunction = new SetFilletPriceFunction();
                setFilletPriceFunction.X = x;
                setFilletPriceFunction.Y = y;
                setFilletPriceFunction.Tile = tile;
                setFilletPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAsync(setFilletPriceFunction);
        }

        public Task<TransactionReceipt> SetFilletPriceRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, BigInteger price, CancellationTokenSource cancellationToken = null)
        {
            var setFilletPriceFunction = new SetFilletPriceFunction();
                setFilletPriceFunction.X = x;
                setFilletPriceFunction.Y = y;
                setFilletPriceFunction.Tile = tile;
                setFilletPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFilletPriceFunction, cancellationToken);
        }

        public Task<string> SellFishRequestAsync(SellFishFunction sellFishFunction)
        {
             return ContractHandler.SendRequestAsync(sellFishFunction);
        }

        public Task<TransactionReceipt> SellFishRequestAndWaitForReceiptAsync(SellFishFunction sellFishFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sellFishFunction, cancellationToken);
        }

        public Task<string> SellFishRequestAsync(ushort x, ushort y, byte tile, string species, BigInteger amount)
        {
            var sellFishFunction = new SellFishFunction();
                sellFishFunction.X = x;
                sellFishFunction.Y = y;
                sellFishFunction.Tile = tile;
                sellFishFunction.Species = species;
                sellFishFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(sellFishFunction);
        }

        public Task<TransactionReceipt> SellFishRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, string species, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var sellFishFunction = new SellFishFunction();
                sellFishFunction.X = x;
                sellFishFunction.Y = y;
                sellFishFunction.Tile = tile;
                sellFishFunction.Species = species;
                sellFishFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sellFishFunction, cancellationToken);
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
