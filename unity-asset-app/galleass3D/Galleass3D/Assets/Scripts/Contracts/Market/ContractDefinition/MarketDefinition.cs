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

namespace Galleass3D.Contracts.Market.ContractDefinition
{


    public partial class MarketDeployment : MarketDeploymentBase
    {
        public MarketDeployment() : base(BYTECODE) { }
        public MarketDeployment(string byteCode) : base(byteCode) { }
    }

    public class MarketDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405234801561001057600080fd5b50604051602080612c51833981018060405281019080805190602001909291905050508080336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555080600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550505050612b89806100c86000396000f3006080604052600436106100f1576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff1680632ce643f2146101035780632e1a7d4d1461015a5780633319bf1a1461019f578063534a5ab8146101fa57806355b9bd8d1461027a5780635f5e38b6146102fa57806365d2724814610388578063715018a6146104165780638da5cb5b1461042d57806396af3d8a146104845780639e281a9814610504578063a4c0ed3614610569578063b0619e8514610614578063cc549a8d1461067d578063dd63133a14610709578063e16c7d9814610797578063f2fde38b14610808575b3480156100fd57600080fd5b50600080fd5b34801561010f57600080fd5b5061011861084b565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561016657600080fd5b5061018560048036038101908080359060200190929190505050610871565b604051808215151515815260200191505060405180910390f35b3480156101ab57600080fd5b506101e0600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610a46565b604051808215151515815260200191505060405180910390f35b34801561020657600080fd5b50610264600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610aee565b6040518082815260200191505060405180910390f35b34801561028657600080fd5b506102e4600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610b2d565b6040518082815260200191505060405180910390f35b34801561030657600080fd5b5061036e600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610b6c565b604051808215151515815260200191505060405180910390f35b34801561039457600080fd5b506103fc600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610de8565b604051808215151515815260200191505060405180910390f35b34801561042257600080fd5b5061042b611064565b005b34801561043957600080fd5b50610442611166565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561049057600080fd5b506104ee600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919050505061118b565b6040518082815260200191505060405180910390f35b34801561051057600080fd5b5061054f600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001909291905050506111ca565b604051808215151515815260200191505060405180910390f35b34801561057557600080fd5b506105fa600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190803590602001908201803590602001908080601f0160208091040260200160405190810160405280939291908181526020018383808284378201915050505050509192919290505050611400565b604051808215151515815260200191505060405180910390f35b34801561062057600080fd5b50610663600480360381019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291908035600019169060200190929190505050611793565b604051808215151515815260200191505060405180910390f35b34801561068957600080fd5b506106c7600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff1690602001909291905050506118aa565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561071557600080fd5b5061077d600480360381019080803561ffff169060200190929190803561ffff169060200190929190803560ff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001909291905050506118f9565b604051808215151515815260200191505060405180910390f35b3480156107a357600080fd5b506107c66004803603810190808035600019169060200190929190505050611ae3565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561081457600080fd5b50610849600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050611bc5565b005b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156108ce57600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690506001600381111561090257fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b15801561096657600080fd5b505af115801561097a573d6000803e3d6000fd5b505050506040513d602081101561099057600080fd5b810190808051906020019092919050505060038111156109ac57fe5b1415156109b857600080fd5b823073ffffffffffffffffffffffffffffffffffffffff1631101515156109de57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff166108fc849081150290604051600060405180830381858888f193505050501515610a3c57fe5b6001915050919050565b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610aa457600080fd5b81600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060019050919050565b60046020528360005260406000206020528260005260406000206020528160005260406000206020528060005260406000206000935093505050505481565b60056020528360005260406000206020528260005260406000206020528160005260406000206020528060005260406000206000935093505050505481565b60007f4d61726b657400000000000000000000000000000000000000000000000000006000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b158015610c2d57600080fd5b505af1158015610c41573d6000803e3d6000fd5b505050506040513d6020811015610c5757600080fd5b810190808051906020019092919050505073ffffffffffffffffffffffffffffffffffffffff163073ffffffffffffffffffffffffffffffffffffffff16141515610ca157600080fd5b878787600260008461ffff1661ffff16815260200190815260200160002060008361ffff1661ffff16815260200190815260200160002060008260ff1660ff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610d4957600080fd5b86600460008d61ffff1661ffff16815260200190815260200160002060008c61ffff1661ffff16815260200190815260200160002060008b60ff1660ff16815260200190815260200160002060008a73ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000208190555060019550505050505095945050505050565b60007f4d61726b657400000000000000000000000000000000000000000000000000006000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b158015610ea957600080fd5b505af1158015610ebd573d6000803e3d6000fd5b505050506040513d6020811015610ed357600080fd5b810190808051906020019092919050505073ffffffffffffffffffffffffffffffffffffffff163073ffffffffffffffffffffffffffffffffffffffff16141515610f1d57600080fd5b878787600260008461ffff1661ffff16815260200190815260200160002060008361ffff1661ffff16815260200190815260200160002060008260ff1660ff16815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610fc557600080fd5b86600560008d61ffff1661ffff16815260200190815260200160002060008c61ffff1661ffff16815260200190815260200160002060008b60ff1660ff16815260200190815260200160002060008a73ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000208190555060019550505050505095945050505050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156110bf57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482060405160405180910390a260008060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60036020528360005260406000206020528260005260406000206020528160005260406000206020528060005260406000206000935093505050505481565b6000806000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561122857600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690506001600381111561125c57fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b1580156112c057600080fd5b505af11580156112d4573d6000803e3d6000fd5b505050506040513d60208110156112ea57600080fd5b8101908080519060200190929190505050600381111561130657fe5b14151561131257600080fd5b8491508173ffffffffffffffffffffffffffffffffffffffff1663a9059cbb33866040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200182815260200192505050602060405180830381600087803b1580156113b857600080fd5b505af11580156113cc573d6000803e3d6000fd5b505050506040513d60208110156113e257600080fd5b81019080805190602001909291905050505060019250505092915050565b6000807f4d61726b657400000000000000000000000000000000000000000000000000006000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b1580156114c257600080fd5b505af11580156114d6573d6000803e3d6000fd5b505050506040513d60208110156114ec57600080fd5b810190808051906020019092919050505073ffffffffffffffffffffffffffffffffffffffff163073ffffffffffffffffffffffffffffffffffffffff1614151561153657600080fd5b7f96bd57d3c3174096a8d69b378ddbbc106adbfcb63971c045e64b183faec8065033888888604051808573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200183815260200180602001828103825283818151815260200191508051906020019080838360005b838110156116055780820151818401526020810190506115ea565b50505050905090810190601f1680156116325780820380516001836020036101000a031916815260200191505b509550505050505060405180910390a184600081518110151561165157fe5b9060200101517f010000000000000000000000000000000000000000000000000000000000000090047f0100000000000000000000000000000000000000000000000000000000000000027f01000000000000000000000000000000000000000000000000000000000000009004925060008360ff1614156116df576116d8878787611c2c565b9350611789565b60018360ff1614156116fd576116f6878787611c6e565b9350611789565b60028360ff16141561171b57611714878787611ffb565b9350611789565b6040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252600e8152602001807f756e6b6e6f776e20616374696f6e00000000000000000000000000000000000081525060200191505060405180910390fd5b5050509392505050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663b0619e8585856040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001826000191660001916815260200192505050602060405180830381600087803b15801561186657600080fd5b505af115801561187a573d6000803e3d6000fd5b505050506040513d602081101561189057600080fd5b810190808051906020019092919050505091505092915050565b6002602052826000526040600020602052816000526040600020602052806000526040600020600092509250509054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60006119247f4c616e6400000000000000000000000000000000000000000000000000000000611ae3565b73ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614806119b057506119817f4c616e644c696200000000000000000000000000000000000000000000000000611ae3565b73ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16145b15156119bb57600080fd5b82600260008861ffff1661ffff16815260200190815260200160002060008761ffff1661ffff16815260200190815260200160002060008660ff1660ff16815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055507f9ddbaf061101ada1338c64912dabc002f73b61a5652827b26a01864e55db68b286868686604051808561ffff1661ffff1681526020018461ffff1661ffff1681526020018360ff1660ff1681526020018273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200194505050505060405180910390a16001905095945050505050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98846040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b158015611b8257600080fd5b505af1158015611b96573d6000803e3d6000fd5b505050506040513d6020811015611bac57600080fd5b8101908080519060200190929190505050915050919050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515611c2057600080fd5b611c298161237c565b50565b600080600080611c3b85612476565b9250611c4685612585565b9150611c5185612694565b9050611c60838383338a61271a565b600193505050509392505050565b6000806000806000806000611ca27f436f707065720000000000000000000000000000000000000000000000000000611ae3565b73ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515611cdb57600080fd5b611ce8868686338d61271a565b611cf188612476565b9550611cfc88612585565b9450611d0788612694565b9350611d146006896128b7565b92506000600560008861ffff1661ffff16815260200190815260200160002060008761ffff1661ffff16815260200190815260200160002060008660ff1660ff16815260200190815260200160002060008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054111515611dad57600080fd5b611dba868686868d61271a565b600560008761ffff1661ffff16815260200190815260200160002060008661ffff1661ffff16815260200190815260200160002060008560ff1660ff16815260200190815260200160002060008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000205489811515611e4d57fe5b049150611e5d868686868661299a565b8290508073ffffffffffffffffffffffffffffffffffffffff1663a9059cbb8b846040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200182815260200192505050602060405180830381600087803b158015611f0357600080fd5b505af1158015611f17573d6000803e3d6000fd5b505050506040513d6020811015611f2d57600080fd5b81019080805190602001909291905050501515611f4957600080fd5b7f24449f700af63cdb19b9de643e694328a8d9dfe98b867ac3436eccdf216467ee8686868c8787604051808761ffff1661ffff1681526020018661ffff1661ffff1681526020018560ff1660ff1681526020018481526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001828152602001965050505050505060405180910390a1600196505050505050509392505050565b60008060008060008061200d87612476565b945061201887612585565b935061202387612694565b92506000600460008761ffff1661ffff16815260200190815260200160002060008661ffff1661ffff16815260200190815260200160002060008560ff1660ff16815260200190815260200160002060003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020541115156120bc57600080fd5b6120c9858585338c61271a565b7ff8753b3ef35e2a9a2103391ec2df237023c9949782e741708c283309916d40ef858585338c8e604051808761ffff1661ffff1681526020018661ffff1661ffff1681526020018560ff1660ff1681526020018473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018381526020018273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001965050505050505060405180910390a1600460008661ffff1661ffff16815260200190815260200160002060008561ffff1661ffff16815260200190815260200160002060008460ff1660ff16815260200190815260200160002060003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054880291506122588585856122527f436f707065720000000000000000000000000000000000000000000000000000611ae3565b8661299a565b6122817f436f707065720000000000000000000000000000000000000000000000000000611ae3565b90508073ffffffffffffffffffffffffffffffffffffffff1663a9059cbb8a846040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200182815260200192505050602060405180830381600087803b15801561232657600080fd5b505af115801561233a573d6000803e3d6000fd5b505050506040513d602081101561235057600080fd5b8101908080519060200190929190505050151561236c57600080fd5b6001955050505050509392505050565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff16141515156123b857600080fd5b8073ffffffffffffffffffffffffffffffffffffffff166000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e060405160405180910390a3806000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050565b600081600281518110151561248757fe5b9060200101517f010000000000000000000000000000000000000000000000000000000000000090047f0100000000000000000000000000000000000000000000000000000000000000027f01000000000000000000000000000000000000000000000000000000000000009004600883600181518110151561250657fe5b9060200101517f010000000000000000000000000000000000000000000000000000000000000090047f0100000000000000000000000000000000000000000000000000000000000000027f0100000000000000000000000000000000000000000000000000000000000000900461ffff169060020a02179050919050565b600081600481518110151561259657fe5b9060200101517f010000000000000000000000000000000000000000000000000000000000000090047f0100000000000000000000000000000000000000000000000000000000000000027f01000000000000000000000000000000000000000000000000000000000000009004600883600381518110151561261557fe5b9060200101517f010000000000000000000000000000000000000000000000000000000000000090047f0100000000000000000000000000000000000000000000000000000000000000027f0100000000000000000000000000000000000000000000000000000000000000900461ffff169060020a02179050919050565b60008160058151811015156126a557fe5b9060200101517f010000000000000000000000000000000000000000000000000000000000000090047f0100000000000000000000000000000000000000000000000000000000000000027f010000000000000000000000000000000000000000000000000000000000000090049050919050565b80600360008761ffff1661ffff16815260200190815260200160002060008661ffff1661ffff16815260200190815260200160002060008560ff1660ff16815260200190815260200160002060008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206000828254019250508190555080600360008761ffff1661ffff16815260200190815260200160002060008661ffff1661ffff16815260200190815260200160002060008560ff1660ff16815260200190815260200160002060008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054101515156128b0576040517f08c379a00000000000000000000000000000000000000000000000000000000081526004018080602001828103825260098152602001807f4f766572666c6f773f000000000000000000000000000000000000000000000081525060200191505060405180910390fd5b5050505050565b600080600080600080600094506014880160ff1693506001840392505b6001880360ff168360ff16111561298c57868360ff168151811015156128f657fe5b9060200101517f010000000000000000000000000000000000000000000000000000000000000090047f0100000000000000000000000000000000000000000000000000000000000000027f010000000000000000000000000000000000000000000000000000000000000090049150600260018460ff168603030260100a8202905080850194508280600190039350506128d4565b849550505050505092915050565b80600360008761ffff1661ffff16815260200190815260200160002060008661ffff1661ffff16815260200190815260200160002060008560ff1660ff16815260200190815260200160002060008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000205410151515612ac0576040517f08c379a000000000000000000000000000000000000000000000000000000000815260040180806020018281038252602c8152602001807f546869732074696c6520646f6573206e6f74206861766520656e6f756768206f81526020017f66207468697320746f6b656e000000000000000000000000000000000000000081525060400191505060405180910390fd5b80600360008761ffff1661ffff16815260200190815260200160002060008661ffff1661ffff16815260200190815260200160002060008560ff1660ff16815260200190815260200160002060008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020019081526020016000206000828254039250508190555050505050505600a165627a7a723058209c92fb162b7ff7b23841637d77cb720acd4cf7f1c92555f02962dc33358eb6a70029";
        public MarketDeploymentBase() : base(BYTECODE) { }
        public MarketDeploymentBase(string byteCode) : base(byteCode) { }
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

