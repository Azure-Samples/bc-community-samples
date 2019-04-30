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
using Galleass3D.Contracts.NFT.ContractDefinition;

namespace Galleass3D.Contracts.NFT
{
    public partial class NFTService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, NFTDeployment nFTDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<NFTDeployment>().SendRequestAndWaitForReceiptAsync(nFTDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, NFTDeployment nFTDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<NFTDeployment>().SendRequestAsync(nFTDeployment);
        }

        public static async Task<NFTService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, NFTDeployment nFTDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, nFTDeployment, cancellationTokenSource);
            return new NFTService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public NFTService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> TokenIndexToOwnerQueryAsync(TokenIndexToOwnerFunction tokenIndexToOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenIndexToOwnerFunction, string>(tokenIndexToOwnerFunction, blockParameter);
        }

        
        public Task<string> TokenIndexToOwnerQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var tokenIndexToOwnerFunction = new TokenIndexToOwnerFunction();
                tokenIndexToOwnerFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<TokenIndexToOwnerFunction, string>(tokenIndexToOwnerFunction, blockParameter);
        }

        public Task<string> TokenIndexToApprovedQueryAsync(TokenIndexToApprovedFunction tokenIndexToApprovedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenIndexToApprovedFunction, string>(tokenIndexToApprovedFunction, blockParameter);
        }

        
        public Task<string> TokenIndexToApprovedQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var tokenIndexToApprovedFunction = new TokenIndexToApprovedFunction();
                tokenIndexToApprovedFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<TokenIndexToApprovedFunction, string>(tokenIndexToApprovedFunction, blockParameter);
        }

        public Task<string> TransferRequestAsync(TransferFunction transferFunction)
        {
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(string to, BigInteger tokenId)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string to, BigInteger tokenId)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.To = to;
                approveFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.To = to;
                approveFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
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

        public Task<string> OwnerOfQueryAsync(OwnerOfFunction ownerOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        
        public Task<string> OwnerOfQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var ownerOfFunction = new OwnerOfFunction();
                ownerOfFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        public Task<bool> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowanceFunction, bool>(allowanceFunction, blockParameter);
        }

        
        public Task<bool> AllowanceQueryAsync(string claimant, BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var allowanceFunction = new AllowanceFunction();
                allowanceFunction.Claimant = claimant;
                allowanceFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<AllowanceFunction, bool>(allowanceFunction, blockParameter);
        }
    }
}
