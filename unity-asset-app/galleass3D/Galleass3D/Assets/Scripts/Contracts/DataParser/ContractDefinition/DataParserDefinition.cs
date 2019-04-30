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

namespace Galleass3D.Contracts.DataParser.ContractDefinition
{


    public partial class DataParserDeployment : DataParserDeploymentBase
    {
        public DataParserDeployment() : base(BYTECODE) { }
        public DataParserDeployment(string byteCode) : base(byteCode) { }
    }

    public class DataParserDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x6080604052348015600f57600080fd5b50603580601d6000396000f3006080604052600080fd00a165627a7a72305820cf85eb68603f67603be33c3c5f368b797c1106a02891401742e648a3ec6e2b040029";
        public DataParserDeploymentBase() : base(BYTECODE) { }
        public DataParserDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
