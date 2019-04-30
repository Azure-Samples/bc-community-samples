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

namespace Galleass3D.Contracts.Schooner.ContractDefinition
{


    public partial class SchoonerDeployment : SchoonerDeploymentBase
    {
        public SchoonerDeployment() : base(BYTECODE) { }
        public SchoonerDeployment(string byteCode) : base(byteCode) { }
    }

    public class SchoonerDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405234801561001057600080fd5b5060405160208061273d8339810180604052810190808051906020019092919050505061003b610221565b81336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555080600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055505060c060405190810160405280600061ffff168152602001600061ffff168152602001600060ff168152602001600061ffff168152602001600061ffff168152602001600067ffffffffffffffff16815250905060058190806001815401808255809150509060018203906000526020600020016000909192909190915060008201518160000160006101000a81548161ffff021916908361ffff16021790555060208201518160000160026101000a81548161ffff021916908361ffff16021790555060408201518160000160046101000a81548160ff021916908360ff16021790555060608201518160000160056101000a81548161ffff021916908361ffff16021790555060808201518160000160076101000a81548161ffff021916908361ffff16021790555060a08201518160000160096101000a81548167ffffffffffffffff021916908367ffffffffffffffff1602179055505050505050610275565b60c060405190810160405280600061ffff168152602001600061ffff168152602001600060ff168152602001600061ffff168152602001600061ffff168152602001600067ffffffffffffffff1681525090565b6124b9806102846000396000f300608060405260043610610154576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff16806306fdde0314610166578063095ea7b3146101f657806318160ddd146102435780631d36e06c1461026e57806323b872dd146102db5780632ce643f2146103485780632e1a7d4d1461039f5780633319bf1a146103e45780636352211e1461043f57806370a08231146104ac578063715018a6146105035780637a2a39311461051a5780638462151c146105875780638da5cb5b1461061f5780638e1a55fc1461067657806395d89b41146106a15780639e281a9814610731578063a8bd9c3214610796578063a9059cbb14610803578063b0619e8514610850578063ba86943e146108b9578063ddc6a171146108ec578063e16c7d9814610951578063e4b50cb8146109c2578063f2fde38b14610a93578063f3ccaac014610ad6575b34801561016057600080fd5b50600080fd5b34801561017257600080fd5b5061017b610b09565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156101bb5780820151818401526020810190506101a0565b50505050905090810190601f1680156101e85780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561020257600080fd5b50610241600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610b42565b005b34801561024f57600080fd5b50610258610c04565b6040518082815260200191505060405180910390f35b34801561027a57600080fd5b5061029960048036038101908080359060200190929190505050610c14565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156102e757600080fd5b50610346600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610c47565b005b34801561035457600080fd5b5061035d610cf8565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156103ab57600080fd5b506103ca60048036038101908080359060200190929190505050610d1e565b604051808215151515815260200191505060405180910390f35b3480156103f057600080fd5b50610425600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610ef3565b604051808215151515815260200191505060405180910390f35b34801561044b57600080fd5b5061046a60048036038101908080359060200190929190505050610f9b565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156104b857600080fd5b506104ed600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050611014565b6040518082815260200191505060405180910390f35b34801561050f57600080fd5b5061051861105d565b005b34801561052657600080fd5b50610585600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff1690602001909291908035906020019092919050505061115f565b005b34801561059357600080fd5b506105c8600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050611230565b6040518080602001828103825283818151815260200191508051906020019060200280838360005b8381101561060b5780820151818401526020810190506105f0565b505050509050019250505060405180910390f35b34801561062b57600080fd5b5061063461137d565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561068257600080fd5b5061068b6113a2565b6040518082815260200191505060405180910390f35b3480156106ad57600080fd5b506106b6611630565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156106f65780820151818401526020810190506106db565b50505050905090810190601f1680156107235780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561073d57600080fd5b5061077c600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050611669565b604051808215151515815260200191505060405180910390f35b3480156107a257600080fd5b506107c16004803603810190808035906020019092919050505061189f565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561080f57600080fd5b5061084e600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001909291905050506118d2565b005b34801561085c57600080fd5b5061089f600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803560001916906020019092919050505061196d565b604051808215151515815260200191505060405180910390f35b3480156108c557600080fd5b506108ce611a84565b604051808261ffff1661ffff16815260200191505060405180910390f35b3480156108f857600080fd5b50610937600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050611a89565b604051808215151515815260200191505060405180910390f35b34801561095d57600080fd5b506109806004803603810190808035600019169060200190929190505050611a9d565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156109ce57600080fd5b506109ed60048036038101908080359060200190929190505050611b7f565b604051808873ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018761ffff1661ffff1681526020018661ffff1661ffff1681526020018560ff1660ff1681526020018461ffff1661ffff1681526020018361ffff1661ffff1681526020018267ffffffffffffffff1667ffffffffffffffff16815260200197505050505050505060405180910390f35b348015610a9f57600080fd5b50610ad4600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050611cde565b005b348015610ae257600080fd5b50610aeb611d45565b60405180826000191660001916815260200191505060405180910390f35b6040805190810160405280601181526020017f47616c6c65617373205363686f6f6e657200000000000000000000000000000081525081565b610b4c3382611d69565b1515610b5757600080fd5b610b618183611dd5565b7fb497174632623317507c114082fd64c660b4313b9375d4c99fd6d9f5067079db338383604051808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001828152602001935050505060405180910390a15050565b6000600160058054905003905090565b60026020528060005260406000206000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515610c8357600080fd5b3073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515610cbe57600080fd5b610cc83382611e2b565b1515610cd357600080fd5b610cdd8382611d69565b1515610ce857600080fd5b610cf3838383611e97565b505050565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610d7b57600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905060016003811115610daf57fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b158015610e1357600080fd5b505af1158015610e27573d6000803e3d6000fd5b505050506040513d6020811015610e3d57600080fd5b81019080805190602001909291905050506003811115610e5957fe5b141515610e6557600080fd5b823073ffffffffffffffffffffffffffffffffffffffff163110151515610e8b57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff166108fc849081150290604051600060405180830381858888f193505050501515610ee957fe5b6001915050919050565b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610f5157600080fd5b81600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060019050919050565b60006002600083815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff169050600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff161415151561100f57600080fd5b919050565b6000600360008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020549050919050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156110b857600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482060405160405180910390a260008060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff161415151561119b57600080fd5b3073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff16141515156111d657600080fd5b6111e08382611d69565b15156111eb57600080fd5b611215337f7472616e736665725363686f6f6e65720000000000000000000000000000000061196d565b151561122057600080fd5b61122b838383611e97565b505050565b606060006060600080600061124487611014565b9450600085141561128757600060405190808252806020026020018201604052801561127f5781602001602082028038833980820191505090505b509550611373565b846040519080825280602002602001820160405280156112b65781602001602082028038833980820191505090505b5093506112c1610c04565b925060009150600190505b828111151561136f578673ffffffffffffffffffffffffffffffffffffffff166002600083815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614156113625780848381518110151561134b57fe5b906020019060200201818152505081806001019250505b80806001019150506112cc565b8395505b5050505050919050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b6000806000806000807f5363686f6f6e65720000000000000000000000000000000000000000000000006000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b15801561146a57600080fd5b505af115801561147e573d6000803e3d6000fd5b505050506040513d602081101561149457600080fd5b810190808051906020019092919050505073ffffffffffffffffffffffffffffffffffffffff163073ffffffffffffffffffffffffffffffffffffffff161415156114de57600080fd5b611508337f6275696c645363686f6f6e65720000000000000000000000000000000000000061196d565b151561151357600080fd5b611543337f54696d6265720000000000000000000000000000000000000000000000000000600661ffff16612099565b151561154e57600080fd5b60049650610600955060019450610200935061020092507fff2425612e81cfb145af3e470a1d1f4bc7e7ea5fd0e9e0ff72ea92201b0a3e5c338888888888604051808773ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018661ffff1661ffff1681526020018561ffff1661ffff1681526020018460ff1660ff1681526020018361ffff1661ffff1681526020018261ffff1661ffff168152602001965050505050505060405180910390a16116243388888888886121be565b97505050505050505090565b6040805190810160405280600a81526020017f475f5343484f4f4e45520000000000000000000000000000000000000000000081525081565b6000806000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116c757600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff169050600160038111156116fb57fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b15801561175f57600080fd5b505af1158015611773573d6000803e3d6000fd5b505050506040513d602081101561178957600080fd5b810190808051906020019092919050505060038111156117a557fe5b1415156117b157600080fd5b8491508173ffffffffffffffffffffffffffffffffffffffff1663a9059cbb33866040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200182815260200192505050602060405180830381600087803b15801561185757600080fd5b505af115801561186b573d6000803e3d6000fd5b505050506040513d602081101561188157600080fd5b81019080805190602001909291905050505060019250505092915050565b60046020528060005260406000206000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff161415151561190e57600080fd5b3073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff161415151561194957600080fd5b6119533382611d69565b151561195e57600080fd5b611969338383611e97565b5050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663b0619e8585856040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001826000191660001916815260200192505050602060405180830381600087803b158015611a4057600080fd5b505af1158015611a54573d6000803e3d6000fd5b505050506040513d6020811015611a6a57600080fd5b810190808051906020019092919050505091505092915050565b600681565b6000611a958383611e2b565b905092915050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98846040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b158015611b3c57600080fd5b505af1158015611b50573d6000803e3d6000fd5b505050506040513d6020811015611b6657600080fd5b8101908080519060200190929190505050915050919050565b60008060008060008060006002600089815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16600589815481101515611bcd57fe5b9060005260206000200160000160009054906101000a900461ffff1660058a815481101515611bf857fe5b9060005260206000200160000160029054906101000a900461ffff1660058b815481101515611c2357fe5b9060005260206000200160000160049054906101000a900460ff1660058c815481101515611c4d57fe5b9060005260206000200160000160059054906101000a900461ffff1660058d815481101515611c7857fe5b9060005260206000200160000160079054906101000a900461ffff1660058e815481101515611ca357fe5b9060005260206000200160000160099054906101000a900467ffffffffffffffff169650965096509650965096509650919395979092949650565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515611d3957600080fd5b611d428161233f565b50565b7f7363686f6f6e657200000000000000000000000000000000000000000000000081565b60008273ffffffffffffffffffffffffffffffffffffffff166002600084815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614905092915050565b806004600084815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055505050565b60008273ffffffffffffffffffffffffffffffffffffffff166004600084815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614905092915050565b600360008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008154809291906001019190505550816002600083815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550600073ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff16141515611ff557600360008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008154809291906001900391905055506004600082815260200190815260200160002060006101000a81549073ffffffffffffffffffffffffffffffffffffffff02191690555b7ffd19e66d1a4315847e95661bab80aff36f6801c5b2eeeca82491034bd7660abe838383604051808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001828152602001935050505060405180910390a1505050565b60006120a483611a9d565b73ffffffffffffffffffffffffffffffffffffffff166323b872dd8530856040518463ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018281526020019350505050602060405180830381600087803b15801561217a57600080fd5b505af115801561218e573d6000803e3d6000fd5b505050506040513d60208110156121a457600080fd5b810190808051906020019092919050505090509392505050565b60006121c8612439565b600060c0604051908101604052808961ffff1681526020018861ffff1681526020018760ff1681526020018661ffff1681526020018561ffff1681526020014267ffffffffffffffff168152509150600160058390806001815401808255809150509060018203906000526020600020016000909192909190915060008201518160000160006101000a81548161ffff021916908361ffff16021790555060208201518160000160026101000a81548161ffff021916908361ffff16021790555060408201518160000160046101000a81548160ff021916908360ff16021790555060608201518160000160056101000a81548161ffff021916908361ffff16021790555060808201518160000160076101000a81548161ffff021916908361ffff16021790555060a08201518160000160096101000a81548167ffffffffffffffff021916908367ffffffffffffffff160217905550505003905061233060008a83611e97565b80925050509695505050505050565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff161415151561237b57600080fd5b8073ffffffffffffffffffffffffffffffffffffffff166000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e060405160405180910390a3806000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050565b60c060405190810160405280600061ffff168152602001600061ffff168152602001600060ff168152602001600061ffff168152602001600061ffff168152602001600067ffffffffffffffff16815250905600a165627a7a723058201f1393da614f81ea2ea7d6e431b23437382a84ee6a25f22f485d8247420cb94f0029";
        public SchoonerDeploymentBase() : base(BYTECODE) { }
        public SchoonerDeploymentBase(string byteCode) : base(byteCode) { }
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

    public partial class ImageFunction : ImageFunctionBase { }

    [Function("image", "bytes32")]
    public class ImageFunctionBase : FunctionMessage
    {

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
        [Parameter("uint16", "power", 5, false )]
        public virtual ushort Power { get; set; }
        [Parameter("uint16", "defense", 6, false )]
        public virtual ushort Defense { get; set; }
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



    public partial class ImageOutputDTO : ImageOutputDTOBase { }

    [FunctionOutput]
    public class ImageOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
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
        [Parameter("uint16", "power", 5)]
        public virtual ushort Power { get; set; }
        [Parameter("uint16", "defense", 6)]
        public virtual ushort Defense { get; set; }
        [Parameter("uint64", "birth", 7)]
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
