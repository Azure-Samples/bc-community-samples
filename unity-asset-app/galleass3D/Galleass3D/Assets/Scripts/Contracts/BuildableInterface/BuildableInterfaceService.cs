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
using Galleass3D.Contracts.BuildableInterface.ContractDefinition;

namespace Galleass3D.Contracts.BuildableInterface
{
    public partial class BuildableInterfaceService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BuildableInterfaceDeployment buildableInterfaceDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BuildableInterfaceDeployment>().SendRequestAndWaitForReceiptAsync(buildableInterfaceDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BuildableInterfaceDeployment buildableInterfaceDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BuildableInterfaceDeployment>().SendRequestAsync(buildableInterfaceDeployment);
        }

        public static async Task<BuildableInterfaceService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BuildableInterfaceDeployment buildableInterfaceDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, buildableInterfaceDeployment, cancellationTokenSource);
            return new BuildableInterfaceService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public BuildableInterfaceService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
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
    }
}
