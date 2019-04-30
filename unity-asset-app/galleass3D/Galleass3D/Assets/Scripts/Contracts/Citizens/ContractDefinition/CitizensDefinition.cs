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

namespace Galleass3D.Contracts.Citizens.ContractDefinition
{


    public partial class CitizensDeployment : CitizensDeploymentBase
    {
        public CitizensDeployment() : base(BYTECODE) { }
        public CitizensDeployment(string byteCode) : base(byteCode) { }
    }

    public class CitizensDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405234801561001057600080fd5b50604051602080620030408339810180604052810190808051906020019092919050505061003c610243565b81336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555080600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055505061010060405190810160405280600060ff16815260200160008152602001600061ffff168152602001600061ffff168152602001600060ff16815260200160006001026000191681526020016000600102600019168152602001600067ffffffffffffffff1681525090506005819080600181540180825580915050906001820390600052602060002090600602016000909192909190915060008201518160000160006101000a81548160ff021916908360ff1602179055506020820151816001015560408201518160020160006101000a81548161ffff021916908361ffff16021790555060608201518160020160026101000a81548161ffff021916908361ffff16021790555060808201518160020160046101000a81548160ff021916908360ff16021790555060a0820151816003019060001916905560c0820151816004019060001916905560e08201518160050160006101000a81548167ffffffffffffffff021916908367ffffffffffffffff16021790555050505050506102a7565b61010060405190810160405280600060ff16815260200160008152602001600061ffff168152602001600061ffff168152602001600060ff1681526020016000801916815260200160008019168152602001600067ffffffffffffffff1681525090565b612d8980620002b76000396000f30060806040526004361061015f576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff16806306fdde0314610171578063095ea7b31461020157806318160ddd1461024e5780631d36e06c1461027957806323b872dd146102e65780632ce643f2146103535780632e1a7d4d146103aa5780633319bf1a146103ef5780634848b1a51461044a5780635185bdf6146104995780636352211e1461054c57806370a08231146105b9578063715018a6146106105780637a2a3931146106275780638462151c146106945780638da5cb5b1461072c57806395d89b41146107835780639e281a9814610813578063a8bd9c3214610878578063a9059cbb146108e5578063b0619e8514610932578063b9c8dc941461099b578063d896dd64146109ed578063ddc6a17114610a3f578063e16c7d9814610aa4578063e4b50cb814610b15578063f2fde38b14610bfa575b34801561016b57600080fd5b50600080fd5b34801561017d57600080fd5b50610186610c3d565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156101c65780820151818401526020810190506101ab565b50505050905090810190601f1680156101f35780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561020d57600080fd5b5061024c600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610c76565b005b34801561025a57600080fd5b50610263610d38565b6040518082815260200191505060405180910390f35b34801561028557600080fd5b506102a460048036038101908080359060200190929190505050610d48565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156102f257600080fd5b50610351600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610d7b565b005b34801561035f57600080fd5b50610368610e2c565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156103b657600080fd5b506103d560048036038101908080359060200190929190505050610e52565b604051808215151515815260200191505060405180910390f35b3480156103fb57600080fd5b50610430600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050611027565b604051808215151515815260200191505060405180910390f35b34801561045657600080fd5b5061047f60048036038101908080359060200190929190803590602001909291905050506110cf565b604051808215151515815260200191505060405180910390f35b3480156104a557600080fd5b50610536600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803560ff16906020019092919080359060200190929190803561ffff169060200190929190803561ffff169060200190929190803560ff169060200190929190803560001916906020019092919080356000191690602001909291905050506113d3565b6040518082815260200191505060405180910390f35b34801561055857600080fd5b5061057760048036038101908080359060200190929190505050611589565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156105c557600080fd5b506105fa600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050611602565b6040518082815260200191505060405180910390f35b34801561061c57600080fd5b5061062561164b565b005b34801561063357600080fd5b50610692600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff1690602001909291908035906020019092919050505061174d565b005b3480156106a057600080fd5b506106d5600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919050505061181e565b6040518080602001828103825283818151815260200191508051906020019060200280838360005b838110156107185780820151818401526020810190506106fd565b505050509050019250505060405180910390f35b34801561073857600080fd5b5061074161196b565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b34801561078f57600080fd5b50610798611990565b6040518080602001828103825283818151815260200191508051906020019080838360005b838110156107d85780820151818401526020810190506107bd565b50505050905090810190601f1680156108055780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561081f57600080fd5b5061085e600480360381019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001909291905050506119c9565b604051808215151515815260200191505060405180910390f35b34801561088457600080fd5b506108a360048036038101908080359060200190929190505050611bff565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b3480156108f157600080fd5b50610930600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050611c32565b005b34801561093e57600080fd5b50610981600480360381019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291908035600019169060200190929190505050611ccd565b604051808215151515815260200191505060405180910390f35b3480156109a757600080fd5b506109d360048036038101908080359060200190929190803560ff169060200190929190505050611de4565b604051808215151515815260200191505060405180910390f35b3480156109f957600080fd5b50610a2560048036038101908080359060200190929190803560ff1690602001909291905050506120fc565b604051808215151515815260200191505060405180910390f35b348015610a4b57600080fd5b50610a8a600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050612414565b604051808215151515815260200191505060405180910390f35b348015610ab057600080fd5b50610ad36004803603810190808035600019169060200190929190505050612428565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b348015610b2157600080fd5b50610b406004803603810190808035906020019092919050505061250a565b604051808a73ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018960ff1660ff1681526020018881526020018761ffff1661ffff1681526020018661ffff1661ffff1681526020018560ff1660ff168152602001846000191660001916815260200183600019166000191681526020018267ffffffffffffffff1667ffffffffffffffff168152602001995050505050505050505060405180910390f35b348015610c0657600080fd5b50610c3b600480360381019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291905050506125fe565b005b6040805190810160405280601081526020017f47616c6c6561737320436974697a656e0000000000000000000000000000000081525081565b610c803382612665565b1515610c8b57600080fd5b610c9581836126d1565b7fb497174632623317507c114082fd64c660b4313b9375d4c99fd6d9f5067079db338383604051808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001828152602001935050505060405180910390a15050565b6000600160058054905003905090565b60026020528060005260406000206000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515610db757600080fd5b3073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515610df257600080fd5b610dfc3382612727565b1515610e0757600080fd5b610e118382612665565b1515610e1c57600080fd5b610e27838383612793565b505050565b600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515610eaf57600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905060016003811115610ee357fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b158015610f4757600080fd5b505af1158015610f5b573d6000803e3d6000fd5b505050506040513d6020811015610f7157600080fd5b81019080805190602001909291905050506003811115610f8d57fe5b141515610f9957600080fd5b823073ffffffffffffffffffffffffffffffffffffffff163110151515610fbf57600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff166108fc849081150290604051600060405180830381858888f19350505050151561101d57fe5b6001915050919050565b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561108557600080fd5b81600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555060019050919050565b6000807f436974697a656e730000000000000000000000000000000000000000000000006000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b15801561119157600080fd5b505af11580156111a5573d6000803e3d6000fd5b505050506040513d60208110156111bb57600080fd5b810190808051906020019092919050505073ffffffffffffffffffffffffffffffffffffffff163073ffffffffffffffffffffffffffffffffffffffff1614151561120557600080fd5b61122e7f436974697a656e734c6962000000000000000000000000000000000000000000612428565b73ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561126757600080fd5b60058681548110151561127657fe5b906000526020600020906006020192508483600101819055508260020160029054906101000a900461ffff1661ffff168360020160009054906101000a900461ffff1661ffff16877f4fadc0f06a1309c767c9e693caee25fac10a24a989613e3428e97ff34e3f3b668660020160049054906101000a900460ff16600260008c815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff168860000160009054906101000a900460ff1689600101548a600301548b60040154604051808760ff1660ff1681526020018673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018560ff1660ff16815260200184815260200183600019166000191681526020018260001916600019168152602001965050505050505060405180910390a46001935050505092915050565b60007f436974697a656e730000000000000000000000000000000000000000000000006000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b15801561149457600080fd5b505af11580156114a8573d6000803e3d6000fd5b505050506040513d60208110156114be57600080fd5b810190808051906020019092919050505073ffffffffffffffffffffffffffffffffffffffff163073ffffffffffffffffffffffffffffffffffffffff1614151561150857600080fd5b6115317f436974697a656e734c6962000000000000000000000000000000000000000000612428565b73ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561156a57600080fd5b61157a8b8b8b8b8b8b8b8b612995565b50505098975050505050505050565b60006002600083815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff169050600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff16141515156115fd57600080fd5b919050565b6000600360008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020549050919050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff161415156116a657600080fd5b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167ff8df31144d9c2f0f6b59d69b8b98abd5459d07f2742c4df920b25aae33c6482060405160405180910390a260008060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff161415151561178957600080fd5b3073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff16141515156117c457600080fd5b6117ce8382612665565b15156117d957600080fd5b611803337f7472616e73666572436974697a656e7300000000000000000000000000000000611ccd565b151561180e57600080fd5b611819838383612793565b505050565b606060006060600080600061183287611602565b9450600085141561187557600060405190808252806020026020018201604052801561186d5781602001602082028038833980820191505090505b509550611961565b846040519080825280602002602001820160405280156118a45781602001602082028038833980820191505090505b5093506118af610d38565b925060009150600190505b828111151561195d578673ffffffffffffffffffffffffffffffffffffffff166002600083815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614156119505780848381518110151561193957fe5b906020019060200201818152505081806001019250505b80806001019150506118ba565b8395505b5050505050919050565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b6040805190810160405280600981526020017f475f434954495a454e000000000000000000000000000000000000000000000081525081565b6000806000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515611a2757600080fd5b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905060016003811115611a5b57fe5b8173ffffffffffffffffffffffffffffffffffffffff1663b0e315816040518163ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401602060405180830381600087803b158015611abf57600080fd5b505af1158015611ad3573d6000803e3d6000fd5b505050506040513d6020811015611ae957600080fd5b81019080805190602001909291905050506003811115611b0557fe5b141515611b1157600080fd5b8491508173ffffffffffffffffffffffffffffffffffffffff1663a9059cbb33866040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200182815260200192505050602060405180830381600087803b158015611bb757600080fd5b505af1158015611bcb573d6000803e3d6000fd5b505050506040513d6020811015611be157600080fd5b81019080805190602001909291905050505060019250505092915050565b60046020528060005260406000206000915054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515611c6e57600080fd5b3073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515611ca957600080fd5b611cb33382612665565b1515611cbe57600080fd5b611cc9338383612793565b5050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663b0619e8585856040518363ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001826000191660001916815260200192505050602060405180830381600087803b158015611da057600080fd5b505af1158015611db4573d6000803e3d6000fd5b505050506040513d6020811015611dca57600080fd5b810190808051906020019092919050505091505092915050565b6000807f436974697a656e730000000000000000000000000000000000000000000000006000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b158015611ea657600080fd5b505af1158015611eba573d6000803e3d6000fd5b505050506040513d6020811015611ed057600080fd5b810190808051906020019092919050505073ffffffffffffffffffffffffffffffffffffffff163073ffffffffffffffffffffffffffffffffffffffff16141515611f1a57600080fd5b611f437f436974697a656e734c6962000000000000000000000000000000000000000000612428565b73ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141515611f7c57600080fd5b600586815481101515611f8b57fe5b90600052602060002090600602019250848360020160046101000a81548160ff021916908360ff1602179055508260020160029054906101000a900461ffff1661ffff168360020160009054906101000a900461ffff1661ffff16877f4fadc0f06a1309c767c9e693caee25fac10a24a989613e3428e97ff34e3f3b668660020160049054906101000a900460ff16600260008c815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff168860000160009054906101000a900460ff1689600101548a600301548b60040154604051808760ff1660ff1681526020018673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018560ff1660ff16815260200184815260200183600019166000191681526020018260001916600019168152602001965050505050505060405180910390a46001935050505092915050565b6000807f436974697a656e730000000000000000000000000000000000000000000000006000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98836040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b1580156121be57600080fd5b505af11580156121d2573d6000803e3d6000fd5b505050506040513d60208110156121e857600080fd5b810190808051906020019092919050505073ffffffffffffffffffffffffffffffffffffffff163073ffffffffffffffffffffffffffffffffffffffff1614151561223257600080fd5b61225b7f436974697a656e734c6962000000000000000000000000000000000000000000612428565b73ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561229457600080fd5b6005868154811015156122a357fe5b90600052602060002090600602019250848360000160006101000a81548160ff021916908360ff1602179055508260020160029054906101000a900461ffff1661ffff168360020160009054906101000a900461ffff1661ffff16877f4fadc0f06a1309c767c9e693caee25fac10a24a989613e3428e97ff34e3f3b668660020160049054906101000a900460ff16600260008c815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff168860000160009054906101000a900460ff1689600101548a600301548b60040154604051808760ff1660ff1681526020018673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018560ff1660ff16815260200184815260200183600019166000191681526020018260001916600019168152602001965050505050505060405180910390a46001935050505092915050565b60006124208383612727565b905092915050565b600080600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1690508073ffffffffffffffffffffffffffffffffffffffff1663e16c7d98846040518263ffffffff167c0100000000000000000000000000000000000000000000000000000000028152600401808260001916600019168152602001915050602060405180830381600087803b1580156124c757600080fd5b505af11580156124db573d6000803e3d6000fd5b505050506040513d60208110156124f157600080fd5b8101908080519060200190929190505050915050919050565b60008060008060008060008060008060058b81548110151561252857fe5b90600052602060002090600602019050600260008c815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff168160000160009054906101000a900460ff1682600101548360020160009054906101000a900461ffff168460020160029054906101000a900461ffff168560020160049054906101000a900460ff16866003015487600401548860050160009054906101000a900467ffffffffffffffff16995099509950995099509950995099509950509193959799909294969850565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561265957600080fd5b61266281612bff565b50565b60008273ffffffffffffffffffffffffffffffffffffffff166002600084815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614905092915050565b806004600084815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055505050565b60008273ffffffffffffffffffffffffffffffffffffffff166004600084815260200190815260200160002060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1614905092915050565b600360008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008154809291906001019190505550816002600083815260200190815260200160002060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550600073ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff161415156128f157600360008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008154809291906001900391905055506004600082815260200190815260200160002060006101000a81549073ffffffffffffffffffffffffffffffffffffffff02191690555b7ffd19e66d1a4315847e95661bab80aff36f6801c5b2eeeca82491034bd7660abe838383604051808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001828152602001935050505060405180910390a1505050565b600061299f612cf9565b6000610100604051908101604052808b60ff1681526020018a81526020018961ffff1681526020018861ffff1681526020018760ff16815260200186600019168152602001856000191681526020014367ffffffffffffffff16815250915060016005839080600181540180825580915050906001820390600052602060002090600602016000909192909190915060008201518160000160006101000a81548160ff021916908360ff1602179055506020820151816001015560408201518160020160006101000a81548161ffff021916908361ffff16021790555060608201518160020160026101000a81548161ffff021916908361ffff16021790555060808201518160020160046101000a81548160ff021916908360ff16021790555060a0820151816003019060001916905560c0820151816004019060001916905560e08201518160050160006101000a81548167ffffffffffffffff021916908367ffffffffffffffff1602179055505050039050612b2060008c83612793565b816060015161ffff16826040015161ffff16827f4fadc0f06a1309c767c9e693caee25fac10a24a989613e3428e97ff34e3f3b6685608001518f876000015188602001518960a001518a60c00151604051808760ff1660ff1681526020018673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff1681526020018560ff1660ff16815260200184815260200183600019166000191681526020018260001916600019168152602001965050505050505060405180910390a4809250505098975050505050505050565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff1614151515612c3b57600080fd5b8073ffffffffffffffffffffffffffffffffffffffff166000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff167f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e060405160405180910390a3806000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555050565b61010060405190810160405280600060ff16815260200160008152602001600061ffff168152602001600061ffff168152602001600060ff1681526020016000801916815260200160008019168152602001600067ffffffffffffffff16815250905600a165627a7a72305820d0aed9b871c95d4fa011391b6ed2588be7d81063caa3bd5a75efdda74180551c0029";
        public CitizensDeploymentBase() : base(BYTECODE) { }
        public CitizensDeploymentBase(string byteCode) : base(byteCode) { }
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

