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

namespace Galleass3D.Contracts.Galleass.ContractDefinition
{


    public partial class GalleassDeployment : GalleassDeploymentBase
    {
        public GalleassDeployment() : base(BYTECODE) { }
        public GalleassDeployment(string byteCode) : base(byteCode) { }
    }

    public class GalleassDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x60806040523480156200001157600080fd5b5060405162001f4b38038062001f4b83398101806040528101908080518201929190505050336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506001600060146101000a81548160ff021916908360038111156200009657fe5b0217905550620000b581620000bc640100000000026401000000009004565b50620001e3565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156200011857600080fd5b80600190805190602001906200013092919062000134565b5050565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106200017757805160ff1916838001178555620001a8565b82800160010185558215620001a8579182015b82811115620001a75782518255916020019190600101906200018a565b5b509050620001b79190620001bb565b5090565b620001e091905b80821115620001dc576000816000905550600101620001c2565b5090565b90565b611d5880620001f36000396000f300608060405260043610610128576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff16806305e88b691461012d57806306fdde031461015c5780632b68b9c6146101ec5780632e1a7d4d1461021b57806336f7ab5e146102605780633b424f09146102f0578063715018a6146103655780637ed77c9c1461037c5780638456cb59146103e55780638da5cb5b146104145780638e1a55fc1461046b5780639e281a981461049a578063a6c3e6b9146104ff578063b0619e851461058f578063b0e31581146105f8578063b967a52e14610631578063c040e6b81461069a578063cc268393146106c9578063da56eedb1461070c578063e16c7d9814610763578063eb2c0223146107d4578063f2fde38b1461082f575b600080fd5b34801561013957600080fd5b50610142610872565b604051808215151515815260200191505060405180910390f35b34801561016857600080fd5b5061017161092a565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156101b1578082015181840152602081019050610196565b50505050905090810190601f1680156101de5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b3480156101f857600080fd5b50610201610963565b604051808215151515815260200191505060405180910390f35b34801561022757600080fd5b5061024660048036038101908080359060200190929190505050610a2e565b604051808215151515815260200191505060405180910390f35b34801561026c57600080fd5b50610275610b18565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156102b557808201518184015260208101905061029a565b50505050905090810190601f1680156102e25780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b3480156102fc57600080fd5b5061034b600480360381019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291908035600019169060200190929190803515159060200190929190505050610bb6565b604051808215151515815260200191505060405180910390f35b34801561037157600080fd5b5061037a610d41565b005b34801561038857600080fd5b506103cb6004803603810190808035600019169060200190929190803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610e43565b604051808215151515815260200191505060405180910390f35b3480156103f157600080fd5b506103fa610fdf565b604051808215151515815260200191505060405180910390f35b34801561042057600080fd5b50610429611096565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561047757600080fd5b506104806110bb565b604051808215151515815260200191505060405180910390f35b3480156104a657600080fd5b506104e5600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050611173565b604051808215151515815260200191505060405180910390f35b34801561050b57600080fd5b506105146112be565b6040518080602001828103825283818151815260200191508051906020019080838360005b83811015610554578082015181840152602081019050610539565b50505050905090810190601f1680156105815780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561059b57600080fd5b506105de600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803560001916906020019092919050505061131e565b604051808215151515815260200191505060405180910390f35b34801561060457600080fd5b5061060d6114f5565b6040518082600381111561061d57fe5b60ff16815260200191505060405180910390f35b34801561063d57600080fd5b50610698600480360381019080803590602001908201803590602001908080601f0160208091040260200160405190810160405280939291908181526020018383808284378201915050505050509192919290505050611508565b005b3480156106a657600080fd5b506106af61157d565b604051808215151515815260200191505060405180910390f35b3480156106d557600080fd5b5061070a600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050611635565b005b34801561071857600080fd5b50610721611708565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561076f57600080fd5b50610792600480360381019080803560001916906020019092919050505061172e565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156107e057600080fd5b50610815600480360381019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291905050506118a6565b604051808215151515815260200191505060405180910390f35b34801561083b57600080fd5b50610870600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050611b26565b005b60006002600381111561088157fe5b600060149054906101000a900460ff16600381111561089c57fe5b1415156108a857600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561090357600080fd5b6003600060146101000a81548160ff0219169083600381111561092257fe5b021790555090565b6040805190810160405280600881526020017f47616c6c6561737300000000000000000000000000000000000000000000000081525081565b600060038081111561097157fe5b600060149054906101000a900460ff16600381111561098c57fe5b1415151561099957600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156109f457600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16ff5b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610a8b57600080fd5b813073ffffffffffffffffffffffffffffffffffffffff163110151515610ab157600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff166108fc839081150290604051600060405180830381858888f193505050501515610b0f57fe5b60019050919050565b60018054600181600116156101000203166002900480601f016020809104026020016040519081016040528092919081815260200182805460018160011615610100020316600290048015610bae5780601f10610b8357610100808354040283529160200191610bae565b820191906000526020600020905b815481529060010190602001808311610b9157829003601f168201915b505050505081565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610c1357600080fd5b60016003811115610c2057fe5b600060149054906101000a900460ff166003811115610c3b57fe5b141515610c4757600080fd5b81600460008673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206000856000191660001916815260200190815260200160002060006101000a81548160ff0219169083151502179055507fb842c2420390626d77bc21fcee7919720b98a4e11cdc34c7982633a598ba8265848484604051808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001836000191660001916815260200182151515158152602001935050505060405180910390a1600190509392505050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610d9c57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482060405160405180910390a260008060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610ea057600080fd5b60016003811115610ead57fe5b600060149054906101000a900460ff166003811115610ec857fe5b141515610ed457600080fd5b8160036000856000191660001916815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055507fb37bbf7809b7e317092a2eb447b6a453fcd8a75921c9b754ec29dffd407282428383336040518084600019166000191681526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001935050505060405180910390a16001905092915050565b6000600380811115610fed57fe5b600060149054906101000a900460ff16600381111561100857fe5b1415151561101557600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561107057600080fd5b60008060146101000a81548160ff0219169083600381111561108e57fe5b021790555090565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60006003808111156110c957fe5b600060149054906101000a900460ff1660038111156110e457fe5b141515156110f157600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561114c57600080fd5b6001600060146101000a81548160ff0219169083600381111561116b57fe5b021790555090565b6000806000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156111d157600080fd5b8390508073ffffffffffffffffffffffffffffffffffffffff1663a9059cbb33856040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200182815260200192505050602060405180830381600087803b15801561127757600080fd5b505af115801561128b573d6000803e3d6000fd5b505050506040513d60208110156112a157600080fd5b810190808051906020019092919050505050600191505092915050565b606060405190810160405280602481526020017f54686f6d61732048616c6c65722074686f6d61732e68616c6c6572406c61623181526020017f302e696f0000000000000000000000000000000000000000000000000000000081525081565b60008073ffffffffffffffffffffffffffffffffffffffff16600260009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614151561148657600260009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1663b0619e8584846040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001826000191660001916815260200192505050602060405180830381600087803b15801561144457600080fd5b505af1158015611458573d6000803e3d6000fd5b505050506040513d602081101561146e57600080fd5b810190808051906020019092919050505090506114ef565b600460008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206000836000191660001916815260200190815260200160002060009054906101000a900460ff1690505b92915050565b600060149054906101000a900460ff1681565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561156357600080fd5b8060019080519060200190611579929190611c87565b5050565b600060038081111561158b57fe5b600060149054906101000a900460ff1660038111156115a657fe5b141515156115b357600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561160e57600080fd5b6002600060146101000a81548160ff0219169083600381111561162d57fe5b021790555090565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561169057600080fd5b60038081111561169c57fe5b600060149054906101000a900460ff1660038111156116b757fe5b141515156116c457600080fd5b80600260006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050565b600260009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60008073ffffffffffffffffffffffffffffffffffffffff16600260009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614151561186257600260009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b15801561182057600080fd5b505af1158015611834573d6000803e3d6000fd5b505050506040513d602081101561184a57600080fd5b810190808051906020019092919050505090506118a1565b60036000836000191660001916815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690505b919050565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561190357600080fd5b6001600381111561191057fe5b600060149054906101000a900460ff16600381111561192b57fe5b14151561193757600080fd5b8173ffffffffffffffffffffffffffffffffffffffff16633319bf1a600260009054906101000a900473ffffffffffffffffffffffffffffffffffffffff166040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001915050602060405180830381600087803b1580156119f457600080fd5b505af1158015611a08573d6000803e3d6000fd5b505050506040513d6020811015611a1e57600080fd5b8101908080519060200190929190505050507f7b563a648f580bb883395153219ac9f16d4acd407bd8bf47e4486fd9f58b840d82600260009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1633604051808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001935050505060405180910390a160019050919050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515611b8157600080fd5b611b8a81611b8d565b50565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff1614151515611bc957600080fd5b8073ffffffffffffffffffffffffffffffffffffffff166000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e060405160405180910390a3806000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f10611cc857805160ff1916838001178555611cf6565b82800160010185558215611cf6579182015b82811115611cf5578251825591602001919060010190611cda565b5b509050611d039190611d07565b5090565b611d2991905b80821115611d25576000816000905550600101611d0d565b5090565b905600a165627a7a723058202ac9d2937c219d1904988f634b3988cbb378cfa72cefa019200e5b067aee03560029";
        public GalleassDeploymentBase() : base(BYTECODE) { }
        public GalleassDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("string", "_contact", 1)]
        public virtual string Contact { get; set; }
    }

    public partial class ProductionFunction : ProductionFunctionBase { }

    [Function("production", "bool")]
    public class ProductionFunctionBase : FunctionMessage
    {

    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class DestructFunction : DestructFunctionBase { }

    [Function("destruct", "bool")]
    public class DestructFunctionBase : FunctionMessage
    {

    }

    public partial class ContactInformationFunction : ContactInformationFunctionBase { }

    [Function("contactInformation", "string")]
    public class ContactInformationFunctionBase : FunctionMessage
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

    public partial class AuthorFunction : AuthorFunctionBase { }

    [Function("author", "string")]
    public class AuthorFunctionBase : FunctionMessage
    {

    }

    public partial class StagedModeFunction : StagedModeFunctionBase { }

    [Function("stagedMode", "uint8")]
    public class StagedModeFunctionBase : FunctionMessage
    {

    }

    public partial class SetContactInformationFunction : SetContactInformationFunctionBase { }

    [Function("setContactInformation")]
    public class SetContactInformationFunctionBase : FunctionMessage
    {
        [Parameter("string", "_info", 1)]
        public virtual string Info { get; set; }
    }

    public partial class StageFunction : StageFunctionBase { }

    [Function("stage", "bool")]
    public class StageFunctionBase : FunctionMessage
    {

    }

    public partial class SetDescendantFunction : SetDescendantFunctionBase { }

    [Function("setDescendant")]
    public class SetDescendantFunctionBase : FunctionMessage
    {
        [Parameter("address", "_descendant", 1)]
        public virtual string Descendant { get; set; }
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

    public partial class UpgradeContractFunction : UpgradeContractFunctionBase { }

    [Function("upgradeContract", "bool")]
    public class UpgradeContractFunctionBase : FunctionMessage
    {
        [Parameter("address", "_contract", 1)]
        public virtual string Contract { get; set; }
    }

    public partial class SetContractFunction : SetContractFunctionBase { }

    [Function("setContract", "bool")]
    public class SetContractFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_name", 1)]
        public virtual byte[] Name { get; set; }
        [Parameter("address", "_contract", 2)]
        public virtual string Contract { get; set; }
    }

    public partial class SetPermissionFunction : SetPermissionFunctionBase { }

    [Function("setPermission", "bool")]
    public class SetPermissionFunctionBase : FunctionMessage
    {
        [Parameter("address", "_contract", 1)]
        public virtual string Contract { get; set; }
        [Parameter("bytes32", "_permission", 2)]
        public virtual byte[] Permission { get; set; }
        [Parameter("bool", "_value", 3)]
        public virtual bool Value { get; set; }
    }

    public partial class GetContractFunction : GetContractFunctionBase { }

    [Function("getContract", "address")]
    public class GetContractFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_name", 1)]
        public virtual byte[] Name { get; set; }
    }

    public partial class HasPermissionFunction : HasPermissionFunctionBase { }

    [Function("hasPermission", "bool")]
    public class HasPermissionFunctionBase : FunctionMessage
    {
        [Parameter("address", "_contract", 1)]
        public virtual string Contract { get; set; }
        [Parameter("bytes32", "_permission", 2)]
        public virtual byte[] Permission { get; set; }
    }

    public partial class WithdrawFunction : WithdrawFunctionBase { }

    [Function("withdraw", "bool")]
    public class WithdrawFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class WithdrawTokenFunction : WithdrawTokenFunctionBase { }

    [Function("withdrawToken", "bool")]
    public class WithdrawTokenFunctionBase : FunctionMessage
    {
        [Parameter("address", "_token", 1)]
        public virtual string Token { get; set; }
        [Parameter("uint256", "_amount", 2)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class UpgradeContractEventDTO : UpgradeContractEventDTOBase { }

    [Event("UpgradeContract")]
    public class UpgradeContractEventDTOBase : IEventDTO
    {
        [Parameter("address", "_contractAddress", 1, false )]
        public virtual string ContractAddress { get; set; }
        [Parameter("address", "_descendant", 2, false )]
        public virtual string Descendant { get; set; }
        [Parameter("address", "_whoDid", 3, false )]
        public virtual string WhoDid { get; set; }
    }

    public partial class SetContractEventDTO : SetContractEventDTOBase { }

    [Event("SetContract")]
    public class SetContractEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "_name", 1, false )]
        public virtual byte[] Name { get; set; }
        [Parameter("address", "_contractAddress", 2, false )]
        public virtual string ContractAddress { get; set; }
        [Parameter("address", "_whoDid", 3, false )]
        public virtual string WhoDid { get; set; }
    }

    public partial class SetPermissionEventDTO : SetPermissionEventDTOBase { }

    [Event("SetPermission")]
    public class SetPermissionEventDTOBase : IEventDTO
    {
        [Parameter("address", "_account", 1, false )]
        public virtual string Account { get; set; }
        [Parameter("bytes32", "_permission", 2, false )]
        public virtual byte[] Permission { get; set; }
        [Parameter("bool", "_value", 3, false )]
        public virtual bool Value { get; set; }
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



    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class ContactInformationOutputDTO : ContactInformationOutputDTOBase { }

    [FunctionOutput]
    public class ContactInformationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class AuthorOutputDTO : AuthorOutputDTOBase { }

    [FunctionOutput]
    public class AuthorOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
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









    public partial class GetContractOutputDTO : GetContractOutputDTOBase { }

    [FunctionOutput]
    public class GetContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class HasPermissionOutputDTO : HasPermissionOutputDTOBase { }

    [FunctionOutput]
    public class HasPermissionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }




}
