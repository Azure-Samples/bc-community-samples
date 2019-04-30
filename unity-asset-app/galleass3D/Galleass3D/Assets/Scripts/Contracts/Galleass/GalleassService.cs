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
using Galleass3D.Contracts.Galleass.ContractDefinition;

namespace Galleass3D.Contracts.Galleass
{
    public partial class GalleassService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, GalleassDeployment galleassDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<GalleassDeployment>().SendRequestAndWaitForReceiptAsync(galleassDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, GalleassDeployment galleassDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<GalleassDeployment>().SendRequestAsync(galleassDeployment);
        }

        public static async Task<GalleassService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, GalleassDeployment galleassDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, galleassDeployment, cancellationTokenSource);
            return new GalleassService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public GalleassService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ProductionRequestAsync(ProductionFunction productionFunction)
        {
             return ContractHandler.SendRequestAsync(productionFunction);
        }

        public Task<string> ProductionRequestAsync()
        {
             return ContractHandler.SendRequestAsync<ProductionFunction>();
        }

        public Task<TransactionReceipt> ProductionRequestAndWaitForReceiptAsync(ProductionFunction productionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(productionFunction, cancellationToken);
        }

        public Task<TransactionReceipt> ProductionRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<ProductionFunction>(null, cancellationToken);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> DestructRequestAsync(DestructFunction destructFunction)
        {
             return ContractHandler.SendRequestAsync(destructFunction);
        }

        public Task<string> DestructRequestAsync()
        {
             return ContractHandler.SendRequestAsync<DestructFunction>();
        }

        public Task<TransactionReceipt> DestructRequestAndWaitForReceiptAsync(DestructFunction destructFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(destructFunction, cancellationToken);
        }

        public Task<TransactionReceipt> DestructRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<DestructFunction>(null, cancellationToken);
        }

        public Task<string> ContactInformationQueryAsync(ContactInformationFunction contactInformationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContactInformationFunction, string>(contactInformationFunction, blockParameter);
        }

        
        public Task<string> ContactInformationQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContactInformationFunction, string>(null, blockParameter);
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

        public Task<string> PauseRequestAsync(PauseFunction pauseFunction)
        {
             return ContractHandler.SendRequestAsync(pauseFunction);
        }

        public Task<string> PauseRequestAsync()
        {
             return ContractHandler.SendRequestAsync<PauseFunction>();
        }

        public Task<TransactionReceipt> PauseRequestAndWaitForReceiptAsync(PauseFunction pauseFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(pauseFunction, cancellationToken);
        }

        public Task<TransactionReceipt> PauseRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<PauseFunction>(null, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> BuildRequestAsync(BuildFunction buildFunction)
        {
             return ContractHandler.SendRequestAsync(buildFunction);
        }

        public Task<string> BuildRequestAsync()
        {
             return ContractHandler.SendRequestAsync<BuildFunction>();
        }

        public Task<TransactionReceipt> BuildRequestAndWaitForReceiptAsync(BuildFunction buildFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buildFunction, cancellationToken);
        }

        public Task<TransactionReceipt> BuildRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<BuildFunction>(null, cancellationToken);
        }

        public Task<string> AuthorQueryAsync(AuthorFunction authorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AuthorFunction, string>(authorFunction, blockParameter);
        }

        
        public Task<string> AuthorQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AuthorFunction, string>(null, blockParameter);
        }

        public Task<byte> StagedModeQueryAsync(StagedModeFunction stagedModeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StagedModeFunction, byte>(stagedModeFunction, blockParameter);
        }

        
        public Task<byte> StagedModeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StagedModeFunction, byte>(null, blockParameter);
        }

        public Task<string> SetContactInformationRequestAsync(SetContactInformationFunction setContactInformationFunction)
        {
             return ContractHandler.SendRequestAsync(setContactInformationFunction);
        }

        public Task<TransactionReceipt> SetContactInformationRequestAndWaitForReceiptAsync(SetContactInformationFunction setContactInformationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContactInformationFunction, cancellationToken);
        }

        public Task<string> SetContactInformationRequestAsync(string info)
        {
            var setContactInformationFunction = new SetContactInformationFunction();
                setContactInformationFunction.Info = info;
            
             return ContractHandler.SendRequestAsync(setContactInformationFunction);
        }

        public Task<TransactionReceipt> SetContactInformationRequestAndWaitForReceiptAsync(string info, CancellationTokenSource cancellationToken = null)
        {
            var setContactInformationFunction = new SetContactInformationFunction();
                setContactInformationFunction.Info = info;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContactInformationFunction, cancellationToken);
        }

        public Task<string> StageRequestAsync(StageFunction stageFunction)
        {
             return ContractHandler.SendRequestAsync(stageFunction);
        }

        public Task<string> StageRequestAsync()
        {
             return ContractHandler.SendRequestAsync<StageFunction>();
        }

        public Task<TransactionReceipt> StageRequestAndWaitForReceiptAsync(StageFunction stageFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stageFunction, cancellationToken);
        }

        public Task<TransactionReceipt> StageRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<StageFunction>(null, cancellationToken);
        }

        public Task<string> SetDescendantRequestAsync(SetDescendantFunction setDescendantFunction)
        {
             return ContractHandler.SendRequestAsync(setDescendantFunction);
        }

        public Task<TransactionReceipt> SetDescendantRequestAndWaitForReceiptAsync(SetDescendantFunction setDescendantFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setDescendantFunction, cancellationToken);
        }

        public Task<string> SetDescendantRequestAsync(string descendant)
        {
            var setDescendantFunction = new SetDescendantFunction();
                setDescendantFunction.Descendant = descendant;
            
             return ContractHandler.SendRequestAsync(setDescendantFunction);
        }

        public Task<TransactionReceipt> SetDescendantRequestAndWaitForReceiptAsync(string descendant, CancellationTokenSource cancellationToken = null)
        {
            var setDescendantFunction = new SetDescendantFunction();
                setDescendantFunction.Descendant = descendant;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setDescendantFunction, cancellationToken);
        }

        public Task<string> DescendantQueryAsync(DescendantFunction descendantFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescendantFunction, string>(descendantFunction, blockParameter);
        }

        
        public Task<string> DescendantQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescendantFunction, string>(null, blockParameter);
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

        public Task<string> UpgradeContractRequestAsync(UpgradeContractFunction upgradeContractFunction)
        {
             return ContractHandler.SendRequestAsync(upgradeContractFunction);
        }

        public Task<TransactionReceipt> UpgradeContractRequestAndWaitForReceiptAsync(UpgradeContractFunction upgradeContractFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeContractFunction, cancellationToken);
        }

        public Task<string> UpgradeContractRequestAsync(string contract)
        {
            var upgradeContractFunction = new UpgradeContractFunction();
                upgradeContractFunction.Contract = contract;
            
             return ContractHandler.SendRequestAsync(upgradeContractFunction);
        }

        public Task<TransactionReceipt> UpgradeContractRequestAndWaitForReceiptAsync(string contract, CancellationTokenSource cancellationToken = null)
        {
            var upgradeContractFunction = new UpgradeContractFunction();
                upgradeContractFunction.Contract = contract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeContractFunction, cancellationToken);
        }

        public Task<string> SetContractRequestAsync(SetContractFunction setContractFunction)
        {
             return ContractHandler.SendRequestAsync(setContractFunction);
        }

        public Task<TransactionReceipt> SetContractRequestAndWaitForReceiptAsync(SetContractFunction setContractFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractFunction, cancellationToken);
        }

        public Task<string> SetContractRequestAsync(byte[] name, string contract)
        {
            var setContractFunction = new SetContractFunction();
                setContractFunction.Name = name;
                setContractFunction.Contract = contract;
            
             return ContractHandler.SendRequestAsync(setContractFunction);
        }

        public Task<TransactionReceipt> SetContractRequestAndWaitForReceiptAsync(byte[] name, string contract, CancellationTokenSource cancellationToken = null)
        {
            var setContractFunction = new SetContractFunction();
                setContractFunction.Name = name;
                setContractFunction.Contract = contract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractFunction, cancellationToken);
        }

        public Task<string> SetPermissionRequestAsync(SetPermissionFunction setPermissionFunction)
        {
             return ContractHandler.SendRequestAsync(setPermissionFunction);
        }

        public Task<TransactionReceipt> SetPermissionRequestAndWaitForReceiptAsync(SetPermissionFunction setPermissionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPermissionFunction, cancellationToken);
        }

        public Task<string> SetPermissionRequestAsync(string contract, byte[] permission, bool value)
        {
            var setPermissionFunction = new SetPermissionFunction();
                setPermissionFunction.Contract = contract;
                setPermissionFunction.Permission = permission;
                setPermissionFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(setPermissionFunction);
        }

        public Task<TransactionReceipt> SetPermissionRequestAndWaitForReceiptAsync(string contract, byte[] permission, bool value, CancellationTokenSource cancellationToken = null)
        {
            var setPermissionFunction = new SetPermissionFunction();
                setPermissionFunction.Contract = contract;
                setPermissionFunction.Permission = permission;
                setPermissionFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPermissionFunction, cancellationToken);
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
    }
}
