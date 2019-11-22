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
using Galleass3D.Contracts.Migrations.ContractDefinition;

namespace Galleass3D.Contracts.Migrations
{
    public partial class MigrationsService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, MigrationsDeployment migrationsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<MigrationsDeployment>().SendRequestAndWaitForReceiptAsync(migrationsDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, MigrationsDeployment migrationsDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<MigrationsDeployment>().SendRequestAsync(migrationsDeployment);
        }

        public static async Task<MigrationsService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, MigrationsDeployment migrationsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, migrationsDeployment, cancellationTokenSource);
            return new MigrationsService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public MigrationsService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> Last_completed_migrationQueryAsync(Last_completed_migrationFunction last_completed_migrationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Last_completed_migrationFunction, BigInteger>(last_completed_migrationFunction, blockParameter);
        }

        
        public Task<BigInteger> Last_completed_migrationQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Last_completed_migrationFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> SetCompletedRequestAsync(SetCompletedFunction setCompletedFunction)
        {
             return ContractHandler.SendRequestAsync(setCompletedFunction);
        }

        public Task<TransactionReceipt> SetCompletedRequestAndWaitForReceiptAsync(SetCompletedFunction setCompletedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCompletedFunction, cancellationToken);
        }

        public Task<string> SetCompletedRequestAsync(BigInteger completed)
        {
            var setCompletedFunction = new SetCompletedFunction();
                setCompletedFunction.Completed = completed;
            
             return ContractHandler.SendRequestAsync(setCompletedFunction);
        }

        public Task<TransactionReceipt> SetCompletedRequestAndWaitForReceiptAsync(BigInteger completed, CancellationTokenSource cancellationToken = null)
        {
            var setCompletedFunction = new SetCompletedFunction();
                setCompletedFunction.Completed = completed;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setCompletedFunction, cancellationToken);
        }

        public Task<string> UpgradeRequestAsync(UpgradeFunction upgradeFunction)
        {
             return ContractHandler.SendRequestAsync(upgradeFunction);
        }

        public Task<TransactionReceipt> UpgradeRequestAndWaitForReceiptAsync(UpgradeFunction upgradeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeFunction, cancellationToken);
        }

        public Task<string> UpgradeRequestAsync(string new_address)
        {
            var upgradeFunction = new UpgradeFunction();
                upgradeFunction.New_address = new_address;
            
             return ContractHandler.SendRequestAsync(upgradeFunction);
        }

        public Task<TransactionReceipt> UpgradeRequestAndWaitForReceiptAsync(string new_address, CancellationTokenSource cancellationToken = null)
        {
            var upgradeFunction = new UpgradeFunction();
                upgradeFunction.New_address = new_address;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeFunction, cancellationToken);
        }
    }
}
