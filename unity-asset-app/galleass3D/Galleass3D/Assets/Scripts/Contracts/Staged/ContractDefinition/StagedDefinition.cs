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

namespace Galleass3D.Contracts.Staged.ContractDefinition
{


    public partial class StagedDeployment : StagedDeploymentBase
    {
        public StagedDeployment() : base(BYTECODE) { }
        public StagedDeployment(string byteCode) : base(byteCode) { }
    }

    public class StagedDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405234801561001057600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506001600060146101000a81548160ff0219169083600381111561007057fe5b02179055506108e4806100846000396000f300608060405260043610610099576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff16806305e88b691461009e5780632b68b9c6146100cd578063715018a6146100fc5780638456cb59146101135780638da5cb5b146101425780638e1a55fc14610199578063b0e31581146101c8578063c040e6b814610201578063f2fde38b14610230575b600080fd5b3480156100aa57600080fd5b506100b3610273565b604051808215151515815260200191505060405180910390f35b3480156100d957600080fd5b506100e261032b565b604051808215151515815260200191505060405180910390f35b34801561010857600080fd5b506101116103f6565b005b34801561011f57600080fd5b506101286104f8565b604051808215151515815260200191505060405180910390f35b34801561014e57600080fd5b506101576105af565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156101a557600080fd5b506101ae6105d4565b604051808215151515815260200191505060405180910390f35b3480156101d457600080fd5b506101dd61068c565b604051808260038111156101ed57fe5b60ff16815260200191505060405180910390f35b34801561020d57600080fd5b5061021661069f565b604051808215151515815260200191505060405180910390f35b34801561023c57600080fd5b50610271600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610757565b005b60006002600381111561028257fe5b600060149054906101000a900460ff16600381111561029d57fe5b1415156102a957600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561030457600080fd5b6003600060146101000a81548160ff0219169083600381111561032357fe5b021790555090565b600060038081111561033957fe5b600060149054906101000a900460ff16600381111561035457fe5b1415151561036157600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156103bc57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16ff5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561045157600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482060405160405180910390a260008060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550565b600060038081111561050657fe5b600060149054906101000a900460ff16600381111561052157fe5b1415151561052e57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561058957600080fd5b60008060146101000a81548160ff021916908360038111156105a757fe5b021790555090565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60006003808111156105e257fe5b600060149054906101000a900460ff1660038111156105fd57fe5b1415151561060a57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561066557600080fd5b6001600060146101000a81548160ff0219169083600381111561068457fe5b021790555090565b600060149054906101000a900460ff1681565b60006003808111156106ad57fe5b600060149054906101000a900460ff1660038111156106c857fe5b141515156106d557600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561073057600080fd5b6002600060146101000a81548160ff0219169083600381111561074f57fe5b021790555090565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156107b257600080fd5b6107bb816107be565b50565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff16141515156107fa57600080fd5b8073ffffffffffffffffffffffffffffffffffffffff166000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e060405160405180910390a3806000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550505600a165627a7a72305820c8e8628b8bd54b2cd990d8095e41e61de379ac009af2f8a4da34973d74745a820029";
        public StagedDeploymentBase() : base(BYTECODE) { }
        public StagedDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class StagedModeFunction : StagedModeFunctionBase { }

    [Function("stagedMode", "uint8")]
    public class StagedModeFunctionBase : FunctionMessage
    {

    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "_newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class PauseFunction : PauseFunctionBase { }

    [Function("pause", "bool")]
    public class PauseFunctionBase : FunctionMessage
    {

    }

    public partial class StageFunction : StageFunctionBase { }

    [Function("stage", "bool")]
    public class StageFunctionBase : FunctionMessage
    {

    }

    public partial class BuildFunction : BuildFunctionBase { }

    [Function("build", "bool")]
    public class BuildFunctionBase : FunctionMessage
    {

    }

    public partial class DestructFunction : DestructFunctionBase { }

    [Function("destruct", "bool")]
    public class DestructFunctionBase : FunctionMessage
    {

    }

    public partial class ProductionFunction : ProductionFunctionBase { }

    [Function("production", "bool")]
    public class ProductionFunctionBase : FunctionMessage
    {

    }

    public partial class OwnershipRenouncedEventDTO : OwnershipRenouncedEventDTOBase { }

    [Event("OwnershipRenounced")]
    public class OwnershipRenouncedEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
    }

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }



    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class StagedModeOutputDTO : StagedModeOutputDTOBase { }

    [FunctionOutput]
    public class StagedModeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }












}
