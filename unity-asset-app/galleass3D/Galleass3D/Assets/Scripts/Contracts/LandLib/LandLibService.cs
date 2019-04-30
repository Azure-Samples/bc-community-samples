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
using Galleass3D.Contracts.LandLib.ContractDefinition;

namespace Galleass3D.Contracts.LandLib
{
    public partial class LandLibService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, LandLibDeployment landLibDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandLibDeployment>().SendRequestAndWaitForReceiptAsync(landLibDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, LandLibDeployment landLibDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandLibDeployment>().SendRequestAsync(landLibDeployment);
        }

        public static async Task<LandLibService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, LandLibDeployment landLibDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landLibDeployment, cancellationTokenSource);
            return new LandLibService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public LandLibService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<ushort> TileTypesQueryAsync(TileTypesFunction tileTypesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TileTypesFunction, ushort>(tileTypesFunction, blockParameter);
        }

        
        public Task<ushort> TileTypesQueryAsync(byte[] returnValue1, BlockParameter blockParameter = null)
        {
            var tileTypesFunction = new TileTypesFunction();
                tileTypesFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<TileTypesFunction, ushort>(tileTypesFunction, blockParameter);
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

        public Task<BigInteger> OPENLANDTILECOSTQueryAsync(OPENLANDTILECOSTFunction oPENLANDTILECOSTFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OPENLANDTILECOSTFunction, BigInteger>(oPENLANDTILECOSTFunction, blockParameter);
        }

        
        public Task<BigInteger> OPENLANDTILECOSTQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OPENLANDTILECOSTFunction, BigInteger>(null, blockParameter);
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

        public Task<BigInteger> NonceQueryAsync(NonceFunction nonceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NonceFunction, BigInteger>(nonceFunction, blockParameter);
        }

        
        public Task<BigInteger> NonceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NonceFunction, BigInteger>(null, blockParameter);
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

        public Task<string> SetTileTypeRequestAsync(SetTileTypeFunction setTileTypeFunction)
        {
             return ContractHandler.SendRequestAsync(setTileTypeFunction);
        }

        public Task<TransactionReceipt> SetTileTypeRequestAndWaitForReceiptAsync(SetTileTypeFunction setTileTypeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTileTypeFunction, cancellationToken);
        }

        public Task<string> SetTileTypeRequestAsync(ushort tile, byte[] name)
        {
            var setTileTypeFunction = new SetTileTypeFunction();
                setTileTypeFunction.Tile = tile;
                setTileTypeFunction.Name = name;
            
             return ContractHandler.SendRequestAsync(setTileTypeFunction);
        }

        public Task<TransactionReceipt> SetTileTypeRequestAndWaitForReceiptAsync(ushort tile, byte[] name, CancellationTokenSource cancellationToken = null)
        {
            var setTileTypeFunction = new SetTileTypeFunction();
                setTileTypeFunction.Tile = tile;
                setTileTypeFunction.Name = name;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTileTypeFunction, cancellationToken);
        }

        public Task<string> GenerateLandRequestAsync(GenerateLandFunction generateLandFunction)
        {
             return ContractHandler.SendRequestAsync(generateLandFunction);
        }

        public Task<string> GenerateLandRequestAsync()
        {
             return ContractHandler.SendRequestAsync<GenerateLandFunction>();
        }

        public Task<TransactionReceipt> GenerateLandRequestAndWaitForReceiptAsync(GenerateLandFunction generateLandFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(generateLandFunction, cancellationToken);
        }

        public Task<TransactionReceipt> GenerateLandRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<GenerateLandFunction>(null, cancellationToken);
        }

        public Task<string> SetTilesAndOwnersRequestAsync(SetTilesAndOwnersFunction setTilesAndOwnersFunction)
        {
             return ContractHandler.SendRequestAsync(setTilesAndOwnersFunction);
        }

        public Task<TransactionReceipt> SetTilesAndOwnersRequestAndWaitForReceiptAsync(SetTilesAndOwnersFunction setTilesAndOwnersFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTilesAndOwnersFunction, cancellationToken);
        }

        public Task<string> SetTilesAndOwnersRequestAsync(ushort x, ushort y, string landContract, byte[] landParts1, byte[] landParts2)
        {
            var setTilesAndOwnersFunction = new SetTilesAndOwnersFunction();
                setTilesAndOwnersFunction.X = x;
                setTilesAndOwnersFunction.Y = y;
                setTilesAndOwnersFunction.LandContract = landContract;
                setTilesAndOwnersFunction.LandParts1 = landParts1;
                setTilesAndOwnersFunction.LandParts2 = landParts2;
            
             return ContractHandler.SendRequestAsync(setTilesAndOwnersFunction);
        }

        public Task<TransactionReceipt> SetTilesAndOwnersRequestAndWaitForReceiptAsync(ushort x, ushort y, string landContract, byte[] landParts1, byte[] landParts2, CancellationTokenSource cancellationToken = null)
        {
            var setTilesAndOwnersFunction = new SetTilesAndOwnersFunction();
                setTilesAndOwnersFunction.X = x;
                setTilesAndOwnersFunction.Y = y;
                setTilesAndOwnersFunction.LandContract = landContract;
                setTilesAndOwnersFunction.LandParts1 = landParts1;
                setTilesAndOwnersFunction.LandParts2 = landParts2;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTilesAndOwnersFunction, cancellationToken);
        }

        public Task<ushort> GetTotalWidthQueryAsync(GetTotalWidthFunction getTotalWidthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTotalWidthFunction, ushort>(getTotalWidthFunction, blockParameter);
        }

        
        public Task<ushort> GetTotalWidthQueryAsync(ushort x, ushort y, BlockParameter blockParameter = null)
        {
            var getTotalWidthFunction = new GetTotalWidthFunction();
                getTotalWidthFunction.X = x;
                getTotalWidthFunction.Y = y;
            
            return ContractHandler.QueryAsync<GetTotalWidthFunction, ushort>(getTotalWidthFunction, blockParameter);
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

        public Task<string> BuildTileRequestAsync(BuildTileFunction buildTileFunction)
        {
             return ContractHandler.SendRequestAsync(buildTileFunction);
        }

        public Task<TransactionReceipt> BuildTileRequestAndWaitForReceiptAsync(BuildTileFunction buildTileFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buildTileFunction, cancellationToken);
        }

        public Task<string> BuildTileRequestAsync(ushort x, ushort y, byte tile, ushort newTileType)
        {
            var buildTileFunction = new BuildTileFunction();
                buildTileFunction.X = x;
                buildTileFunction.Y = y;
                buildTileFunction.Tile = tile;
                buildTileFunction.NewTileType = newTileType;
            
             return ContractHandler.SendRequestAsync(buildTileFunction);
        }

        public Task<TransactionReceipt> BuildTileRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, ushort newTileType, CancellationTokenSource cancellationToken = null)
        {
            var buildTileFunction = new BuildTileFunction();
                buildTileFunction.X = x;
                buildTileFunction.Y = y;
                buildTileFunction.Tile = tile;
                buildTileFunction.NewTileType = newTileType;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buildTileFunction, cancellationToken);
        }

        public Task<ushort> TranslateTileToWidthQueryAsync(TranslateTileToWidthFunction translateTileToWidthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TranslateTileToWidthFunction, ushort>(translateTileToWidthFunction, blockParameter);
        }

        
        public Task<ushort> TranslateTileToWidthQueryAsync(ushort tileType, BlockParameter blockParameter = null)
        {
            var translateTileToWidthFunction = new TranslateTileToWidthFunction();
                translateTileToWidthFunction.TileType = tileType;
            
            return ContractHandler.QueryAsync<TranslateTileToWidthFunction, ushort>(translateTileToWidthFunction, blockParameter);
        }

        public Task<ushort> TranslateToStartingTileQueryAsync(TranslateToStartingTileFunction translateToStartingTileFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TranslateToStartingTileFunction, ushort>(translateToStartingTileFunction, blockParameter);
        }

        
        public Task<ushort> TranslateToStartingTileQueryAsync(ushort tilepart, BlockParameter blockParameter = null)
        {
            var translateToStartingTileFunction = new TranslateToStartingTileFunction();
                translateToStartingTileFunction.Tilepart = tilepart;
            
            return ContractHandler.QueryAsync<TranslateToStartingTileFunction, ushort>(translateToStartingTileFunction, blockParameter);
        }
    }
}
