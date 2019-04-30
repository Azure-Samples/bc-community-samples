using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Galleass3D.Contracts.Land.ContractDefinition;

namespace Galleass3D.Contracts.Land
{
    public partial class LandService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, LandDeployment landDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<LandDeployment>().SendRequestAndWaitForReceiptAsync(landDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, LandDeployment landDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<LandDeployment>().SendRequestAsync(landDeployment);
        }

        public static async Task<LandService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, LandDeployment landDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, landDeployment, cancellationTokenSource);
            return new LandService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public LandService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> PriceAtQueryAsync(PriceAtFunction priceAtFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceAtFunction, BigInteger>(priceAtFunction, blockParameter);
        }

        
        public Task<BigInteger> PriceAtQueryAsync(ushort returnValue1, ushort returnValue2, BigInteger returnValue3, BlockParameter blockParameter = null)
        {
            var priceAtFunction = new PriceAtFunction();
                priceAtFunction.ReturnValue1 = returnValue1;
                priceAtFunction.ReturnValue2 = returnValue2;
                priceAtFunction.ReturnValue3 = returnValue3;
            
            return ContractHandler.QueryAsync<PriceAtFunction, BigInteger>(priceAtFunction, blockParameter);
        }

        public Task<string> GalleassQueryAsync(GalleassFunction galleassFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GalleassFunction, string>(galleassFunction, blockParameter);
        }

        
        public Task<string> GalleassQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GalleassFunction, string>(null, blockParameter);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(BigInteger amount)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<string> UpgradeGalleassRequestAsync(UpgradeGalleassFunction upgradeGalleassFunction)
        {
             return ContractHandler.SendRequestAsync(upgradeGalleassFunction);
        }

        public Task<TransactionReceipt> UpgradeGalleassRequestAndWaitForReceiptAsync(UpgradeGalleassFunction upgradeGalleassFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeGalleassFunction, cancellationToken);
        }

        public Task<string> UpgradeGalleassRequestAsync(string galleass)
        {
            var upgradeGalleassFunction = new UpgradeGalleassFunction();
                upgradeGalleassFunction.Galleass = galleass;
            
             return ContractHandler.SendRequestAsync(upgradeGalleassFunction);
        }

        public Task<TransactionReceipt> UpgradeGalleassRequestAndWaitForReceiptAsync(string galleass, CancellationTokenSource cancellationToken = null)
        {
            var upgradeGalleassFunction = new UpgradeGalleassFunction();
                upgradeGalleassFunction.Galleass = galleass;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(upgradeGalleassFunction, cancellationToken);
        }

        public Task<ushort> MainYQueryAsync(MainYFunction mainYFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MainYFunction, ushort>(mainYFunction, blockParameter);
        }

        
        public Task<ushort> MainYQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MainYFunction, ushort>(null, blockParameter);
        }

        public Task<ushort> TotalWidthQueryAsync(TotalWidthFunction totalWidthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalWidthFunction, ushort>(totalWidthFunction, blockParameter);
        }

        
        public Task<ushort> TotalWidthQueryAsync(ushort returnValue1, ushort returnValue2, BlockParameter blockParameter = null)
        {
            var totalWidthFunction = new TotalWidthFunction();
                totalWidthFunction.ReturnValue1 = returnValue1;
                totalWidthFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryAsync<TotalWidthFunction, ushort>(totalWidthFunction, blockParameter);
        }

        public Task<ushort> TileTypeAtQueryAsync(TileTypeAtFunction tileTypeAtFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TileTypeAtFunction, ushort>(tileTypeAtFunction, blockParameter);
        }

        
        public Task<ushort> TileTypeAtQueryAsync(ushort returnValue1, ushort returnValue2, BigInteger returnValue3, BlockParameter blockParameter = null)
        {
            var tileTypeAtFunction = new TileTypeAtFunction();
                tileTypeAtFunction.ReturnValue1 = returnValue1;
                tileTypeAtFunction.ReturnValue2 = returnValue2;
                tileTypeAtFunction.ReturnValue3 = returnValue3;
            
            return ContractHandler.QueryAsync<TileTypeAtFunction, ushort>(tileTypeAtFunction, blockParameter);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> ContractAtQueryAsync(ContractAtFunction contractAtFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractAtFunction, string>(contractAtFunction, blockParameter);
        }

        
        public Task<string> ContractAtQueryAsync(ushort returnValue1, ushort returnValue2, BigInteger returnValue3, BlockParameter blockParameter = null)
        {
            var contractAtFunction = new ContractAtFunction();
                contractAtFunction.ReturnValue1 = returnValue1;
                contractAtFunction.ReturnValue2 = returnValue2;
                contractAtFunction.ReturnValue3 = returnValue3;
            
            return ContractHandler.QueryAsync<ContractAtFunction, string>(contractAtFunction, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerAtQueryAsync(OwnerAtFunction ownerAtFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerAtFunction, string>(ownerAtFunction, blockParameter);
        }

        
        public Task<string> OwnerAtQueryAsync(ushort returnValue1, ushort returnValue2, BigInteger returnValue3, BlockParameter blockParameter = null)
        {
            var ownerAtFunction = new OwnerAtFunction();
                ownerAtFunction.ReturnValue1 = returnValue1;
                ownerAtFunction.ReturnValue2 = returnValue2;
                ownerAtFunction.ReturnValue3 = returnValue3;
            
            return ContractHandler.QueryAsync<OwnerAtFunction, string>(ownerAtFunction, blockParameter);
        }

        public Task<string> WithdrawTokenRequestAsync(WithdrawTokenFunction withdrawTokenFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawTokenFunction);
        }

        public Task<TransactionReceipt> WithdrawTokenRequestAndWaitForReceiptAsync(WithdrawTokenFunction withdrawTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawTokenFunction, cancellationToken);
        }

        public Task<string> WithdrawTokenRequestAsync(string token, BigInteger amount)
        {
            var withdrawTokenFunction = new WithdrawTokenFunction();
                withdrawTokenFunction.Token = token;
                withdrawTokenFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(withdrawTokenFunction);
        }

        public Task<TransactionReceipt> WithdrawTokenRequestAndWaitForReceiptAsync(string token, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var withdrawTokenFunction = new WithdrawTokenFunction();
                withdrawTokenFunction.Token = token;
                withdrawTokenFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawTokenFunction, cancellationToken);
        }

        public Task<bool> HasPermissionQueryAsync(HasPermissionFunction hasPermissionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasPermissionFunction, bool>(hasPermissionFunction, blockParameter);
        }

        
        public Task<bool> HasPermissionQueryAsync(string contract, byte[] permission, BlockParameter blockParameter = null)
        {
            var hasPermissionFunction = new HasPermissionFunction();
                hasPermissionFunction.Contract = contract;
                hasPermissionFunction.Permission = permission;
            
            return ContractHandler.QueryAsync<HasPermissionFunction, bool>(hasPermissionFunction, blockParameter);
        }

        public Task<string> GetContractQueryAsync(GetContractFunction getContractFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContractFunction, string>(getContractFunction, blockParameter);
        }

        
        public Task<string> GetContractQueryAsync(byte[] name, BlockParameter blockParameter = null)
        {
            var getContractFunction = new GetContractFunction();
                getContractFunction.Name = name;
            
            return ContractHandler.QueryAsync<GetContractFunction, string>(getContractFunction, blockParameter);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<ushort> MainXQueryAsync(MainXFunction mainXFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MainXFunction, ushort>(mainXFunction, blockParameter);
        }

        
        public Task<ushort> MainXQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MainXFunction, ushort>(null, blockParameter);
        }

        public Task<string> EditTileRequestAsync(EditTileFunction editTileFunction)
        {
             return ContractHandler.SendRequestAsync(editTileFunction);
        }

        public Task<TransactionReceipt> EditTileRequestAndWaitForReceiptAsync(EditTileFunction editTileFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(editTileFunction, cancellationToken);
        }

        public Task<string> EditTileRequestAsync(ushort x, ushort y, byte tile, ushort update, string contract)
        {
            var editTileFunction = new EditTileFunction();
                editTileFunction.X = x;
                editTileFunction.Y = y;
                editTileFunction.Tile = tile;
                editTileFunction.Update = update;
                editTileFunction.Contract = contract;
            
             return ContractHandler.SendRequestAsync(editTileFunction);
        }

        public Task<TransactionReceipt> EditTileRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, ushort update, string contract, CancellationTokenSource cancellationToken = null)
        {
            var editTileFunction = new EditTileFunction();
                editTileFunction.X = x;
                editTileFunction.Y = y;
                editTileFunction.Tile = tile;
                editTileFunction.Update = update;
                editTileFunction.Contract = contract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(editTileFunction, cancellationToken);
        }

        public Task<string> OwnerSetMainLocationRequestAsync(OwnerSetMainLocationFunction ownerSetMainLocationFunction)
        {
             return ContractHandler.SendRequestAsync(ownerSetMainLocationFunction);
        }

        public Task<TransactionReceipt> OwnerSetMainLocationRequestAndWaitForReceiptAsync(OwnerSetMainLocationFunction ownerSetMainLocationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ownerSetMainLocationFunction, cancellationToken);
        }

        public Task<string> OwnerSetMainLocationRequestAsync(ushort mainX, ushort mainY)
        {
            var ownerSetMainLocationFunction = new OwnerSetMainLocationFunction();
                ownerSetMainLocationFunction.MainX = mainX;
                ownerSetMainLocationFunction.MainY = mainY;
            
             return ContractHandler.SendRequestAsync(ownerSetMainLocationFunction);
        }

        public Task<TransactionReceipt> OwnerSetMainLocationRequestAndWaitForReceiptAsync(ushort mainX, ushort mainY, CancellationTokenSource cancellationToken = null)
        {
            var ownerSetMainLocationFunction = new OwnerSetMainLocationFunction();
                ownerSetMainLocationFunction.MainX = mainX;
                ownerSetMainLocationFunction.MainY = mainY;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(ownerSetMainLocationFunction, cancellationToken);
        }

        public Task<string> BuyTileRequestAsync(BuyTileFunction buyTileFunction)
        {
             return ContractHandler.SendRequestAsync(buyTileFunction);
        }

        public Task<TransactionReceipt> BuyTileRequestAndWaitForReceiptAsync(BuyTileFunction buyTileFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyTileFunction, cancellationToken);
        }

        public Task<string> BuyTileRequestAsync(ushort x, ushort y, byte tile)
        {
            var buyTileFunction = new BuyTileFunction();
                buyTileFunction.X = x;
                buyTileFunction.Y = y;
                buyTileFunction.Tile = tile;
            
             return ContractHandler.SendRequestAsync(buyTileFunction);
        }

        public Task<TransactionReceipt> BuyTileRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, CancellationTokenSource cancellationToken = null)
        {
            var buyTileFunction = new BuyTileFunction();
                buyTileFunction.X = x;
                buyTileFunction.Y = y;
                buyTileFunction.Tile = tile;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyTileFunction, cancellationToken);
        }

        public Task<string> OnTokenTransferRequestAsync(OnTokenTransferFunction onTokenTransferFunction)
        {
             return ContractHandler.SendRequestAsync(onTokenTransferFunction);
        }

        public Task<TransactionReceipt> OnTokenTransferRequestAndWaitForReceiptAsync(OnTokenTransferFunction onTokenTransferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onTokenTransferFunction, cancellationToken);
        }

        public Task<string> OnTokenTransferRequestAsync(string sender, BigInteger amount, byte[] data)
        {
            var onTokenTransferFunction = new OnTokenTransferFunction();
                onTokenTransferFunction.Sender = sender;
                onTokenTransferFunction.Amount = amount;
                onTokenTransferFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(onTokenTransferFunction);
        }

        public Task<TransactionReceipt> OnTokenTransferRequestAndWaitForReceiptAsync(string sender, BigInteger amount, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var onTokenTransferFunction = new OnTokenTransferFunction();
                onTokenTransferFunction.Sender = sender;
                onTokenTransferFunction.Amount = amount;
                onTokenTransferFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onTokenTransferFunction, cancellationToken);
        }

        public Task<string> SetTileTypeAtRequestAsync(SetTileTypeAtFunction setTileTypeAtFunction)
        {
             return ContractHandler.SendRequestAsync(setTileTypeAtFunction);
        }

        public Task<TransactionReceipt> SetTileTypeAtRequestAndWaitForReceiptAsync(SetTileTypeAtFunction setTileTypeAtFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTileTypeAtFunction, cancellationToken);
        }

        public Task<string> SetTileTypeAtRequestAsync(ushort x, ushort y, byte tile, ushort type)
        {
            var setTileTypeAtFunction = new SetTileTypeAtFunction();
                setTileTypeAtFunction.X = x;
                setTileTypeAtFunction.Y = y;
                setTileTypeAtFunction.Tile = tile;
                setTileTypeAtFunction.Type = type;
            
             return ContractHandler.SendRequestAsync(setTileTypeAtFunction);
        }

        public Task<TransactionReceipt> SetTileTypeAtRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, ushort type, CancellationTokenSource cancellationToken = null)
        {
            var setTileTypeAtFunction = new SetTileTypeAtFunction();
                setTileTypeAtFunction.X = x;
                setTileTypeAtFunction.Y = y;
                setTileTypeAtFunction.Tile = tile;
                setTileTypeAtFunction.Type = type;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTileTypeAtFunction, cancellationToken);
        }

        public Task<string> SetContractAtRequestAsync(SetContractAtFunction setContractAtFunction)
        {
             return ContractHandler.SendRequestAsync(setContractAtFunction);
        }

        public Task<TransactionReceipt> SetContractAtRequestAndWaitForReceiptAsync(SetContractAtFunction setContractAtFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractAtFunction, cancellationToken);
        }

        public Task<string> SetContractAtRequestAsync(ushort x, ushort y, byte tile, string address)
        {
            var setContractAtFunction = new SetContractAtFunction();
                setContractAtFunction.X = x;
                setContractAtFunction.Y = y;
                setContractAtFunction.Tile = tile;
                setContractAtFunction.Address = address;
            
             return ContractHandler.SendRequestAsync(setContractAtFunction);
        }

        public Task<TransactionReceipt> SetContractAtRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, string address, CancellationTokenSource cancellationToken = null)
        {
            var setContractAtFunction = new SetContractAtFunction();
                setContractAtFunction.X = x;
                setContractAtFunction.Y = y;
                setContractAtFunction.Tile = tile;
                setContractAtFunction.Address = address;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractAtFunction, cancellationToken);
        }

        public Task<string> SetOwnerAtRequestAsync(SetOwnerAtFunction setOwnerAtFunction)
        {
             return ContractHandler.SendRequestAsync(setOwnerAtFunction);
        }

        public Task<TransactionReceipt> SetOwnerAtRequestAndWaitForReceiptAsync(SetOwnerAtFunction setOwnerAtFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setOwnerAtFunction, cancellationToken);
        }

        public Task<string> SetOwnerAtRequestAsync(ushort x, ushort y, byte tile, string owner)
        {
            var setOwnerAtFunction = new SetOwnerAtFunction();
                setOwnerAtFunction.X = x;
                setOwnerAtFunction.Y = y;
                setOwnerAtFunction.Tile = tile;
                setOwnerAtFunction.Owner = owner;
            
             return ContractHandler.SendRequestAsync(setOwnerAtFunction);
        }

        public Task<TransactionReceipt> SetOwnerAtRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, string owner, CancellationTokenSource cancellationToken = null)
        {
            var setOwnerAtFunction = new SetOwnerAtFunction();
                setOwnerAtFunction.X = x;
                setOwnerAtFunction.Y = y;
                setOwnerAtFunction.Tile = tile;
                setOwnerAtFunction.Owner = owner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setOwnerAtFunction, cancellationToken);
        }

        public Task<string> SetPriceAtRequestAsync(SetPriceAtFunction setPriceAtFunction)
        {
             return ContractHandler.SendRequestAsync(setPriceAtFunction);
        }

        public Task<TransactionReceipt> SetPriceAtRequestAndWaitForReceiptAsync(SetPriceAtFunction setPriceAtFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceAtFunction, cancellationToken);
        }

        public Task<string> SetPriceAtRequestAsync(ushort x, ushort y, byte tile, BigInteger price)
        {
            var setPriceAtFunction = new SetPriceAtFunction();
                setPriceAtFunction.X = x;
                setPriceAtFunction.Y = y;
                setPriceAtFunction.Tile = tile;
                setPriceAtFunction.Price = price;
            
             return ContractHandler.SendRequestAsync(setPriceAtFunction);
        }

        public Task<TransactionReceipt> SetPriceAtRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, BigInteger price, CancellationTokenSource cancellationToken = null)
        {
            var setPriceAtFunction = new SetPriceAtFunction();
                setPriceAtFunction.X = x;
                setPriceAtFunction.Y = y;
                setPriceAtFunction.Tile = tile;
                setPriceAtFunction.Price = price;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceAtFunction, cancellationToken);
        }

        public Task<string> SetTotalWidthRequestAsync(SetTotalWidthFunction setTotalWidthFunction)
        {
             return ContractHandler.SendRequestAsync(setTotalWidthFunction);
        }

        public Task<TransactionReceipt> SetTotalWidthRequestAndWaitForReceiptAsync(SetTotalWidthFunction setTotalWidthFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTotalWidthFunction, cancellationToken);
        }

        public Task<string> SetTotalWidthRequestAsync(ushort x, ushort y, ushort width)
        {
            var setTotalWidthFunction = new SetTotalWidthFunction();
                setTotalWidthFunction.X = x;
                setTotalWidthFunction.Y = y;
                setTotalWidthFunction.Width = width;
            
             return ContractHandler.SendRequestAsync(setTotalWidthFunction);
        }

        public Task<TransactionReceipt> SetTotalWidthRequestAndWaitForReceiptAsync(ushort x, ushort y, ushort width, CancellationTokenSource cancellationToken = null)
        {
            var setTotalWidthFunction = new SetTotalWidthFunction();
                setTotalWidthFunction.X = x;
                setTotalWidthFunction.Y = y;
                setTotalWidthFunction.Width = width;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setTotalWidthFunction, cancellationToken);
        }

        public Task<string> SetMainLocationRequestAsync(SetMainLocationFunction setMainLocationFunction)
        {
             return ContractHandler.SendRequestAsync(setMainLocationFunction);
        }

        public Task<TransactionReceipt> SetMainLocationRequestAndWaitForReceiptAsync(SetMainLocationFunction setMainLocationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMainLocationFunction, cancellationToken);
        }

        public Task<string> SetMainLocationRequestAsync(ushort mainX, ushort mainY)
        {
            var setMainLocationFunction = new SetMainLocationFunction();
                setMainLocationFunction.MainX = mainX;
                setMainLocationFunction.MainY = mainY;
            
             return ContractHandler.SendRequestAsync(setMainLocationFunction);
        }

        public Task<TransactionReceipt> SetMainLocationRequestAndWaitForReceiptAsync(ushort mainX, ushort mainY, CancellationTokenSource cancellationToken = null)
        {
            var setMainLocationFunction = new SetMainLocationFunction();
                setMainLocationFunction.MainX = mainX;
                setMainLocationFunction.MainY = mainY;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMainLocationFunction, cancellationToken);
        }

        public Task<string> SignalGenerateLandRequestAsync(SignalGenerateLandFunction signalGenerateLandFunction)
        {
             return ContractHandler.SendRequestAsync(signalGenerateLandFunction);
        }

        public Task<TransactionReceipt> SignalGenerateLandRequestAndWaitForReceiptAsync(SignalGenerateLandFunction signalGenerateLandFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(signalGenerateLandFunction, cancellationToken);
        }

        public Task<string> SignalGenerateLandRequestAsync(ushort x, ushort y, List<byte> islands)
        {
            var signalGenerateLandFunction = new SignalGenerateLandFunction();
                signalGenerateLandFunction.X = x;
                signalGenerateLandFunction.Y = y;
                signalGenerateLandFunction.Islands = islands;
            
             return ContractHandler.SendRequestAsync(signalGenerateLandFunction);
        }

        public Task<TransactionReceipt> SignalGenerateLandRequestAndWaitForReceiptAsync(ushort x, ushort y, List<byte> islands, CancellationTokenSource cancellationToken = null)
        {
            var signalGenerateLandFunction = new SignalGenerateLandFunction();
                signalGenerateLandFunction.X = x;
                signalGenerateLandFunction.Y = y;
                signalGenerateLandFunction.Islands = islands;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(signalGenerateLandFunction, cancellationToken);
        }

        public Task<string> SetPriceRequestAsync(SetPriceFunction setPriceFunction)
        {
             return ContractHandler.SendRequestAsync(setPriceFunction);
        }

        public Task<TransactionReceipt> SetPriceRequestAndWaitForReceiptAsync(SetPriceFunction setPriceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceFunction, cancellationToken);
        }

        public Task<string> SetPriceRequestAsync(ushort x, ushort y, byte tile, BigInteger price)
        {
            var setPriceFunction = new SetPriceFunction();
                setPriceFunction.X = x;
                setPriceFunction.Y = y;
                setPriceFunction.Tile = tile;
                setPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAsync(setPriceFunction);
        }

        public Task<TransactionReceipt> SetPriceRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, BigInteger price, CancellationTokenSource cancellationToken = null)
        {
            var setPriceFunction = new SetPriceFunction();
                setPriceFunction.X = x;
                setPriceFunction.Y = y;
                setPriceFunction.Tile = tile;
                setPriceFunction.Price = price;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPriceFunction, cancellationToken);
        }

        public Task<string> TransferTileRequestAsync(TransferTileFunction transferTileFunction)
        {
             return ContractHandler.SendRequestAsync(transferTileFunction);
        }

        public Task<TransactionReceipt> TransferTileRequestAndWaitForReceiptAsync(TransferTileFunction transferTileFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferTileFunction, cancellationToken);
        }

        public Task<string> TransferTileRequestAsync(ushort x, ushort y, byte tile, string newOwner)
        {
            var transferTileFunction = new TransferTileFunction();
                transferTileFunction.X = x;
                transferTileFunction.Y = y;
                transferTileFunction.Tile = tile;
                transferTileFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferTileFunction);
        }

        public Task<TransactionReceipt> TransferTileRequestAndWaitForReceiptAsync(ushort x, ushort y, byte tile, string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferTileFunction = new TransferTileFunction();
                transferTileFunction.X = x;
                transferTileFunction.Y = y;
                transferTileFunction.Tile = tile;
                transferTileFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferTileFunction, cancellationToken);
        }

        public Task<GetTileOutputDTO> GetTileQueryAsync(GetTileFunction getTileFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetTileFunction, GetTileOutputDTO>(getTileFunction, blockParameter);
        }

        public Task<GetTileOutputDTO> GetTileQueryAsync(ushort x, ushort y, byte index, BlockParameter blockParameter = null)
        {
            var getTileFunction = new GetTileFunction();
                getTileFunction.X = x;
                getTileFunction.Y = y;
                getTileFunction.Index = index;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetTileFunction, GetTileOutputDTO>(getTileFunction, blockParameter);
        }

        public Task<ushort> GetTileLocationQueryAsync(GetTileLocationFunction getTileLocationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTileLocationFunction, ushort>(getTileLocationFunction, blockParameter);
        }

        
        public Task<ushort> GetTileLocationQueryAsync(ushort x, ushort y, string address, BlockParameter blockParameter = null)
        {
            var getTileLocationFunction = new GetTileLocationFunction();
                getTileLocationFunction.X = x;
                getTileLocationFunction.Y = y;
                getTileLocationFunction.Address = address;
            
            return ContractHandler.QueryAsync<GetTileLocationFunction, ushort>(getTileLocationFunction, blockParameter);
        }

        public Task<byte> FindTileQueryAsync(FindTileFunction findTileFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FindTileFunction, byte>(findTileFunction, blockParameter);
        }

        
        public Task<byte> FindTileQueryAsync(ushort x, ushort y, ushort lookingForType, BlockParameter blockParameter = null)
        {
            var findTileFunction = new FindTileFunction();
                findTileFunction.X = x;
                findTileFunction.Y = y;
                findTileFunction.LookingForType = lookingForType;
            
            return ContractHandler.QueryAsync<FindTileFunction, byte>(findTileFunction, blockParameter);
        }

        public Task<byte> FindTileByAddressQueryAsync(FindTileByAddressFunction findTileByAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FindTileByAddressFunction, byte>(findTileByAddressFunction, blockParameter);
        }

        
        public Task<byte> FindTileByAddressQueryAsync(ushort x, ushort y, string address, BlockParameter blockParameter = null)
        {
            var findTileByAddressFunction = new FindTileByAddressFunction();
                findTileByAddressFunction.X = x;
                findTileByAddressFunction.Y = y;
                findTileByAddressFunction.Address = address;
            
            return ContractHandler.QueryAsync<FindTileByAddressFunction, byte>(findTileByAddressFunction, blockParameter);
        }
    }
}
