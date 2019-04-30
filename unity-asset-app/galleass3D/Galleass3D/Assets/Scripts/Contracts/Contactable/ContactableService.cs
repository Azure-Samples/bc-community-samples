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
using Galleass3D.Contracts.Contactable.ContractDefinition;

namespace Galleass3D.Contracts.Contactable
{
    public partial class ContactableService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ContactableDeployment contactableDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ContactableDeployment>().SendRequestAndWaitForReceiptAsync(contactableDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ContactableDeployment contactableDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ContactableDeployment>().SendRequestAsync(contactableDeployment);
        }

        public static async Task<ContactableService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ContactableDeployment contactableDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, contactableDeployment, cancellationTokenSource);
            return new ContactableService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ContactableService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
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
    }
}
