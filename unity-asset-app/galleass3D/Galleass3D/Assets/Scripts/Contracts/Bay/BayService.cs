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
using Galleass3D.Contracts.Bay.ContractDefinition;

namespace Galleass3D.Contracts.Bay
{
    public partial class BayService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BayDeployment bayDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BayDeployment>().SendRequestAndWaitForReceiptAsync(bayDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BayDeployment bayDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BayDeployment>().SendRequestAsync(bayDeployment);
        }

        public static async Task<BayService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BayDeployment bayDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, bayDeployment, cancellationTokenSource);
            return new BayService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public BayService(Nethereum.Web3.Web3 web3, string contractAddress)
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

        public Task<ushort> DepthQueryAsync(DepthFunction depthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DepthFunction, ushort>(depthFunction, blockParameter);
        }

        
        public Task<ushort> DepthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DepthFunction, ushort>(null, blockParameter);
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

        public Task<bool> SpeciesQueryAsync(SpeciesFunction speciesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SpeciesFunction, bool>(speciesFunction, blockParameter);
        }

        
        public Task<bool> SpeciesQueryAsync(ushort returnValue1, ushort returnValue2, string returnValue3, BlockParameter blockParameter = null)
        {
            var speciesFunction = new SpeciesFunction();
                speciesFunction.ReturnValue1 = returnValue1;
                speciesFunction.ReturnValue2 = returnValue2;
                speciesFunction.ReturnValue3 = returnValue3;
            
            return ContractHandler.QueryAsync<SpeciesFunction, bool>(speciesFunction, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<ShipsOutputDTO> ShipsQueryAsync(ShipsFunction shipsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ShipsFunction, ShipsOutputDTO>(shipsFunction, blockParameter);
        }

        public Task<ShipsOutputDTO> ShipsQueryAsync(ushort returnValue1, ushort returnValue2, string returnValue3, BlockParameter blockParameter = null)
        {
            var shipsFunction = new ShipsFunction();
                shipsFunction.ReturnValue1 = returnValue1;
                shipsFunction.ReturnValue2 = returnValue2;
                shipsFunction.ReturnValue3 = returnValue3;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ShipsFunction, ShipsOutputDTO>(shipsFunction, blockParameter);
        }

        public Task<string> FishQueryAsync(FishFunction fishFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FishFunction, string>(fishFunction, blockParameter);
        }

        
        public Task<string> FishQueryAsync(ushort returnValue1, ushort returnValue2, byte[] returnValue3, BlockParameter blockParameter = null)
        {
            var fishFunction = new FishFunction();
                fishFunction.ReturnValue1 = returnValue1;
                fishFunction.ReturnValue2 = returnValue2;
                fishFunction.ReturnValue3 = returnValue3;
            
            return ContractHandler.QueryAsync<FishFunction, string>(fishFunction, blockParameter);
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

        public Task<ushort> WidthQueryAsync(WidthFunction widthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WidthFunction, ushort>(widthFunction, blockParameter);
        }

        
        public Task<ushort> WidthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WidthFunction, ushort>(null, blockParameter);
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

        public Task<BigInteger> ShipSpeedQueryAsync(ShipSpeedFunction shipSpeedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ShipSpeedFunction, BigInteger>(shipSpeedFunction, blockParameter);
        }

        
        public Task<BigInteger> ShipSpeedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ShipSpeedFunction, BigInteger>(null, blockParameter);
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

        public Task<string> AllowSpeciesRequestAsync(AllowSpeciesFunction allowSpeciesFunction)
        {
             return ContractHandler.SendRequestAsync(allowSpeciesFunction);
        }

        public Task<TransactionReceipt> AllowSpeciesRequestAndWaitForReceiptAsync(AllowSpeciesFunction allowSpeciesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(allowSpeciesFunction, cancellationToken);
        }

        public Task<string> AllowSpeciesRequestAsync(ushort x, ushort y, string species)
        {
            var allowSpeciesFunction = new AllowSpeciesFunction();
                allowSpeciesFunction.X = x;
                allowSpeciesFunction.Y = y;
                allowSpeciesFunction.Species = species;
            
             return ContractHandler.SendRequestAsync(allowSpeciesFunction);
        }

        public Task<TransactionReceipt> AllowSpeciesRequestAndWaitForReceiptAsync(ushort x, ushort y, string species, CancellationTokenSource cancellationToken = null)
        {
            var allowSpeciesFunction = new AllowSpeciesFunction();
                allowSpeciesFunction.X = x;
                allowSpeciesFunction.Y = y;
                allowSpeciesFunction.Species = species;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(allowSpeciesFunction, cancellationToken);
        }

        public Task<string> StockRequestAsync(StockFunction stockFunction)
        {
             return ContractHandler.SendRequestAsync(stockFunction);
        }

        public Task<TransactionReceipt> StockRequestAndWaitForReceiptAsync(StockFunction stockFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stockFunction, cancellationToken);
        }

        public Task<string> StockRequestAsync(ushort x, ushort y, string species, BigInteger amount)
        {
            var stockFunction = new StockFunction();
                stockFunction.X = x;
                stockFunction.Y = y;
                stockFunction.Species = species;
                stockFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(stockFunction);
        }

        public Task<TransactionReceipt> StockRequestAndWaitForReceiptAsync(ushort x, ushort y, string species, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var stockFunction = new StockFunction();
                stockFunction.X = x;
                stockFunction.Y = y;
                stockFunction.Species = species;
                stockFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stockFunction, cancellationToken);
        }

        public Task<string> EmbarkRequestAsync(EmbarkFunction embarkFunction)
        {
             return ContractHandler.SendRequestAsync(embarkFunction);
        }

        public Task<TransactionReceipt> EmbarkRequestAndWaitForReceiptAsync(EmbarkFunction embarkFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(embarkFunction, cancellationToken);
        }

        public Task<string> EmbarkRequestAsync(ushort x, ushort y, BigInteger shipId)
        {
            var embarkFunction = new EmbarkFunction();
                embarkFunction.X = x;
                embarkFunction.Y = y;
                embarkFunction.ShipId = shipId;
            
             return ContractHandler.SendRequestAsync(embarkFunction);
        }

        public Task<TransactionReceipt> EmbarkRequestAndWaitForReceiptAsync(ushort x, ushort y, BigInteger shipId, CancellationTokenSource cancellationToken = null)
        {
            var embarkFunction = new EmbarkFunction();
                embarkFunction.X = x;
                embarkFunction.Y = y;
                embarkFunction.ShipId = shipId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(embarkFunction, cancellationToken);
        }

        public Task<string> DisembarkRequestAsync(DisembarkFunction disembarkFunction)
        {
             return ContractHandler.SendRequestAsync(disembarkFunction);
        }

        public Task<TransactionReceipt> DisembarkRequestAndWaitForReceiptAsync(DisembarkFunction disembarkFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(disembarkFunction, cancellationToken);
        }

        public Task<string> DisembarkRequestAsync(ushort x, ushort y, BigInteger shipId)
        {
            var disembarkFunction = new DisembarkFunction();
                disembarkFunction.X = x;
                disembarkFunction.Y = y;
                disembarkFunction.ShipId = shipId;
            
             return ContractHandler.SendRequestAsync(disembarkFunction);
        }

        public Task<TransactionReceipt> DisembarkRequestAndWaitForReceiptAsync(ushort x, ushort y, BigInteger shipId, CancellationTokenSource cancellationToken = null)
        {
            var disembarkFunction = new DisembarkFunction();
                disembarkFunction.X = x;
                disembarkFunction.Y = y;
                disembarkFunction.ShipId = shipId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(disembarkFunction, cancellationToken);
        }

        public Task<string> SetSailRequestAsync(SetSailFunction setSailFunction)
        {
             return ContractHandler.SendRequestAsync(setSailFunction);
        }

        public Task<TransactionReceipt> SetSailRequestAndWaitForReceiptAsync(SetSailFunction setSailFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSailFunction, cancellationToken);
        }

        public Task<string> SetSailRequestAsync(ushort x, ushort y, bool direction)
        {
            var setSailFunction = new SetSailFunction();
                setSailFunction.X = x;
                setSailFunction.Y = y;
                setSailFunction.Direction = direction;
            
             return ContractHandler.SendRequestAsync(setSailFunction);
        }

        public Task<TransactionReceipt> SetSailRequestAndWaitForReceiptAsync(ushort x, ushort y, bool direction, CancellationTokenSource cancellationToken = null)
        {
            var setSailFunction = new SetSailFunction();
                setSailFunction.X = x;
                setSailFunction.Y = y;
                setSailFunction.Direction = direction;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSailFunction, cancellationToken);
        }

        public Task<string> DropAnchorRequestAsync(DropAnchorFunction dropAnchorFunction)
        {
             return ContractHandler.SendRequestAsync(dropAnchorFunction);
        }

        public Task<TransactionReceipt> DropAnchorRequestAndWaitForReceiptAsync(DropAnchorFunction dropAnchorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(dropAnchorFunction, cancellationToken);
        }

        public Task<string> DropAnchorRequestAsync(ushort x, ushort y)
        {
            var dropAnchorFunction = new DropAnchorFunction();
                dropAnchorFunction.X = x;
                dropAnchorFunction.Y = y;
            
             return ContractHandler.SendRequestAsync(dropAnchorFunction);
        }

        public Task<TransactionReceipt> DropAnchorRequestAndWaitForReceiptAsync(ushort x, ushort y, CancellationTokenSource cancellationToken = null)
        {
            var dropAnchorFunction = new DropAnchorFunction();
                dropAnchorFunction.X = x;
                dropAnchorFunction.Y = y;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(dropAnchorFunction, cancellationToken);
        }

        public Task<string> CastLineRequestAsync(CastLineFunction castLineFunction)
        {
             return ContractHandler.SendRequestAsync(castLineFunction);
        }

        public Task<TransactionReceipt> CastLineRequestAndWaitForReceiptAsync(CastLineFunction castLineFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(castLineFunction, cancellationToken);
        }

        public Task<string> CastLineRequestAsync(ushort x, ushort y, byte[] baitHash)
        {
            var castLineFunction = new CastLineFunction();
                castLineFunction.X = x;
                castLineFunction.Y = y;
                castLineFunction.BaitHash = baitHash;
            
             return ContractHandler.SendRequestAsync(castLineFunction);
        }

        public Task<TransactionReceipt> CastLineRequestAndWaitForReceiptAsync(ushort x, ushort y, byte[] baitHash, CancellationTokenSource cancellationToken = null)
        {
            var castLineFunction = new CastLineFunction();
                castLineFunction.X = x;
                castLineFunction.Y = y;
                castLineFunction.BaitHash = baitHash;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(castLineFunction, cancellationToken);
        }

        public Task<string> ReelInRequestAsync(ReelInFunction reelInFunction)
        {
             return ContractHandler.SendRequestAsync(reelInFunction);
        }

        public Task<TransactionReceipt> ReelInRequestAndWaitForReceiptAsync(ReelInFunction reelInFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reelInFunction, cancellationToken);
        }

        public Task<string> ReelInRequestAsync(ushort x, ushort y, byte[] fish, byte[] bait)
        {
            var reelInFunction = new ReelInFunction();
                reelInFunction.X = x;
                reelInFunction.Y = y;
                reelInFunction.Fish = fish;
                reelInFunction.Bait = bait;
            
             return ContractHandler.SendRequestAsync(reelInFunction);
        }

        public Task<TransactionReceipt> ReelInRequestAndWaitForReceiptAsync(ushort x, ushort y, byte[] fish, byte[] bait, CancellationTokenSource cancellationToken = null)
        {
            var reelInFunction = new ReelInFunction();
                reelInFunction.X = x;
                reelInFunction.Y = y;
                reelInFunction.Fish = fish;
                reelInFunction.Bait = bait;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(reelInFunction, cancellationToken);
        }

        public Task<GetShipOutputDTO> GetShipQueryAsync(GetShipFunction getShipFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetShipFunction, GetShipOutputDTO>(getShipFunction, blockParameter);
        }

        public Task<GetShipOutputDTO> GetShipQueryAsync(ushort x, ushort y, string address, BlockParameter blockParameter = null)
        {
            var getShipFunction = new GetShipFunction();
                getShipFunction.X = x;
                getShipFunction.Y = y;
                getShipFunction.Address = address;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetShipFunction, GetShipOutputDTO>(getShipFunction, blockParameter);
        }

        public Task<FishLocationOutputDTO> FishLocationQueryAsync(FishLocationFunction fishLocationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<FishLocationFunction, FishLocationOutputDTO>(fishLocationFunction, blockParameter);
        }

        public Task<FishLocationOutputDTO> FishLocationQueryAsync(byte[] id, BlockParameter blockParameter = null)
        {
            var fishLocationFunction = new FishLocationFunction();
                fishLocationFunction.Id = id;
            
            return ContractHandler.QueryDeserializingToObjectAsync<FishLocationFunction, FishLocationOutputDTO>(fishLocationFunction, blockParameter);
        }

        public Task<ushort> ShipLocationQueryAsync(ShipLocationFunction shipLocationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ShipLocationFunction, ushort>(shipLocationFunction, blockParameter);
        }

        
        public Task<ushort> ShipLocationQueryAsync(ushort x, ushort y, string owner, BlockParameter blockParameter = null)
        {
            var shipLocationFunction = new ShipLocationFunction();
                shipLocationFunction.X = x;
                shipLocationFunction.Y = y;
                shipLocationFunction.Owner = owner;
            
            return ContractHandler.QueryAsync<ShipLocationFunction, ushort>(shipLocationFunction, blockParameter);
        }

        public Task<bool> InRangeToDisembarkQueryAsync(InRangeToDisembarkFunction inRangeToDisembarkFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<InRangeToDisembarkFunction, bool>(inRangeToDisembarkFunction, blockParameter);
        }

        
        public Task<bool> InRangeToDisembarkQueryAsync(ushort x, ushort y, string account, BlockParameter blockParameter = null)
        {
            var inRangeToDisembarkFunction = new InRangeToDisembarkFunction();
                inRangeToDisembarkFunction.X = x;
                inRangeToDisembarkFunction.Y = y;
                inRangeToDisembarkFunction.Account = account;
            
            return ContractHandler.QueryAsync<InRangeToDisembarkFunction, bool>(inRangeToDisembarkFunction, blockParameter);
        }

        public Task<ushort> GetHarborLocationQueryAsync(GetHarborLocationFunction getHarborLocationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetHarborLocationFunction, ushort>(getHarborLocationFunction, blockParameter);
        }

        
        public Task<ushort> GetHarborLocationQueryAsync(ushort x, ushort y, BlockParameter blockParameter = null)
        {
            var getHarborLocationFunction = new GetHarborLocationFunction();
                getHarborLocationFunction.X = x;
                getHarborLocationFunction.Y = y;
            
            return ContractHandler.QueryAsync<GetHarborLocationFunction, ushort>(getHarborLocationFunction, blockParameter);
        }
    }
}
