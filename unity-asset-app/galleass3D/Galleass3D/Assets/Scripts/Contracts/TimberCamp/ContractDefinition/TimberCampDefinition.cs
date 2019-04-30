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

namespace Galleass3D.Contracts.TimberCamp.ContractDefinition
{


    public partial class TimberCampDeployment : TimberCampDeploymentBase
    {
        public TimberCampDeployment() : base(BYTECODE) { }
        public TimberCampDeployment(string byteCode) : base(byteCode) { }
    }

    public class TimberCampDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405260017e0100000000000000000000000000000000000000000000000000000000000002600460006101000a81548161ffff02191690837e01000000000000000000000000000000000000000000000000000000000000900402179055506106667e0100000000000000000000000000000000000000000000000000000000000002600460026101000a81548161ffff02191690837e010000000000000000000000000000000000000000000000000000000000009004021790555060086004806101000a81548160ff021916908360ff1602179055507f54696d626572000000000000000000000000000000000000000000000000000060059060001916905534801561011057600080fd5b50604051602080611d13833981018060405281019080805190602001909291905050508080336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555080600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550505050611b4b806101c86000396000f300608060405260043610610107576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff16806324265000146101195780632ce643f21461017f5780632e1a7d4d146101d65780633319bf1a1461021b5780633a63d886146102765780636ac5db19146102a9578063715018a614610316578063730879a91461032d57806383c2396c146103a15780638da5cb5b146103d257806396af3d8a146104295780639e281a98146104a9578063b0619e851461050e578063b3dee38614610577578063cc549a8d146105db578063dd63133a14610667578063e16c7d98146106f5578063f2fde38b14610766578063f8897945146107a9575b34801561011357600080fd5b50600080fd5b34801561012557600080fd5b50610163600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff169060200190929190505050610816565b604051808260ff1660ff16815260200191505060405180910390f35b34801561018b57600080fd5b50610194610a8d565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156101e257600080fd5b5061020160048036038101908080359060200190929190505050610ab3565b604051808215151515815260200191505060405180910390f35b34801561022757600080fd5b5061025c600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610c88565b604051808215151515815260200191505060405180910390f35b34801561028257600080fd5b5061028b610d30565b60405180826000191660001916815260200191505060405180910390f35b3480156102b557600080fd5b506102be610d36565b60405180827dffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff19167dffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916815260200191505060405180910390f35b34801561032257600080fd5b5061032b610d67565b005b34801561033957600080fd5b50610377600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff169060200190929190505050610e69565b604051808267ffffffffffffffff1667ffffffffffffffff16815260200191505060405180910390f35b3480156103ad57600080fd5b506103b6610eac565b604051808260ff1660ff16815260200191505060405180910390f35b3480156103de57600080fd5b506103e7610ebe565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561043557600080fd5b50610493600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610ee3565b6040518082815260200191505060405180910390f35b3480156104b557600080fd5b506104f4600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610f22565b604051808215151515815260200191505060405180910390f35b34801561051a57600080fd5b5061055d600480360381019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291908035600019169060200190929190505050611158565b604051808215151515815260200191505060405180910390f35b34801561058357600080fd5b506105c1600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff16906020019092919050505061126f565b604051808215151515815260200191505060405180910390f35b3480156105e757600080fd5b50610625600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff1690602001909291905050506115d9565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561067357600080fd5b506106db600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050611628565b604051808215151515815260200191505060405180910390f35b34801561070157600080fd5b5061072460048036038101908080356000191690602001909291905050506116c1565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561077257600080fd5b506107a7600480360381019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291905050506117a3565b005b3480156107b557600080fd5b506107be61180a565b60405180827dffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff19167dffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff1916815260200191505060405180910390f35b60008060008060008060009550600460009054906101000a90047e01000000000000000000000000000000000000000000000000000000000000027e0100000000000000000000000000000000000000000000000000000000000090049450600460029054906101000a90047e01000000000000000000000000000000000000000000000000000000000000027e01000000000000000000000000000000000000000000000000000000000000900493504361ffff1692505b600660008a61ffff1661ffff16815260200190815260200160002060008961ffff1661ffff16815260200190815260200160002060008860ff1660ff16815260200190815260200160002060009054906101000a900467ffffffffffffffff1667ffffffffffffffff168367ffffffffffffffff16101515610a7d578267ffffffffffffffff1640915081600160208110151561096857fe5b1a7f0100000000000000000000000000000000000000000000000000000000000000027f0100000000000000000000000000000000000000000000000000000000000000900460088360006020811015156109bf57fe5b1a7f0100000000000000000000000000000000000000000000000000000000000000027f0100000000000000000000000000000000000000000000000000000000000000900461ffff169060020a021790508461ffff168161ffff1610158015610a3157508361ffff168161ffff1611155b15610a725785806001019650506004809054906101000a900460ff1660ff168660ff16101515610a71576004809054906101000a900460ff169550610a81565b5b6001830392506108cf565b8595505b50505050509392505050565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610b1057600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905060016003811115610b4457fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b158015610ba857600080fd5b505af1158015610bbc573d6000803e3d6000fd5b505050506040513d6020811015610bd257600080fd5b81019080805190602001909291905050506003811115610bee57fe5b141515610bfa57600080fd5b823073ffffffffffffffffffffffffffffffffffffffff163110151515610c2057600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff166108fc849081150290604051600060405180830381858888f193505050501515610c7e57fe5b6001915050919050565b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610ce657600080fd5b81600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060019050919050565b60055481565b600460029054906101000a90047e010000000000000000000000000000000000000000000000000000000000000281565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610dc257600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482060405160405180910390a260008060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550565b6006602052826000526040600020602052816000526040600020602052806000526040600020600092509250509054906101000a900467ffffffffffffffff1681565b6004809054906101000a900460ff1681565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60036020528360005260406000206020528260005260406000206020528160005260406000206020528060005260406000206000935093505050505481565b6000806000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610f8057600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905060016003811115610fb457fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b15801561101857600080fd5b505af115801561102c573d6000803e3d6000fd5b505050506040513d602081101561104257600080fd5b8101908080519060200190929190505050600381111561105e57fe5b14151561106a57600080fd5b8491508173ffffffffffffffffffffffffffffffffffffffff1663a9059cbb33866040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200182815260200192505050602060405180830381600087803b15801561111057600080fd5b505af1158015611124573d6000803e3d6000fd5b505050506040513d602081101561113a57600080fd5b81019080805190602001909291905050505060019250505092915050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663b0619e8585856040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001826000191660001916815260200192505050602060405180830381600087803b15801561122b57600080fd5b505af115801561123f573d6000803e3d6000fd5b505050506040513d602081101561125557600080fd5b810190808051906020019092919050505091505092915050565b60008060007f54696d62657243616d70000000000000000000000000000000000000000000006000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b15801561133357600080fd5b505af1158015611347573d6000803e3d6000fd5b505050506040513d602081101561135d57600080fd5b810190808051906020019092919050505073ffffffffffffffffffffffffffffffffffffffff163073ffffffffffffffffffffffffffffffffffffffff161415156113a757600080fd5b878787600260008461ffff1661ffff16815260200190815260200160002060008361ffff1661ffff16815260200190815260200160002060008260ff1660ff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561144f57600080fd5b61145a8b8b8b610816565b96506114676005546116c1565b95508573ffffffffffffffffffffffffffffffffffffffff1663e2155c1433896040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018260ff16815260200192505050602060405180830381600087803b15801561150f57600080fd5b505af1158015611523573d6000803e3d6000fd5b505050506040513d602081101561153957600080fd5b8101908080519060200190929190505050151561155557600080fd5b43600660008d61ffff1661ffff16815260200190815260200160002060008c61ffff1661ffff16815260200190815260200160002060008b60ff1660ff16815260200190815260200160002060006101000a81548167ffffffffffffffff021916908367ffffffffffffffff16021790555060019750505050505050509392505050565b6002602052826000526040600020602052816000526040600020602052806000526040600020600092509250509054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b6000611637868686868661183b565b151561164257600080fd5b43600660008861ffff1661ffff16815260200190815260200160002060008761ffff1661ffff16815260200190815260200160002060008660ff1660ff16815260200190815260200160002060006101000a81548167ffffffffffffffff021916908367ffffffffffffffff1602179055506001905095945050505050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98846040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b15801561176057600080fd5b505af1158015611774573d6000803e3d6000fd5b505050506040513d602081101561178a57600080fd5b8101908080519060200190929190505050915050919050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156117fe57600080fd5b61180781611a25565b50565b600460009054906101000a90047e010000000000000000000000000000000000000000000000000000000000000281565b60006118667f4c616e64000000000000000000000000000000000000000000000000000000006116c1565b73ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614806118f257506118c37f4c616e644c6962000000000000000000000000000000000000000000000000006116c1565b73ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16145b15156118fd57600080fd5b82600260008861ffff1661ffff16815260200190815260200160002060008761ffff1661ffff16815260200190815260200160002060008660ff1660ff16815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055507f9ddbaf061101ada1338c64912dabc002f73b61a5652827b26a01864e55db68b286868686604051808561ffff1661ffff1681526020018461ffff1661ffff1681526020018360ff1660ff1681526020018273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200194505050505060405180910390a16001905095945050505050565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff1614151515611a6157600080fd5b8073ffffffffffffffffffffffffffffffffffffffff166000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e060405160405180910390a3806000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550505600a165627a7a72305820371cae89bb1866d3c537958ec6e49f22a7aa6a33a7530db19f35384c15f7f0fb0029";
        public TimberCampDeploymentBase() : base(BYTECODE) { }
        public TimberCampDeploymentBase(string byteCode) : base(byteCode) { }
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

