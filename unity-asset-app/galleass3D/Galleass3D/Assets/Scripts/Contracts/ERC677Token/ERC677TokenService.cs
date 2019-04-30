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
using Galleass3D.Contracts.ERC677Token.ContractDefinition;

namespace Galleass3D.Contracts.ERC677Token
{
    public partial class ERC677TokenService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ERC677TokenDeployment eRC677TokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ERC677TokenDeployment>().SendRequestAndWaitForReceiptAsync(eRC677TokenDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ERC677TokenDeployment eRC677TokenDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ERC677TokenDeployment>().SendRequestAsync(eRC677TokenDeployment);
        }

        public static async Task<ERC677TokenService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ERC677TokenDeployment eRC677TokenDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, eRC677TokenDeployment, cancellationTokenSource);
            return new ERC677TokenService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ERC677TokenService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string spender, BigInteger value)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string spender, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger value)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> DecreaseApprovalRequestAsync(DecreaseApprovalFunction decreaseApprovalFunction)
        {
             return ContractHandler.SendRequestAsync(decreaseApprovalFunction);
        }

        public Task<TransactionReceipt> DecreaseApprovalRequestAndWaitForReceiptAsync(DecreaseApprovalFunction decreaseApprovalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseApprovalFunction, cancellationToken);
        }

        public Task<string> DecreaseApprovalRequestAsync(string spender, BigInteger subtractedValue)
        {
            var decreaseApprovalFunction = new DecreaseApprovalFunction();
                decreaseApprovalFunction.Spender = spender;
                decreaseApprovalFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAsync(decreaseApprovalFunction);
        }

        public Task<TransactionReceipt> DecreaseApprovalRequestAndWaitForReceiptAsync(string spender, BigInteger subtractedValue, CancellationTokenSource cancellationToken = null)
        {
            var decreaseApprovalFunction = new DecreaseApprovalFunction();
                decreaseApprovalFunction.Spender = spender;
                decreaseApprovalFunction.SubtractedValue = subtractedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(decreaseApprovalFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Owner = owner;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<string> TransferRequestAsync(TransferFunction transferFunction)
        {
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(string to, BigInteger value)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string to, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> IncreaseApprovalRequestAsync(IncreaseApprovalFunction increaseApprovalFunction)
        {
             return ContractHandler.SendRequestAsync(increaseApprovalFunction);
        }

        public Task<TransactionReceipt> IncreaseApprovalRequestAndWaitForReceiptAsync(IncreaseApprovalFunction increaseApprovalFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseApprovalFunction, cancellationToken);
        }

        public Task<string> IncreaseApprovalRequestAsync(string spender, BigInteger addedValue)
        {
            var increaseApprovalFunction = new IncreaseApprovalFunction();
                increaseApprovalFunction.Spender = spender;
                increaseApprovalFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAsync(increaseApprovalFunction);
        }

        public Task<TransactionReceipt> IncreaseApprovalRequestAndWaitForReceiptAsync(string spender, BigInteger addedValue, CancellationTokenSource cancellationToken = null)
        {
            var increaseApprovalFunction = new IncreaseApprovalFunction();
                increaseApprovalFunction.Spender = spender;
                increaseApprovalFunction.AddedValue = addedValue;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(increaseApprovalFunction, cancellationToken);
        }

        public Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        
        public Task<BigInteger> AllowanceQueryAsync(string owner, string spender, BlockParameter blockParameter = null)
        {
            var allowanceFunction = new AllowanceFunction();
                allowanceFunction.Owner = owner;
                allowanceFunction.Spender = spender;
            
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        public Task<string> TransferAndCallRequestAsync(TransferAndCallFunction transferAndCallFunction)
        {
             return ContractHandler.SendRequestAsync(transferAndCallFunction);
        }

        public Task<TransactionReceipt> TransferAndCallRequestAndWaitForReceiptAsync(TransferAndCallFunction transferAndCallFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferAndCallFunction, cancellationToken);
        }

        public Task<string> TransferAndCallRequestAsync(string to, BigInteger value, byte[] data)
        {
            var transferAndCallFunction = new TransferAndCallFunction();
                transferAndCallFunction.To = to;
                transferAndCallFunction.Value = value;
                transferAndCallFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(transferAndCallFunction);
        }

        public Task<TransactionReceipt> TransferAndCallRequestAndWaitForReceiptAsync(string to, BigInteger value, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var transferAndCallFunction = new TransferAndCallFunction();
                transferAndCallFunction.To = to;
                transferAndCallFunction.Value = value;
                transferAndCallFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferAndCallFunction, cancellationToken);
        }
    }
}
