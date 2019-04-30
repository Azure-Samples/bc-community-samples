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

namespace Galleass3D.Contracts.Sea.ContractDefinition
{


    public partial class SeaDeployment : SeaDeploymentBase
    {
        public SeaDeployment() : base(BYTECODE) { }
        public SeaDeployment(string byteCode) : base(byteCode) { }
    }

    public class SeaDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x60806040526000600160146101000a81548160ff021916908360ff16021790555034801561002c57600080fd5b506040516020806117e18339810180604052810190808051906020019092919050505080336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555080600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050506116ff806100e26000396000f3006080604052600436106100af576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680632ce643f2146100b45780632e1a7d4d1461010b5780633319bf1a14610150578063715018a6146101ab5780637a1091ea146101c25780638da5cb5b146103085780639779f9241461035f5780639e281a98146103ee578063b0619e8514610453578063e16c7d98146104bc578063f2fde38b1461052d575b600080fd5b3480156100c057600080fd5b506100c9610570565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561011757600080fd5b5061013660048036038101908080359060200190929190505050610596565b604051808215151515815260200191505060405180910390f35b34801561015c57600080fd5b50610191600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919050505061076b565b604051808215151515815260200191505060405180910390f35b3480156101b757600080fd5b506101c0610813565b005b3480156101ce57600080fd5b5061020d600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610915565b604051808d81526020018c73ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018b73ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018a151515158152602001891515151581526020018861ffff1661ffff1681526020018761ffff1661ffff1681526020018661ffff1661ffff1681526020018561ffff1661ffff1681526020018461ffff1661ffff1681526020018361ffff1661ffff1681526020018261ffff1661ffff1681526020019c5050505050505050505050505060405180910390f35b34801561031457600080fd5b5061031d610a3e565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561036b57600080fd5b506103d4600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190803561ffff169060200190929190803561ffff169060200190929190803561ffff169060200190929190505050610a63565b604051808215151515815260200191505060405180910390f35b3480156103fa57600080fd5b50610439600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050611019565b604051808215151515815260200191505060405180910390f35b34801561045f57600080fd5b506104a2600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803560001916906020019092919050505061124f565b604051808215151515815260200191505060405180910390f35b3480156104c857600080fd5b506104eb6004803603810190808035600019169060200190929190505050611366565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561053957600080fd5b5061056e600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050611448565b005b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156105f357600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690506001600381111561062757fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b15801561068b57600080fd5b505af115801561069f573d6000803e3d6000fd5b505050506040513d60208110156106b557600080fd5b810190808051906020019092919050505060038111156106d157fe5b1415156106dd57600080fd5b823073ffffffffffffffffffffffffffffffffffffffff16311015151561070357600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff166108fc849081150290604051600060405180830381858888f19350505050151561076157fe5b6001915050919050565b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156107c957600080fd5b81600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060019050919050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561086e57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482060405160405180910390a260008060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550565b6002602052816000526040600020602052806000526040600020600091509150508060000154908060010160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060020160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16908060020160149054906101000a900460ff16908060020160159054906101000a900460ff16908060020160169054906101000a900461ffff16908060020160189054906101000a900461ffff169080600201601a9054906101000a900461ffff169080600201601c9054906101000a900461ffff169080600201601e9054906101000a900461ffff16908060030160009054906101000a900461ffff16908060030160029054906101000a900461ffff1690508c565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b6000806000807f53656100000000000000000000000000000000000000000000000000000000006000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b158015610b2857600080fd5b505af1158015610b3c573d6000803e3d6000fd5b505050506040513d6020811015610b5257600080fd5b810190808051906020019092919050505073ffffffffffffffffffffffffffffffffffffffff163073ffffffffffffffffffffffffffffffffffffffff16141515610b9c57600080fd5b600260008c73ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008b815260200190815260200160002060020160149054906101000a900460ff16151515610c0957600080fd5b610c33337f656d6261726b536869707300000000000000000000000000000000000000000061124f565b1515610c3e57600080fd5b600260008c73ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008b815260200190815260200160002094508985600001819055508a8560010160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060018560020160146101000a81548160ff02191690831515021790555060008560020160156101000a81548160ff021916908315150217905550888560020160166101000a81548161ffff021916908361ffff160217905550878560020160186101000a81548161ffff021916908361ffff1602179055508685600201601a6101000a81548161ffff021916908361ffff1602179055508a93508373ffffffffffffffffffffffffffffffffffffffff16636352211e8b6040518263ffffffff167c010000000000000000000000000000000000000000000000000000000002815260040180828152602001915050602060405180830381600087803b158015610de557600080fd5b505af1158015610df9573d6000803e3d6000fd5b505050506040513d6020811015610e0f57600080fd5b810190808051906020019092919050505092506110078b8b85886101806040519081016040529081600082015481526020016001820160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020016002820160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020016002820160149054906101000a900460ff161515151581526020016002820160159054906101000a900460ff161515151581526020016002820160169054906101000a900461ffff1661ffff1661ffff1681526020016002820160189054906101000a900461ffff1661ffff1661ffff16815260200160028201601a9054906101000a900461ffff1661ffff1661ffff16815260200160028201601c9054906101000a900461ffff1661ffff1661ffff16815260200160028201601e9054906101000a900461ffff1661ffff1661ffff1681526020016003820160009054906101000a900461ffff1661ffff1661ffff1681526020016003820160029054906101000a900461ffff1661ffff1661ffff16815250506114af565b60019550505050505095945050505050565b6000806000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561107757600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff169050600160038111156110ab57fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b15801561110f57600080fd5b505af1158015611123573d6000803e3d6000fd5b505050506040513d602081101561113957600080fd5b8101908080519060200190929190505050600381111561115557fe5b14151561116157600080fd5b8491508173ffffffffffffffffffffffffffffffffffffffff1663a9059cbb33866040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200182815260200192505050602060405180830381600087803b15801561120757600080fd5b505af115801561121b573d6000803e3d6000fd5b505050506040513d602081101561123157600080fd5b81019080805190602001909291905050505060019250505092915050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663b0619e8585856040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001826000191660001916815260200192505050602060405180830381600087803b15801561132257600080fd5b505af1158015611336573d6000803e3d6000fd5b505050506040513d602081101561134c57600080fd5b810190808051906020019092919050505091505092915050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98846040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b15801561140557600080fd5b505af1158015611419573d6000803e3d6000fd5b505050506040513d602081101561142f57600080fd5b8101908080519060200190929190505050915050919050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156114a357600080fd5b6114ac816115d9565b50565b8060c0015161ffff168160a0015161ffff168373ffffffffffffffffffffffffffffffffffffffff167f77fac33f8b645a9b9465f6761d518168a950417432328f6d53b19cb20d8f82c8428789876060015188608001518960e001518a61010001518b61012001518c61014001518d6101600151604051808b81526020018a81526020018973ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200188151515158152602001871515151581526020018661ffff1661ffff1681526020018561ffff1661ffff1681526020018461ffff1661ffff1681526020018361ffff1661ffff1681526020018261ffff1661ffff1681526020019a505050505050505050505060405180910390a450505050565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff161415151561161557600080fd5b8073ffffffffffffffffffffffffffffffffffffffff166000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e060405160405180910390a3806000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550505600a165627a7a723058200200c86c8fd9c20a47e2bec377d4a4073b6d17f74327579ba6282086f65d0d210029";
        public SeaDeploymentBase() : base(BYTECODE) { }
        public SeaDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_galleass", 1)]
        public virtual string Galleass { get; set; }
    }

    public partial class GalleassFunction : GalleassFunctionBase { }

    [Function("galleass", "address")]
    public class GalleassFunctionBase : FunctionMessage
    {

    }

    public partial class WithdrawFunction : WithdrawFunctionBase { }

    [Function("withdraw", "bool")]
    public class WithdrawFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class UpgradeGalleassFunction : UpgradeGalleassFunctionBase { }

    [Function("upgradeGalleass", "bool")]
    public class UpgradeGalleassFunctionBase : FunctionMessage
    {
        [Parameter("address", "_galleass", 1)]
        public virtual string Galleass { get; set; }
    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class ShipsFunction : ShipsFunctionBase { }

    [Function("ships", typeof(ShipsOutputDTO))]
    public class ShipsFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("uint256", "", 2)]
        public virtual BigInteger ReturnValue2 { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

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

    public partial class HasPermissionFunction : HasPermissionFunctionBase { }

    [Function("hasPermission", "bool")]
    public class HasPermissionFunctionBase : FunctionMessage
    {
        [Parameter("address", "_contract", 1)]
        public virtual string Contract { get; set; }
        [Parameter("bytes32", "_permission", 2)]
        public virtual byte[] Permission { get; set; }
    }

    public partial class GetContractFunction : GetContractFunctionBase { }

    [Function("getContract", "address")]
    public class GetContractFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_name", 1)]
        public virtual byte[] Name { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "_newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class EmbarkFunction : EmbarkFunctionBase { }

    [Function("embark", "bool")]
    public class EmbarkFunctionBase : FunctionMessage
    {
        [Parameter("address", "_contract", 1)]
        public virtual string Contract { get; set; }
        [Parameter("uint256", "_shipId", 2)]
        public virtual BigInteger ShipId { get; set; }
        [Parameter("uint16", "_x", 3)]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "_y", 4)]
        public virtual ushort Y { get; set; }
        [Parameter("uint16", "_location", 5)]
        public virtual ushort Location { get; set; }
    }

    public partial class ShipUpdateEventDTO : ShipUpdateEventDTOBase { }

    [Event("ShipUpdate")]
    public class ShipUpdateEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "timestamp", 1, false )]
        public virtual BigInteger Timestamp { get; set; }
        [Parameter("uint256", "id", 2, false )]
        public virtual BigInteger Id { get; set; }
        [Parameter("address", "contractAddress", 3, false )]
        public virtual string ContractAddress { get; set; }
        [Parameter("address", "owner", 4, true )]
        public virtual string Owner { get; set; }
        [Parameter("bool", "floating", 5, false )]
        public virtual bool Floating { get; set; }
        [Parameter("bool", "sailing", 6, false )]
        public virtual bool Sailing { get; set; }
        [Parameter("uint16", "x", 7, true )]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "y", 8, true )]
        public virtual ushort Y { get; set; }
        [Parameter("uint16", "location", 9, false )]
        public virtual ushort Location { get; set; }
        [Parameter("uint16", "destX", 10, false )]
        public virtual ushort DestX { get; set; }
        [Parameter("uint16", "destY", 11, false )]
        public virtual ushort DestY { get; set; }
        [Parameter("uint16", "destLocation", 12, false )]
        public virtual ushort DestLocation { get; set; }
        [Parameter("uint16", "destBlock", 13, false )]
        public virtual ushort DestBlock { get; set; }
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

    public partial class GalleassOutputDTO : GalleassOutputDTOBase { }

    [FunctionOutput]
    public class GalleassOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }







    public partial class ShipsOutputDTO : ShipsOutputDTOBase { }

    [FunctionOutput]
    public class ShipsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("address", "contractAddress", 2)]
        public virtual string ContractAddress { get; set; }
        [Parameter("address", "owner", 3)]
        public virtual string Owner { get; set; }
        [Parameter("bool", "floating", 4)]
        public virtual bool Floating { get; set; }
        [Parameter("bool", "sailing", 5)]
        public virtual bool Sailing { get; set; }
        [Parameter("uint16", "x", 6)]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "y", 7)]
        public virtual ushort Y { get; set; }
        [Parameter("uint16", "location", 8)]
        public virtual ushort Location { get; set; }
        [Parameter("uint16", "destX", 9)]
        public virtual ushort DestX { get; set; }
        [Parameter("uint16", "destY", 10)]
        public virtual ushort DestY { get; set; }
        [Parameter("uint16", "destLocation", 11)]
        public virtual ushort DestLocation { get; set; }
        [Parameter("uint16", "destBlock", 12)]
        public virtual ushort DestBlock { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
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

    public partial class GetContractOutputDTO : GetContractOutputDTOBase { }

    [FunctionOutput]
    public class GetContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }




}
