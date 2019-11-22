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
using Galleass3D.Contracts.StandardTokenInterface.ContractDefinition;

namespace Galleass3D.Contracts.StandardTokenInterface
{
    public partial class StandardTokenInterfaceService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, StandardTokenInterfaceDeployment standardTokenInterfaceDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<StandardTokenInterfaceDeployment>().SendRequestAndWaitForReceiptAsync(standardTokenInterfaceDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, StandardTokenInterfaceDeployment standardTokenInterfaceDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<StandardTokenInterfaceDeployment>().SendRequestAsync(standardTokenInterfaceDeployment);
        }

        public static async Task<StandardTokenInterfaceService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, StandardTokenInterfaceDeployment standardTokenInterfaceDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, standardTokenInterfaceDeployment, cancellationTokenSource);
            return new StandardTokenInterfaceService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public StandardTokenInterfaceService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string returnValue1, string returnValue2, BigInteger returnValue3)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.ReturnValue1 = returnValue1;
                transferFromFunction.ReturnValue2 = returnValue2;
                transferFromFunction.ReturnValue3 = returnValue3;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string returnValue1, string returnValue2, BigInteger returnValue3, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.ReturnValue1 = returnValue1;
                transferFromFunction.ReturnValue2 = returnValue2;
                transferFromFunction.ReturnValue3 = returnValue3;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> GalleassTransferFromRequestAsync(GalleassTransferFromFunction galleassTransferFromFunction)
        {
             return ContractHandler.SendRequestAsync(galleassTransferFromFunction);
        }

        public Task<TransactionReceipt> GalleassTransferFromRequestAndWaitForReceiptAsync(GalleassTransferFromFunction galleassTransferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(galleassTransferFromFunction, cancellationToken);
        }

        public Task<string> GalleassTransferFromRequestAsync(string returnValue1, string returnValue2, BigInteger returnValue3)
        {
            var galleassTransferFromFunction = new GalleassTransferFromFunction();
                galleassTransferFromFunction.ReturnValue1 = returnValue1;
                galleassTransferFromFunction.ReturnValue2 = returnValue2;
                galleassTransferFromFunction.ReturnValue3 = returnValue3;
            
             return ContractHandler.SendRequestAsync(galleassTransferFromFunction);
        }

        public Task<TransactionReceipt> GalleassTransferFromRequestAndWaitForReceiptAsync(string returnValue1, string returnValue2, BigInteger returnValue3, CancellationTokenSource cancellationToken = null)
        {
            var galleassTransferFromFunction = new GalleassTransferFromFunction();
                galleassTransferFromFunction.ReturnValue1 = returnValue1;
                galleassTransferFromFunction.ReturnValue2 = returnValue2;
                galleassTransferFromFunction.ReturnValue3 = returnValue3;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(galleassTransferFromFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(TransferFunction transferFunction)
        {
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(string returnValue1, BigInteger returnValue2)
        {
            var transferFunction = new TransferFunction();
                transferFunction.ReturnValue1 = returnValue1;
                transferFunction.ReturnValue2 = returnValue2;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string returnValue1, BigInteger returnValue2, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.ReturnValue1 = returnValue1;
                transferFunction.ReturnValue2 = returnValue2;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string returnValue1, BigInteger returnValue2)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.ReturnValue1 = returnValue1;
                approveFunction.ReturnValue2 = returnValue2;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string returnValue1, BigInteger returnValue2, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.ReturnValue1 = returnValue1;
                approveFunction.ReturnValue2 = returnValue2;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> GalleassMintRequestAsync(GalleassMintFunction galleassMintFunction)
        {
             return ContractHandler.SendRequestAsync(galleassMintFunction);
        }

        public Task<TransactionReceipt> GalleassMintRequestAndWaitForReceiptAsync(GalleassMintFunction galleassMintFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(galleassMintFunction, cancellationToken);
        }

        public Task<string> GalleassMintRequestAsync(string returnValue1, BigInteger returnValue2)
        {
            var galleassMintFunction = new GalleassMintFunction();
                galleassMintFunction.ReturnValue1 = returnValue1;
                galleassMintFunction.ReturnValue2 = returnValue2;
            
             return ContractHandler.SendRequestAsync(galleassMintFunction);
        }

        public Task<TransactionReceipt> GalleassMintRequestAndWaitForReceiptAsync(string returnValue1, BigInteger returnValue2, CancellationTokenSource cancellationToken = null)
        {
            var galleassMintFunction = new GalleassMintFunction();
                galleassMintFunction.ReturnValue1 = returnValue1;
                galleassMintFunction.ReturnValue2 = returnValue2;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(galleassMintFunction, cancellationToken);
        }
    }
}
