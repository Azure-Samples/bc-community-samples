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

namespace Galleass3D.Contracts.ERC677Receiver.ContractDefinition
{


    public partial class ERC677ReceiverDeployment : ERC677ReceiverDeploymentBase
    {
        public ERC677ReceiverDeployment() : base(BYTECODE) { }
        public ERC677ReceiverDeployment(string byteCode) : base(byteCode) { }
    }

    public class ERC677ReceiverDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405234801561001057600080fd5b50610121806100206000396000f300608060405260043610603f576000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff168063a4c0ed36146044575b600080fd5b348015604f57600080fd5b5060d2600480360381019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190803590602001908201803590602001908080601f016020809104026020016040519081016040528093929190818152602001838380828437820191505050505050919291929050505060ec565b604051808215151515815260200191505060405180910390f35b600093925050505600a165627a7a72305820bb1f37d9baf4eabf08a0b5bd225bdcbca1625c202da9ff62f8eb59c13276c7170029";
        public ERC677ReceiverDeploymentBase() : base(BYTECODE) { }
        public ERC677ReceiverDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class OnTokenTransferFunction : OnTokenTransferFunctionBase { }

    [Function("onTokenTransfer", "bool")]
    public class OnTokenTransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("uint256", "", 2)]
        public virtual BigInteger ReturnValue2 { get; set; }
        [Parameter("bytes", "", 3)]
        public virtual byte[] ReturnValue3 { get; set; }
    }

    public partial class OnTokenTransferOutputDTO : OnTokenTransferOutputDTOBase { }

    [FunctionOutput]
    public class OnTokenTransferOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
