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
using Galleass3D.Contracts.Predecessor.ContractDefinition;

namespace Galleass3D.Contracts.Predecessor
{
    public partial class PredecessorService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PredecessorDeployment predecessorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PredecessorDeployment>().SendRequestAndWaitForReceiptAsync(predecessorDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PredecessorDeployment predecessorDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PredecessorDeployment>().SendRequestAsync(predecessorDeployment);
        }

        public static async Task<PredecessorService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PredecessorDeployment predecessorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, predecessorDeployment, cancellationTokenSource);
            return new PredecessorService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PredecessorService(Nethereum.Web3.Web3 web3, string contractAddress)
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

        public Task<byte> StagedModeQueryAsync(StagedModeFunction stagedModeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StagedModeFunction, byte>(stagedModeFunction, blockParameter);
        }

        
        public Task<byte> StagedModeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StagedModeFunction, byte>(null, blockParameter);
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
    }
}
