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
using Galleass3D.Contracts.SafeMath.ContractDefinition;

namespace Galleass3D.Contracts.SafeMath
{
    public partial class SafeMathService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SafeMathDeployment safeMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SafeMathDeployment>().SendRequestAndWaitForReceiptAsync(safeMathDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SafeMathDeployment safeMathDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SafeMathDeployment>().SendRequestAsync(safeMathDeployment);
        }

        public static async Task<SafeMathService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SafeMathDeployment safeMathDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, safeMathDeployment, cancellationTokenSource);
            return new SafeMathService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SafeMathService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
