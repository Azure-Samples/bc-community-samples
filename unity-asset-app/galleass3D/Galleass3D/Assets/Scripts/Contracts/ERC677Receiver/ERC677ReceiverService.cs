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
using Galleass3D.Contracts.ERC677Receiver.ContractDefinition;

namespace Galleass3D.Contracts.ERC677Receiver
{
    public partial class ERC677ReceiverService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ERC677ReceiverDeployment eRC677ReceiverDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ERC677ReceiverDeployment>().SendRequestAndWaitForReceiptAsync(eRC677ReceiverDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ERC677ReceiverDeployment eRC677ReceiverDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ERC677ReceiverDeployment>().SendRequestAsync(eRC677ReceiverDeployment);
        }

        public static async Task<ERC677ReceiverService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ERC677ReceiverDeployment eRC677ReceiverDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, eRC677ReceiverDeployment, cancellationTokenSource);
            return new ERC677ReceiverService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ERC677ReceiverService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> OnTokenTransferQueryAsync(OnTokenTransferFunction onTokenTransferFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OnTokenTransferFunction, bool>(onTokenTransferFunction, blockParameter);
        }

        
        public Task<bool> OnTokenTransferQueryAsync(string returnValue1, BigInteger returnValue2, byte[] returnValue3, BlockParameter blockParameter = null)
        {
            var onTokenTransferFunction = new OnTokenTransferFunction();
                onTokenTransferFunction.ReturnValue1 = returnValue1;
                onTokenTransferFunction.ReturnValue2 = returnValue2;
                onTokenTransferFunction.ReturnValue3 = returnValue3;
            
            return ContractHandler.QueryAsync<OnTokenTransferFunction, bool>(onTokenTransferFunction, blockParameter);
        }
    }
}
