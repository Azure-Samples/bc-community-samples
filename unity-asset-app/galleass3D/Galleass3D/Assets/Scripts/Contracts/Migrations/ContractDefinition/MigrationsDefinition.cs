using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Galleass3D.Contracts.Migrations.ContractDefinition
{


    public partial class MigrationsDeployment : MigrationsDeploymentBase
    {
        public MigrationsDeployment() : base(BYTECODE) { }
        public MigrationsDeployment(string byteCode) : base(byteCode) { }
    }

    public class MigrationsDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405234801561001057600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506102f8806100606000396000f300608060405260043610610062576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680630900f01014610067578063445df0ac146100aa5780638da5cb5b146100d5578063fdacd5761461012c575b600080fd5b34801561007357600080fd5b506100a8600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610159565b005b3480156100b657600080fd5b506100bf610241565b6040518082815260200191505060405180910390f35b3480156100e157600080fd5b506100ea610247565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561013857600080fd5b506101576004803603810190808035906020019092919050505061026c565b005b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141561023d578190508073ffffffffffffffffffffffffffffffffffffffff1663fdacd5766001546040518263ffffffff167c010000000000000000000000000000000000000000000000000000000002815260040180828152602001915050600060405180830381600087803b15801561022457600080fd5b505af1158015610238573d6000803e3d6000fd5b505050505b5050565b60015481565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614156102c957806001819055505b505600a165627a7a72305820e909663b2b3949f49b57ca0f177939e60ed9a27ee8c4db9be46a8b571f6307bb0029";
        public MigrationsDeploymentBase() : base(BYTECODE) { }
        public MigrationsDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class Last_completed_migrationFunction : Last_completed_migrationFunctionBase { }

    [Function("last_completed_migration", "uint256")]
    public class Last_completed_migrationFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class SetCompletedFunction : SetCompletedFunctionBase { }

    [Function("setCompleted")]
    public class SetCompletedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "completed", 1)]
        public virtual BigInteger Completed { get; set; }
    }

    public partial class UpgradeFunction : UpgradeFunctionBase { }

    [Function("upgrade")]
    public class UpgradeFunctionBase : FunctionMessage
    {
        [Parameter("address", "new_address", 1)]
        public virtual string New_address { get; set; }
    }

    public partial class Last_completed_migrationOutputDTO : Last_completed_migrationOutputDTOBase { }

    [FunctionOutput]
    public class Last_completed_migrationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }




}
