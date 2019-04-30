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

namespace Galleass3D.Contracts.Predecessor.ContractDefinition
{


    public partial class PredecessorDeployment : PredecessorDeploymentBase
    {
        public PredecessorDeployment() : base(BYTECODE) { }
        public PredecessorDeployment(string byteCode) : base(byteCode) { }
    }

    public class PredecessorDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405234801561001057600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506001600060146101000a81548160ff0219169083600381111561007057fe5b0217905550610a8d806100846000396000f3006080604052600436106100af576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff16806305e88b69146100b45780632b68b9c6146100e3578063715018a6146101125780638456cb59146101295780638da5cb5b146101585780638e1a55fc146101af578063b0e31581146101de578063c040e6b814610217578063cc26839314610246578063da56eedb14610289578063f2fde38b146102e0575b600080fd5b3480156100c057600080fd5b506100c9610323565b604051808215151515815260200191505060405180910390f35b3480156100ef57600080fd5b506100f86103db565b604051808215151515815260200191505060405180910390f35b34801561011e57600080fd5b506101276104a6565b005b34801561013557600080fd5b5061013e6105a8565b604051808215151515815260200191505060405180910390f35b34801561016457600080fd5b5061016d61065f565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156101bb57600080fd5b506101c4610684565b604051808215151515815260200191505060405180910390f35b3480156101ea57600080fd5b506101f361073c565b6040518082600381111561020357fe5b60ff16815260200191505060405180910390f35b34801561022357600080fd5b5061022c61074f565b604051808215151515815260200191505060405180910390f35b34801561025257600080fd5b50610287600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610807565b005b34801561029557600080fd5b5061029e6108da565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156102ec57600080fd5b50610321600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610900565b005b60006002600381111561033257fe5b600060149054906101000a900460ff16600381111561034d57fe5b14151561035957600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156103b457600080fd5b6003600060146101000a81548160ff021916908360038111156103d357fe5b021790555090565b60006003808111156103e957fe5b600060149054906101000a900460ff16600381111561040457fe5b1415151561041157600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561046c57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16ff5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561050157600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482060405160405180910390a260008060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550565b60006003808111156105b657fe5b600060149054906101000a900460ff1660038111156105d157fe5b141515156105de57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561063957600080fd5b60008060146101000a81548160ff0219169083600381111561065757fe5b021790555090565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600060038081111561069257fe5b600060149054906101000a900460ff1660038111156106ad57fe5b141515156106ba57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561071557600080fd5b6001600060146101000a81548160ff0219169083600381111561073457fe5b021790555090565b600060149054906101000a900460ff1681565b600060038081111561075d57fe5b600060149054906101000a900460ff16600381111561077857fe5b1415151561078557600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156107e057600080fd5b6002600060146101000a81548160ff021916908360038111156107ff57fe5b021790555090565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561086257600080fd5b60038081111561086e57fe5b600060149054906101000a900460ff16600381111561088957fe5b1415151561089657600080fd5b80600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561095b57600080fd5b61096481610967565b50565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff16141515156109a357600080fd5b8073ffffffffffffffffffffffffffffffffffffffff166000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e060405160405180910390a3806000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550505600a165627a7a72305820646ab17bd7480402daed8a32eb232b5917f141b4cd4ab94d52545e19bd64b0eb0029";
        public PredecessorDeploymentBase() : base(BYTECODE) { }
        public PredecessorDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ProductionFunction : ProductionFunctionBase { }

    [Function("production", "bool")]
    public class ProductionFunctionBase : FunctionMessage
    {

    }

    public partial class DestructFunction : DestructFunctionBase { }

    [Function("destruct", "bool")]
    public class DestructFunctionBase : FunctionMessage
    {

    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class PauseFunction : PauseFunctionBase { }

    [Function("pause", "bool")]
    public class PauseFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class BuildFunction : BuildFunctionBase { }

    [Function("build", "bool")]
    public class BuildFunctionBase : FunctionMessage
    {

    }

    public partial class StagedModeFunction : StagedModeFunctionBase { }

    [Function("stagedMode", "uint8")]
    public class StagedModeFunctionBase : FunctionMessage
    {

    }

    public partial class StageFunction : StageFunctionBase { }

    [Function("stage", "bool")]
    public class StageFunctionBase : FunctionMessage
    {

    }

    public partial class DescendantFunction : DescendantFunctionBase { }

    [Function("descendant", "address")]
    public class DescendantFunctionBase : FunctionMessage
    {

    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "_newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class SetDescendantFunction : SetDescendantFunctionBase { }

    [Function("setDescendant")]
    public class SetDescendantFunctionBase : FunctionMessage
    {
        [Parameter("address", "_descendant", 1)]
        public virtual string Descendant { get; set; }
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



    public partial class DescendantOutputDTO : DescendantOutputDTOBase { }

    [FunctionOutput]
    public class DescendantOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }




}
