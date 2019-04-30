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
using Galleass3D.Contracts.WorldsRegistry.ContractDefinition;

namespace Galleass3D.Contracts.WorldsRegistry
{
    public partial class WorldsRegistryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, WorldsRegistryDeployment worldsRegistryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<WorldsRegistryDeployment>().SendRequestAndWaitForReceiptAsync(worldsRegistryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, WorldsRegistryDeployment worldsRegistryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<WorldsRegistryDeployment>().SendRequestAsync(worldsRegistryDeployment);
        }

        public static async Task<WorldsRegistryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, WorldsRegistryDeployment worldsRegistryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, worldsRegistryDeployment, cancellationTokenSource);
            return new WorldsRegistryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public WorldsRegistryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> WorldsQueryAsync(WorldsFunction worldsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WorldsFunction, string>(worldsFunction, blockParameter);
        }

        
        public Task<string> WorldsQueryAsync(byte[] returnValue1, BlockParameter blockParameter = null)
        {
            var worldsFunction = new WorldsFunction();
                worldsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<WorldsFunction, string>(worldsFunction, blockParameter);
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

        public Task<string> RegisterGalleasWorldRequestAsync(RegisterGalleasWorldFunction registerGalleasWorldFunction)
        {
             return ContractHandler.SendRequestAsync(registerGalleasWorldFunction);
        }

        public Task<TransactionReceipt> RegisterGalleasWorldRequestAndWaitForReceiptAsync(RegisterGalleasWorldFunction registerGalleasWorldFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(registerGalleasWorldFunction, cancellationToken);
        }

        public Task<string> RegisterGalleasWorldRequestAsync(string galleasContract, string initiator, byte[] name)
        {
            var registerGalleasWorldFunction = new RegisterGalleasWorldFunction();
                registerGalleasWorldFunction.GalleasContract = galleasContract;
                registerGalleasWorldFunction.Initiator = initiator;
                registerGalleasWorldFunction.Name = name;
            
             return ContractHandler.SendRequestAsync(registerGalleasWorldFunction);
        }

        public Task<TransactionReceipt> RegisterGalleasWorldRequestAndWaitForReceiptAsync(string galleasContract, string initiator, byte[] name, CancellationTokenSource cancellationToken = null)
        {
            var registerGalleasWorldFunction = new RegisterGalleasWorldFunction();
                registerGalleasWorldFunction.GalleasContract = galleasContract;
                registerGalleasWorldFunction.Initiator = initiator;
                registerGalleasWorldFunction.Name = name;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(registerGalleasWorldFunction, cancellationToken);
        }
    }
}