    public partial class ResourceFunction : ResourceFunctionBase { }

    [Function("resource", "bytes32")]
    public class ResourceFunctionBase : FunctionMessage
    {

    }

    public partial class MaxFunction : MaxFunctionBase { }

    [Function("max", "bytes2")]
    public class MaxFunctionBase : FunctionMessage
    {

    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class LastBlockFunction : LastBlockFunctionBase { }

    [Function("lastBlock", "uint64")]
    public class LastBlockFunctionBase : FunctionMessage
    {
        [Parameter("uint16", "", 1)]
        public virtual ushort ReturnValue1 { get; set; }
        [Parameter("uint16", "", 2)]
        public virtual ushort ReturnValue2 { get; set; }
        [Parameter("uint8", "", 3)]
        public virtual byte ReturnValue3 { get; set; }
    }

    public partial class MaxCollectFunction : MaxCollectFunctionBase { }

    [Function("maxCollect", "uint8")]
    public class MaxCollectFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class TokenBalanceFunction : TokenBalanceFunctionBase { }

    [Function("tokenBalance", "uint256")]
    public class TokenBalanceFunctionBase : FunctionMessage
    {
        [Parameter("uint16", "", 1)]
        public virtual ushort ReturnValue1 { get; set; }
        [Parameter("uint16", "", 2)]
        public virtual ushort ReturnValue2 { get; set; }
        [Parameter("uint8", "", 3)]
        public virtual byte ReturnValue3 { get; set; }
        [Parameter("address", "", 4)]
        public virtual string ReturnValue4 { get; set; }
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