    public partial class BuyPricesFunction : BuyPricesFunctionBase { }

    [Function("buyPrices", "uint256")]
    public class BuyPricesFunctionBase : FunctionMessage
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

    public partial class SellPricesFunction : SellPricesFunctionBase { }

    [Function("sellPrices", "uint256")]
    public class SellPricesFunctionBase : FunctionMessage
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

    public partial class SetBuyPriceFunction : SetBuyPriceFunctionBase { }

    [Function("setBuyPrice", "bool")]
    public class SetBuyPriceFunctionBase : FunctionMessage
    {
        [Parameter("uint16", "_x", 1)]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "_y", 2)]
        public virtual ushort Y { get; set; }
        [Parameter("uint8", "_tile", 3)]
        public virtual byte Tile { get; set; }
        [Parameter("address", "_token", 4)]
        public virtual string Token { get; set; }
        [Parameter("uint256", "_price", 5)]
        public virtual BigInteger Price { get; set; }
    }

    public partial class SetSellPriceFunction : SetSellPriceFunctionBase { }

    [Function("setSellPrice", "bool")]
    public class SetSellPriceFunctionBase : FunctionMessage
    {
        [Parameter("uint16", "_x", 1)]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "_y", 2)]
        public virtual ushort Y { get; set; }
        [Parameter("uint8", "_tile", 3)]
        public virtual byte Tile { get; set; }
        [Parameter("address", "_token", 4)]
        public virtual string Token { get; set; }
        [Parameter("uint256", "_price", 5)]
        public virtual BigInteger Price { get; set; }
    }

    public partial class OnTokenTransferFunction : OnTokenTransferFunctionBase { }

    [Function("onTokenTransfer", "bool")]
    public class OnTokenTransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "_sender", 1)]
        public virtual string Sender { get; set; }
        [Parameter("uint256", "_amount", 2)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("bytes", "_data", 3)]
        public virtual byte[] Data { get; set; }
    }

    public partial class TokenTransferEventDTO : TokenTransferEventDTOBase { }

    [Event("TokenTransfer")]
    public class TokenTransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "token", 1, false )]
        public virtual string Token { get; set; }
        [Parameter("address", "sender", 2, false )]
        public virtual string Sender { get; set; }
        [Parameter("uint256", "amount", 3, false )]
        public virtual BigInteger Amount { get; set; }
        [Parameter("bytes", "data", 4, false )]
        public virtual byte[] Data { get; set; }
    }

    public partial class BuyEventDTO : BuyEventDTOBase { }

    [Event("Buy")]
    public class BuyEventDTOBase : IEventDTO
    {
        [Parameter("uint16", "_x", 1, false )]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "_y", 2, false )]
        public virtual ushort Y { get; set; }
        [Parameter("uint8", "_tile", 3, false )]
        public virtual byte Tile { get; set; }
        [Parameter("uint256", "copperSpent", 4, false )]
        public virtual BigInteger CopperSpent { get; set; }
        [Parameter("address", "_tokenAddress", 5, false )]
        public virtual string TokenAddress { get; set; }
        [Parameter("uint256", "amountOfTokensToSend", 6, false )]
        public virtual BigInteger AmountOfTokensToSend { get; set; }
    }

    public partial class SellEventDTO : SellEventDTOBase { }

    [Event("Sell")]
    public class SellEventDTOBase : IEventDTO
    {
        [Parameter("uint16", "_x", 1, false )]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "_y", 2, false )]
        public virtual ushort Y { get; set; }
        [Parameter("uint8", "_tile", 3, false )]
        public virtual byte Tile { get; set; }
        [Parameter("address", "_tokenAddress", 4, false )]
        public virtual string TokenAddress { get; set; }
        [Parameter("uint256", "_amount", 5, false )]
        public virtual BigInteger Amount { get; set; }
        [Parameter("address", "_sender", 6, false )]
        public virtual string Sender { get; set; }
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





    public partial class BuyPricesOutputDTO : BuyPricesOutputDTOBase { }

    [FunctionOutput]
    public class BuyPricesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class SellPricesOutputDTO : SellPricesOutputDTOBase { }

    [FunctionOutput]
    public class SellPricesOutputDTOBase : IFunctionOutputDTO 
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








}
