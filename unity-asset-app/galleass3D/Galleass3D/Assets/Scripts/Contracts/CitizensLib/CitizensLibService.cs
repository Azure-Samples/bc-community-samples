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
using Galleass3D.Contracts.CitizensLib.ContractDefinition;

namespace Galleass3D.Contracts.CitizensLib
{
    public partial class CitizensLibService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, CitizensLibDeployment citizensLibDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CitizensLibDeployment>().SendRequestAndWaitForReceiptAsync(citizensLibDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, CitizensLibDeployment citizensLibDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CitizensLibDeployment>().SendRequestAsync(citizensLibDeployment);
        }

        public static async Task<CitizensLibService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, CitizensLibDeployment citizensLibDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, citizensLibDeployment, cancellationTokenSource);
            return new CitizensLibService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public CitizensLibService(Nethereum.Web3.Web3 web3, string contractAddress)
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

        public Task<string> OwnerCreateCitizenRequestAsync(OwnerCreateCitizenFunction ownerCreateCitizenFunction)
        {
             return ContractHandler.SendRequestAsync(ownerCreateCitizenFunction);
        }

        public Task<TransactionReceipt> OwnerCreateCitizenRequestAndWaitForReceiptAsync(OwnerCreateCitizenFunction ownerCreateCitizenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ownerCreateCitizenFunction, cancellationToken);
        }

        public Task<string> OwnerCreateCitizenRequestAsync(string owner, ushort x, ushort y, byte tile, byte[] genes, byte[] characteristics)
        {
            var ownerCreateCitizenFunction = new OwnerCreateCitizenFunction();
                ownerCreateCitizenFunction.Owner = owner;
                ownerCreateCitizenFunction.X = x;
                ownerCreateCitizenFunction.Y = y;
                ownerCreateCitizenFunction.Tile = tile;
                ownerCreateCitizenFunction.Genes = genes;
                ownerCreateCitizenFunction.Characteristics = characteristics;
            
             return ContractHandler.SendRequestAsync(ownerCreateCitizenFunction);
        }

        public Task<TransactionReceipt> OwnerCreateCitizenRequestAndWaitForReceiptAsync(string owner, ushort x, ushort y, byte tile, byte[] genes, byte[] characteristics, CancellationTokenSource cancellationToken = null)
        {
            var ownerCreateCitizenFunction = new OwnerCreateCitizenFunction();
                ownerCreateCitizenFunction.Owner = owner;
                ownerCreateCitizenFunction.X = x;
                ownerCreateCitizenFunction.Y = y;
                ownerCreateCitizenFunction.Tile = tile;
                ownerCreateCitizenFunction.Genes = genes;
                ownerCreateCitizenFunction.Characteristics = characteristics;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ownerCreateCitizenFunction, cancellationToken);
        }

        public Task<string> OwnerSetStatusRequestAsync(OwnerSetStatusFunction ownerSetStatusFunction)
        {
             return ContractHandler.SendRequestAsync(ownerSetStatusFunction);
        }

        public Task<TransactionReceipt> OwnerSetStatusRequestAndWaitForReceiptAsync(OwnerSetStatusFunction ownerSetStatusFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ownerSetStatusFunction, cancellationToken);
        }

        public Task<string> OwnerSetStatusRequestAsync(BigInteger id, byte status)
        {
            var ownerSetStatusFunction = new OwnerSetStatusFunction();
                ownerSetStatusFunction.Id = id;
                ownerSetStatusFunction.Status = status;
            
             return ContractHandler.SendRequestAsync(ownerSetStatusFunction);
        }

        public Task<TransactionReceipt> OwnerSetStatusRequestAndWaitForReceiptAsync(BigInteger id, byte status, CancellationTokenSource cancellationToken = null)
        {
            var ownerSetStatusFunction = new OwnerSetStatusFunction();
                ownerSetStatusFunction.Id = id;
                ownerSetStatusFunction.Status = status;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ownerSetStatusFunction, cancellationToken);
        }

        public Task<string> CreateCitizenRequestAsync(CreateCitizenFunction createCitizenFunction)
        {
             return ContractHandler.SendRequestAsync(createCitizenFunction);
        }

        public Task<TransactionReceipt> CreateCitizenRequestAndWaitForReceiptAsync(CreateCitizenFunction createCitizenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createCitizenFunction, cancellationToken);
        }

        public Task<string> CreateCitizenRequestAsync(string owner, ushort x, ushort y, byte tile, byte[] food1, byte[] food2, byte[] food3)
        {
            var createCitizenFunction = new CreateCitizenFunction();
                createCitizenFunction.Owner = owner;
                createCitizenFunction.X = x;
                createCitizenFunction.Y = y;
                createCitizenFunction.Tile = tile;
                createCitizenFunction.Food1 = food1;
                createCitizenFunction.Food2 = food2;
                createCitizenFunction.Food3 = food3;
            
             return ContractHandler.SendRequestAsync(createCitizenFunction);
        }

        public Task<TransactionReceipt> CreateCitizenRequestAndWaitForReceiptAsync(string owner, ushort x, ushort y, byte tile, byte[] food1, byte[] food2, byte[] food3, CancellationTokenSource cancellationToken = null)
        {
            var createCitizenFunction = new CreateCitizenFunction();
                createCitizenFunction.Owner = owner;
                createCitizenFunction.X = x;
                createCitizenFunction.Y = y;
                createCitizenFunction.Tile = tile;
                createCitizenFunction.Food1 = food1;
                createCitizenFunction.Food2 = food2;
                createCitizenFunction.Food3 = food3;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createCitizenFunction, cancellationToken);
        }

        public Task<GetCitizenGenesOutputDTO> GetCitizenGenesQueryAsync(GetCitizenGenesFunction getCitizenGenesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetCitizenGenesFunction, GetCitizenGenesOutputDTO>(getCitizenGenesFunction, blockParameter);
        }

        public Task<GetCitizenGenesOutputDTO> GetCitizenGenesQueryAsync(BigInteger id, BlockParameter blockParameter = null)
        {
            var getCitizenGenesFunction = new GetCitizenGenesFunction();
                getCitizenGenesFunction.Id = id;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetCitizenGenesFunction, GetCitizenGenesOutputDTO>(getCitizenGenesFunction, blockParameter);
        }

        public Task<GetCitizenCharacteristicsOutputDTO> GetCitizenCharacteristicsQueryAsync(GetCitizenCharacteristicsFunction getCitizenCharacteristicsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetCitizenCharacteristicsFunction, GetCitizenCharacteristicsOutputDTO>(getCitizenCharacteristicsFunction, blockParameter);
        }

        public Task<GetCitizenCharacteristicsOutputDTO> GetCitizenCharacteristicsQueryAsync(BigInteger id, BlockParameter blockParameter = null)
        {
            var getCitizenCharacteristicsFunction = new GetCitizenCharacteristicsFunction();
                getCitizenCharacteristicsFunction.Id = id;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetCitizenCharacteristicsFunction, GetCitizenCharacteristicsOutputDTO>(getCitizenCharacteristicsFunction, blockParameter);
        }

        public Task<GetCitizenStatusOutputDTO> GetCitizenStatusQueryAsync(GetCitizenStatusFunction getCitizenStatusFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetCitizenStatusFunction, GetCitizenStatusOutputDTO>(getCitizenStatusFunction, blockParameter);
        }

        public Task<GetCitizenStatusOutputDTO> GetCitizenStatusQueryAsync(BigInteger id, BlockParameter blockParameter = null)
        {
            var getCitizenStatusFunction = new GetCitizenStatusFunction();
                getCitizenStatusFunction.Id = id;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetCitizenStatusFunction, GetCitizenStatusOutputDTO>(getCitizenStatusFunction, blockParameter);
        }

        public Task<string> SetStatusRequestAsync(SetStatusFunction setStatusFunction)
        {
             return ContractHandler.SendRequestAsync(setStatusFunction);
        }

        public Task<TransactionReceipt> SetStatusRequestAndWaitForReceiptAsync(SetStatusFunction setStatusFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setStatusFunction, cancellationToken);
        }

        public Task<string> SetStatusRequestAsync(BigInteger id, byte status)
        {
            var setStatusFunction = new SetStatusFunction();
                setStatusFunction.Id = id;
                setStatusFunction.Status = status;
            
             return ContractHandler.SendRequestAsync(setStatusFunction);
        }

        public Task<TransactionReceipt> SetStatusRequestAndWaitForReceiptAsync(BigInteger id, byte status, CancellationTokenSource cancellationToken = null)
        {
            var setStatusFunction = new SetStatusFunction();
                setStatusFunction.Id = id;
                setStatusFunction.Status = status;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setStatusFunction, cancellationToken);
        }

        public Task<string> SetPriceRequestAsync(SetPriceFunction setPriceFunction)
        {
             return ContractHandler.SendRequestAsync(setPriceFunction);
        }

        public Task<TransactionReceipt> SetPriceRequestAndWaitForReceiptAsync(SetPriceFunction setPriceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceFunction, cancellationToken);
        }

        public Task<string> SetPriceRequestAsync(BigInteger id, BigInteger price)
        {
            var setPriceFunction = new SetPriceFunction();
                setPriceFunction.Id = id;
                setPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAsync(setPriceFunction);
        }

        public Task<TransactionReceipt> SetPriceRequestAndWaitForReceiptAsync(BigInteger id, BigInteger price, CancellationTokenSource cancellationToken = null)
        {
            var setPriceFunction = new SetPriceFunction();
                setPriceFunction.Id = id;
                setPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceFunction, cancellationToken);
        }

        public Task<string> MoveCitizenRequestAsync(MoveCitizenFunction moveCitizenFunction)
        {
             return ContractHandler.SendRequestAsync(moveCitizenFunction);
        }

        public Task<TransactionReceipt> MoveCitizenRequestAndWaitForReceiptAsync(MoveCitizenFunction moveCitizenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(moveCitizenFunction, cancellationToken);
        }

        public Task<string> MoveCitizenRequestAsync(BigInteger id, byte tile)
        {
            var moveCitizenFunction = new MoveCitizenFunction();
                moveCitizenFunction.Id = id;
                moveCitizenFunction.Tile = tile;
            
             return ContractHandler.SendRequestAsync(moveCitizenFunction);
        }

        public Task<TransactionReceipt> MoveCitizenRequestAndWaitForReceiptAsync(BigInteger id, byte tile, CancellationTokenSource cancellationToken = null)
        {
            var moveCitizenFunction = new MoveCitizenFunction();
                moveCitizenFunction.Id = id;
                moveCitizenFunction.Tile = tile;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(moveCitizenFunction, cancellationToken);
        }
    }
}
