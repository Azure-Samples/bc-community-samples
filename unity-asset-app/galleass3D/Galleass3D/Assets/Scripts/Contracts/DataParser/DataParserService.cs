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
using Galleass3D.Contracts.DataParser.ContractDefinition;

namespace Galleass3D.Contracts.DataParser
{
    public partial class DataParserService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, DataParserDeployment dataParserDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<DataParserDeployment>().SendRequestAndWaitForReceiptAsync(dataParserDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, DataParserDeployment dataParserDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<DataParserDeployment>().SendRequestAsync(dataParserDeployment);
        }

        public static async Task<DataParserService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, DataParserDeployment dataParserDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, dataParserDeployment, cancellationTokenSource);
            return new DataParserService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public DataParserService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