    public partial class CreateCitizenFunction : CreateCitizenFunctionBase { }

    [Function("createCitizen", "uint256")]
    public class CreateCitizenFunctionBase : FunctionMessage
    {
        [Parameter("address", "_owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("uint8", "_status", 2)]
        public virtual byte Status { get; set; }
        [Parameter("uint256", "_data", 3)]
        public virtual BigInteger Data { get; set; }
        [Parameter("uint16", "_x", 4)]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "_y", 5)]
        public virtual ushort Y { get; set; }
        [Parameter("uint8", "_tile", 6)]
        public virtual byte Tile { get; set; }
        [Parameter("bytes32", "_genes", 7)]
        public virtual byte[] Genes { get; set; }
        [Parameter("bytes32", "_characteristics", 8)]
        public virtual byte[] Characteristics { get; set; }
    }

    public partial class SetStatusFunction : SetStatusFunctionBase { }

    [Function("setStatus", "bool")]
    public class SetStatusFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("uint8", "_status", 2)]
        public virtual byte Status { get; set; }
    }

    public partial class SetTileFunction : SetTileFunctionBase { }

    [Function("setTile", "bool")]
    public class SetTileFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("uint8", "_tile", 2)]
        public virtual byte Tile { get; set; }
    }

    public partial class SetDataFunction : SetDataFunctionBase { }

    [Function("setData", "bool")]
    public class SetDataFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("uint256", "_data", 2)]
        public virtual BigInteger Data { get; set; }
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

    public partial class CitizenUpdateEventDTO : CitizenUpdateEventDTOBase { }

    [Event("CitizenUpdate")]
    public class CitizenUpdateEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "id", 1, true )]
        public virtual BigInteger Id { get; set; }
        [Parameter("uint16", "x", 2, true )]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "y", 3, true )]
        public virtual ushort Y { get; set; }
        [Parameter("uint8", "tile", 4, false )]
        public virtual byte Tile { get; set; }
        [Parameter("address", "owner", 5, false )]
        public virtual string Owner { get; set; }
        [Parameter("uint8", "status", 6, false )]
        public virtual byte Status { get; set; }
        [Parameter("uint256", "data", 7, false )]
        public virtual BigInteger Data { get; set; }
        [Parameter("bytes32", "genes", 8, false )]
        public virtual byte[] Genes { get; set; }
        [Parameter("bytes32", "characteristics", 9, false )]
        public virtual byte[] Characteristics { get; set; }
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
        [Parameter("uint8", "status", 2)]
        public virtual byte Status { get; set; }
        [Parameter("uint256", "data", 3)]
        public virtual BigInteger Data { get; set; }
        [Parameter("uint16", "x", 4)]
        public virtual ushort X { get; set; }
        [Parameter("uint16", "y", 5)]
        public virtual ushort Y { get; set; }
        [Parameter("uint8", "tile", 6)]
        public virtual byte Tile { get; set; }
        [Parameter("bytes32", "genes", 7)]
        public virtual byte[] Genes { get; set; }
        [Parameter("bytes32", "characteristics", 8)]
        public virtual byte[] Characteristics { get; set; }
        [Parameter("uint64", "birth", 9)]
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
