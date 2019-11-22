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

namespace Galleass3D.Contracts.BuildableInterface.ContractDefinition
{


    public partial class BuildableInterfaceDeployment : BuildableInterfaceDeploymentBase
    {
        public BuildableInterfaceDeployment() : base(BYTECODE) { }
        public BuildableInterfaceDeployment(string byteCode) : base(byteCode) { }
    }

    public class BuildableInterfaceDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public BuildableInterfaceDeploymentBase() : base(BYTECODE) { }
        public BuildableInterfaceDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class BuildFunction : BuildFunctionBase { }

    [Function("build", "uint256")]
    public class BuildFunctionBase : FunctionMessage
    {

    }


}
