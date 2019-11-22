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

namespace Galleass3D.Contracts.Dogger.ContractDefinition
{


    public partial class DoggerDeployment : DoggerDeploymentBase
    {
        public DoggerDeployment() : base(BYTECODE) { }
        public DoggerDeployment(string byteCode) : base(byteCode) { }
    }

    public class DoggerDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405234801561001057600080fd5b506040516020806125498339810180604052810190808051906020019092919050505061003b6101c5565b81336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555080600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050608060405190810160405280600061ffff168152602001600061ffff168152602001600060ff168152602001600067ffffffffffffffff16815250905060058190806001815401808255809150509060018203906000526020600020016000909192909190915060008201518160000160006101000a81548161ffff021916908361ffff16021790555060208201518160000160026101000a81548161ffff021916908361ffff16021790555060408201518160000160046101000a81548160ff021916908360ff16021790555060608201518160000160056101000a81548167ffffffffffffffff021916908367ffffffffffffffff1602179055505050505050610203565b608060405190810160405280600061ffff168152602001600061ffff168152602001600060ff168152602001600067ffffffffffffffff1681525090565b612337806102126000396000f300608060405260043610610149576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff16806306fdde031461015b578063095ea7b3146101eb57806318160ddd146102385780631d36e06c1461026357806323b872dd146102d05780632ce643f21461033d5780632e1a7d4d146103945780633319bf1a146103d95780636352211e1461043457806370a08231146104a1578063715018a6146104f85780637a2a39311461050f5780638462151c1461057c5780638da5cb5b146106145780638e1a55fc1461066b57806395d89b41146106965780639e281a9814610726578063a8bd9c321461078b578063a9059cbb146107f8578063b0619e8514610845578063ba86943e146108ae578063ddc6a171146108e1578063e16c7d9814610946578063e4b50cb8146109b7578063f2fde38b14610a6a575b34801561015557600080fd5b50600080fd5b34801561016757600080fd5b50610170610aad565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156101b0578082015181840152602081019050610195565b50505050905090810190601f1680156101dd5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b3480156101f757600080fd5b50610236600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610ae6565b005b34801561024457600080fd5b5061024d610ba8565b6040518082815260200191505060405180910390f35b34801561026f57600080fd5b5061028e60048036038101908080359060200190929190505050610bb8565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156102dc57600080fd5b5061033b600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610beb565b005b34801561034957600080fd5b50610352610c9c565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156103a057600080fd5b506103bf60048036038101908080359060200190929190505050610cc2565b604051808215151515815260200191505060405180910390f35b3480156103e557600080fd5b5061041a600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610e97565b604051808215151515815260200191505060405180910390f35b34801561044057600080fd5b5061045f60048036038101908080359060200190929190505050610f3f565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156104ad57600080fd5b506104e2600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610fb8565b6040518082815260200191505060405180910390f35b34801561050457600080fd5b5061050d611001565b005b34801561051b57600080fd5b5061057a600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050611103565b005b34801561058857600080fd5b506105bd600480360381019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291905050506111d4565b6040518080602001828103825283818151815260200191508051906020019060200280838360005b838110156106005780820151818401526020810190506105e5565b505050509050019250505060405180910390f35b34801561062057600080fd5b50610629611321565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561067757600080fd5b50610680611346565b6040518082815260200191505060405180910390f35b3480156106a257600080fd5b506106ab6115a3565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156106eb5780820151818401526020810190506106d0565b50505050905090810190601f1680156107185780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561073257600080fd5b50610771600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001909291905050506115dc565b604051808215151515815260200191505060405180910390f35b34801561079757600080fd5b506107b660048036038101908080359060200190929190505050611812565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561080457600080fd5b50610843600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050611845565b005b34801561085157600080fd5b50610894600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080356000191690602001909291905050506118e0565b604051808215151515815260200191505060405180910390f35b3480156108ba57600080fd5b506108c36119f7565b604051808261ffff1661ffff16815260200191505060405180910390f35b3480156108ed57600080fd5b5061092c600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001909291905050506119fc565b604051808215151515815260200191505060405180910390f35b34801561095257600080fd5b506109756004803603810190808035600019169060200190929190505050611a10565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156109c357600080fd5b506109e260048036038101908080359060200190929190505050611af2565b604051808673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018561ffff1661ffff1681526020018461ffff1661ffff1681526020018360ff1660ff1681526020018267ffffffffffffffff1667ffffffffffffffff1681526020019550505050505060405180910390f35b348015610a7657600080fd5b50610aab600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050611bf2565b005b6040805190810160405280600f81526020017f47616c6c6561737320446f67676572000000000000000000000000000000000081525081565b610af03382611c59565b1515610afb57600080fd5b610b058183611cc5565b7fb497174632623317507c114082fd64c660b4313b9375d4c99fd6d9f5067079db338383604051808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001828152602001935050505060405180910390a15050565b6000600160058054905003905090565b60026020528060005260406000206000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515610c2757600080fd5b3073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515610c6257600080fd5b610c6c3382611d1b565b1515610c7757600080fd5b610c818382611c59565b1515610c8c57600080fd5b610c97838383611d87565b505050565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610d1f57600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905060016003811115610d5357fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b158015610db757600080fd5b505af1158015610dcb573d6000803e3d6000fd5b505050506040513d6020811015610de157600080fd5b81019080805190602001909291905050506003811115610dfd57fe5b141515610e0957600080fd5b823073ffffffffffffffffffffffffffffffffffffffff163110151515610e2f57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff166108fc849081150290604051600060405180830381858888f193505050501515610e8d57fe5b6001915050919050565b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610ef557600080fd5b81600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060019050919050565b60006002600083815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff169050600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff1614151515610fb357600080fd5b919050565b6000600360008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020549050919050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561105c57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482060405160405180910390a260008060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff161415151561113f57600080fd5b3073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff161415151561117a57600080fd5b6111848382611c59565b151561118f57600080fd5b6111b9337f7472616e73666572446f676765720000000000000000000000000000000000006118e0565b15156111c457600080fd5b6111cf838383611d87565b505050565b60606000606060008060006111e887610fb8565b9450600085141561122b5760006040519080825280602002602001820160405280156112235781602001602082028038833980820191505090505b509550611317565b8460405190808252806020026020018201604052801561125a5781602001602082028038833980820191505090505b509350611265610ba8565b925060009150600190505b8281111515611313578673ffffffffffffffffffffffffffffffffffffffff166002600083815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff161415611306578084838151811015156112ef57fe5b906020019060200201818152505081806001019250505b8080600101915050611270565b8395505b5050505050919050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b6000806000807f446f6767657200000000000000000000000000000000000000000000000000006000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b15801561140b57600080fd5b505af115801561141f573d6000803e3d6000fd5b505050506040513d602081101561143557600080fd5b810190808051906020019092919050505073ffffffffffffffffffffffffffffffffffffffff163073ffffffffffffffffffffffffffffffffffffffff1614151561147f57600080fd5b6114a9337f6275696c64446f676765720000000000000000000000000000000000000000006118e0565b15156114b457600080fd5b6114e4337f54696d6265720000000000000000000000000000000000000000000000000000600261ffff16611f89565b15156114ef57600080fd5b600194506102009350600192507f85243c881d389c1aacb9e09cc483800240118794218224ef60403c5f092c73ad33868686604051808573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018461ffff1661ffff1681526020018361ffff1661ffff1681526020018260ff1660ff16815260200194505050505060405180910390a1611599338686866120ae565b9550505050505090565b6040805190810160405280600881526020017f475f444f4747455200000000000000000000000000000000000000000000000081525081565b6000806000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561163a57600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690506001600381111561166e57fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b1580156116d257600080fd5b505af11580156116e6573d6000803e3d6000fd5b505050506040513d60208110156116fc57600080fd5b8101908080519060200190929190505050600381111561171857fe5b14151561172457600080fd5b8491508173ffffffffffffffffffffffffffffffffffffffff1663a9059cbb33866040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200182815260200192505050602060405180830381600087803b1580156117ca57600080fd5b505af11580156117de573d6000803e3d6000fd5b505050506040513d60208110156117f457600080fd5b81019080805190602001909291905050505060019250505092915050565b60046020528060005260406000206000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff161415151561188157600080fd5b3073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff16141515156118bc57600080fd5b6118c63382611c59565b15156118d157600080fd5b6118dc338383611d87565b5050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663b0619e8585856040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001826000191660001916815260200192505050602060405180830381600087803b1580156119b357600080fd5b505af11580156119c7573d6000803e3d6000fd5b505050506040513d60208110156119dd57600080fd5b810190808051906020019092919050505091505092915050565b600281565b6000611a088383611d1b565b905092915050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98846040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b158015611aaf57600080fd5b505af1158015611ac3573d6000803e3d6000fd5b505050506040513d6020811015611ad957600080fd5b8101908080519060200190929190505050915050919050565b60008060008060006002600087815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16600587815481101515611b3d57fe5b9060005260206000200160000160009054906101000a900461ffff16600588815481101515611b6857fe5b9060005260206000200160000160029054906101000a900461ffff16600589815481101515611b9357fe5b9060005260206000200160000160049054906101000a900460ff1660058a815481101515611bbd57fe5b9060005260206000200160000160059054906101000a900467ffffffffffffffff169450945094509450945091939590929450565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515611c4d57600080fd5b611c56816121d3565b50565b60008273ffffffffffffffffffffffffffffffffffffffff166002600084815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614905092915050565b806004600084815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055505050565b60008273ffffffffffffffffffffffffffffffffffffffff166004600084815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614905092915050565b600360008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008154809291906001019190505550816002600083815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550600073ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff16141515611ee557600360008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008154809291906001900391905055506004600082815260200190815260200160002060006101000a81549073ffffffffffffffffffffffffffffffffffffffff02191690555b7ffd19e66d1a4315847e95661bab80aff36f6801c5b2eeeca82491034bd7660abe838383604051808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001828152602001935050505060405180910390a1505050565b6000611f9483611a10565b73ffffffffffffffffffffffffffffffffffffffff166323b872dd8530856040518463ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018281526020019350505050602060405180830381600087803b15801561206a57600080fd5b505af115801561207e573d6000803e3d6000fd5b505050506040513d602081101561209457600080fd5b810190808051906020019092919050505090509392505050565b60006120b86122cd565b60006080604051908101604052808761ffff1681526020018661ffff1681526020018560ff1681526020014267ffffffffffffffff168152509150600160058390806001815401808255809150509060018203906000526020600020016000909192909190915060008201518160000160006101000a81548161ffff021916908361ffff16021790555060208201518160000160026101000a81548161ffff021916908361ffff16021790555060408201518160000160046101000a81548160ff021916908360ff16021790555060608201518160000160056101000a81548167ffffffffffffffff021916908367ffffffffffffffff16021790555050500390506121c660008883611d87565b8092505050949350505050565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff161415151561220f57600080fd5b8073ffffffffffffffffffffffffffffffffffffffff166000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e060405160405180910390a3806000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050565b608060405190810160405280600061ffff168152602001600061ffff168152602001600060ff168152602001600067ffffffffffffffff16815250905600a165627a7a72305820dc9fe389921620e8a7ecbf69dc7fedfb85ad86e2b06a272d89ef6b61758d92330029";
        public DoggerDeploymentBase() : base(BYTECODE) { }
        public DoggerDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_galleass", 1)]
        public virtual string Galleass { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TokenIndexToOwnerFunction : TokenIndexToOwnerFunctionBase { }

    [Function("tokenIndexToOwner", "address")]
    public class TokenIndexToOwnerFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "_to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
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

    public partial class OwnerOfFunction : OwnerOfFunctionBase { }

    [Function("ownerOf", "address")]
    public class OwnerOfFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
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

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
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

    public partial class TokenIndexToApprovedFunction : TokenIndexToApprovedFunctionBase { }

    [Function("tokenIndexToApproved", "address")]
    public class TokenIndexToApprovedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("transfer")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
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

    public partial class TIMBERTOBUILDFunction : TIMBERTOBUILDFunctionBase { }

    [Function("TIMBERTOBUILD", "uint16")]
    public class TIMBERTOBUILDFunctionBase : FunctionMessage
    {

    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "bool")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "_claimant", 1)]
        public virtual string Claimant { get; set; }
        [Parameter("uint256", "_tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
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

    public partial class BuildFunction : BuildFunctionBase { }

    [Function("build", "uint256")]
    public class BuildFunctionBase : FunctionMessage
    {

    }

    public partial class GalleassetTransferFromFunction : GalleassetTransferFromFunctionBase { }

    [Function("galleassetTransferFrom")]
    public class GalleassetTransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "_to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class GetTokenFunction : GetTokenFunctionBase { }

    [Function("getToken", typeof(GetTokenOutputDTO))]
    public class GetTokenFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_id", 1)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class TokensOfOwnerFunction : TokensOfOwnerFunctionBase { }

    [Function("tokensOfOwner", "uint256[]")]
    public class TokensOfOwnerFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class BuildEventDTO : BuildEventDTOBase { }

    [Event("Build")]
    public class BuildEventDTOBase : IEventDTO
    {
        [Parameter("address", "_sender", 1, false )]
        public virtual string Sender { get; set; }
        [Parameter("uint16", "strength", 2, false )]
        public virtual ushort Strength { get; set; }
        [Parameter("uint16", "speed", 3, false )]
        public virtual ushort Speed { get; set; }
        [Parameter("uint8", "luck", 4, false )]
        public virtual byte Luck { get; set; }
    }

    public partial class NFTTransferEventDTO : NFTTransferEventDTOBase { }

    [Event("NFTTransfer")]
    public class NFTTransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, false )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, false )]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3, false )]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class NFTApprovalEventDTO : NFTApprovalEventDTOBase { }

    [Event("NFTApproval")]
    public class NFTApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, false )]
        public virtual string Owner { get; set; }
        [Parameter("address", "approved", 2, false )]
        public virtual string Approved { get; set; }
        [Parameter("uint256", "tokenId", 3, false )]
        public virtual BigInteger TokenId { get; set; }
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



    public partial class TokenIndexToOwnerOutputDTO : TokenIndexToOwnerOutputDTOBase { }

    [FunctionOutput]
    public class TokenIndexToOwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class GalleassOutputDTO : GalleassOutputDTOBase { }

    [FunctionOutput]
    public class GalleassOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





    public partial class OwnerOfOutputDTO : OwnerOfOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "count", 1)]
        public virtual BigInteger Count { get; set; }
    }



    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class TokenIndexToApprovedOutputDTO : TokenIndexToApprovedOutputDTOBase { }

    [FunctionOutput]
    public class TokenIndexToApprovedOutputDTOBase : IFunctionOutputDTO 
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

    public partial class TIMBERTOBUILDOutputDTO : TIMBERTOBUILDOutputDTOBase { }

    [FunctionOutput]
    public class TIMBERTOBUILDOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint16", "", 1)]
        public virtual ushort ReturnValue1 { get; set; }
    }

    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
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







    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetTokenOutputDTO : GetTokenOutputDTOBase { }

    [FunctionOutput]
    public class GetTokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("uint16", "strength", 2)]
        public virtual ushort Strength { get; set; }
        [Parameter("uint16", "speed", 3)]
        public virtual ushort Speed { get; set; }
        [Parameter("uint8", "luck", 4)]
        public virtual byte Luck { get; set; }
        [Parameter("uint64", "birth", 5)]
        public virtual ulong Birth { get; set; }
    }

    public partial class TokensOfOwnerOutputDTO : TokensOfOwnerOutputDTOBase { }

    [FunctionOutput]
    public class TokensOfOwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[]", "", 1)]
        public virtual List<BigInteger> ReturnValue1 { get; set; }
    }
}