    public partial class LandOwnersFunction : LandOwnersFunctionBase { }

    [Function("landOwners", "address")]
    public class LandOwnersFunctionBase : FunctionMessage
    {
        [Parameter("uint16", "", 1)]
        public virtual ushort ReturnValue1 { get; set; }
        [Parameter("uint16", "", 2)]
        public virtual ushort ReturnValue2 { get; set; }
        [Parameter("uint8", "", 3)]
        public virtual byte ReturnValue3 { get; set; }
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

    public partial class MinFunction : MinFunctionBase { }

    [Function("min", "bytes2")]
    public class MinFunctionBase : FunctionMessage
    {

    }

    public partial class OnPurchaseFunction : OnPurchaseFunctionBase { }

    [Function("onPurchase", "bool")]
    public class OnPurchaseFunctionBase : FunctionMessage
    {
        [Parameter("uint16", "_x", 1)]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "_y", 2)]
        public virtual ushort Y { get; set; }
        [Parameter("uint8", "_tile", 3)]
        public virtual byte Tile { get; set; }
        [Parameter("address", "_owner", 4)]
        public virtual string Owner { get; set; }
        [Parameter("uint256", "_amount", 5)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class CollectFunction : CollectFunctionBase { }

    [Function("collect", "bool")]
    public class CollectFunctionBase : FunctionMessage
    {
        [Parameter("uint16", "_x", 1)]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "_y", 2)]
        public virtual ushort Y { get; set; }
        [Parameter("uint8", "_tile", 3)]
        public virtual byte Tile { get; set; }
    }

    public partial class CanCollectFunction : CanCollectFunctionBase { }

    [Function("canCollect", "uint8")]
    public class CanCollectFunctionBase : FunctionMessage
    {
        [Parameter("uint16", "_x", 1)]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "_y", 2)]
        public virtual ushort Y { get; set; }
        [Parameter("uint8", "_tile", 3)]
        public virtual byte Tile { get; set; }
    }

    public partial class LandOwnerEventDTO : LandOwnerEventDTOBase { }

    [Event("LandOwner")]
    public class LandOwnerEventDTOBase : IEventDTO
    {
        [Parameter("uint16", "_x", 1, false )]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "_y", 2, false )]
        public virtual ushort Y { get; set; }
        [Parameter("uint8", "_tile", 3, false )]
        public virtual byte Tile { get; set; }
        [Parameter("address", "_owner", 4, false )]
        public virtual string Owner { get; set; }
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





    public partial class ResourceOutputDTO : ResourceOutputDTOBase { }

    [FunctionOutput]
    public class ResourceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class MaxOutputDTO : MaxOutputDTOBase { }

    [FunctionOutput]
    public class MaxOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes2", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }



    public partial class LastBlockOutputDTO : LastBlockOutputDTOBase { }

    [FunctionOutput]
    public class LastBlockOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint64", "", 1)]
        public virtual ulong ReturnValue1 { get; set; }
    }

    public partial class MaxCollectOutputDTO : MaxCollectOutputDTOBase { }

    [FunctionOutput]
    public class MaxCollectOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TokenBalanceOutputDTO : TokenBalanceOutputDTOBase { }

    [FunctionOutput]
    public class TokenBalanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class HasPermissionOutputDTO : HasPermissionOutputDTOBase { }

    [FunctionOutput]
    public class HasPermissionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class LandOwnersOutputDTO : LandOwnersOutputDTOBase { }

    [FunctionOutput]
    public class LandOwnersOutputDTOBase : IFunctionOutputDTO 
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



    public partial class MinOutputDTO : MinOutputDTOBase { }

    [FunctionOutput]
    public class MinOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes2", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }





    public partial class CanCollectOutputDTO : CanCollectOutputDTOBase { }

    [FunctionOutput]
    public class CanCollectOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "amount", 1)]
        public virtual byte Amount { get; set; }
    }
}
