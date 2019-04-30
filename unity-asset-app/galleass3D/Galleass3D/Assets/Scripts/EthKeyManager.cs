using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nethereum;
using Nethereum.Contracts.CQS;
using Nethereum.JsonRpc.UnityClient;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using System.Numerics;
using System;
using System.Text;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3.Accounts;
using System.Threading.Tasks;
using Galleass3D.Contracts;
using System.Threading;
using Galleass3D.Contracts.Dogger.ContractDefinition;
using Galleass3D;
using Galleass3D.Contracts.StandardTile.ContractDefinition;

public class TransactionDetails
{
    public TransactionReceipt TransactionReceipt;

    public string ContractName;

    public List<IEventDTO> AllEvents = new List<IEventDTO>();

    public List<Galleass3D.Contracts.Bay.ContractDefinition.FishEventDTO> FishEvents = new List<Galleass3D.Contracts.Bay.ContractDefinition.FishEventDTO>();
    public List<Galleass3D.Contracts.Land.ContractDefinition.LandGeneratedEventDTO> LandEvents = new List<Galleass3D.Contracts.Land.ContractDefinition.LandGeneratedEventDTO>();
    public List<Galleass3D.Contracts.StandardTile.ContractDefinition.LandOwnerEventDTO> LandOwner = new List<Galleass3D.Contracts.StandardTile.ContractDefinition.LandOwnerEventDTO>();
    public List<Galleass3D.Contracts.Dogger.ContractDefinition.BuildEventDTO> DoggerWasBuild = new List<Galleass3D.Contracts.Dogger.ContractDefinition.BuildEventDTO>();

    //public List<Galleass3D.Contracts.Timber.ContractDefinition.MintEventDTO> TimberMintEvents = new List<Galleass3D.Contracts.Timber.ContractDefinition.MintEventDTO>();
    //public List<Galleass3D.Contracts.Copper.ContractDefinition.MintEventDTO> CopperMintEvents = new List<Galleass3D.Contracts.Copper.ContractDefinition.MintEventDTO>();

   

    //LandGenerated


    public string GetDescriptiveText()
    {
        StringBuilder sb = new StringBuilder();

        string hasErrors = TransactionReceipt.HasErrors().HasValue ? TransactionReceipt.HasErrors().Value.ToString() : "???";

        sb.AppendLine(TransactionReceipt.TransactionHash);
        sb.AppendLine("Contract:" + ContractName);
        sb.AppendLine("HasErrors:" + hasErrors);
        sb.AppendLine("Status:" + TransactionReceipt.Status.Value.ToString());
        sb.AppendLine("Logs:" + TransactionReceipt.Logs);

        return sb.ToString();
    }
    //public string Transa;
}

public class BlockDetails
{
    public string GetDescriptiveText()
    {
        return BlockInfo.BlockHash;
    }

    public List<TransactionDetails> TransactionDetails = new List<TransactionDetails>();

    public BlockWithTransactions BlockInfo { get; internal set; }
}



public class Ownership
{
    public BigInteger Ether { get; set; }
    public int Copper { get; set; }
    public int Timber { get; set; }

    public List<GetTokenOutputDTOBase> Doggers = new List<GetTokenOutputDTOBase>();
}



public class EthKeyManager : MonoBehaviour {

    public enum StageMode
    {
        PAUSED, 
        BUILD,
        STAGE,
        PRODUCTION
    }

    public static EthKeyManager Instance { get; private set; }

    public BigInteger DefaultGasPrice = new BigInteger(1000000);
    public BigInteger DefaultGas = new BigInteger(2000000);

    [SerializeField]
    public string RpcUrl;

    [SerializeField]
    public string PreselectedPrivateKey;

    [SerializeField]
    public GameObject BlockInfoText;

    [SerializeField]
    public GameObject TransactionDetailsObject;
    
    [SerializeField]
    public GameObject SelectTransactionButtonPrefab;

    [SerializeField]
    public GameObject TxtBlockNumberDisplay;

    internal byte[] GetEncodedDataCall(ushort x, ushort y, ushort landId, byte command)
    {
        //TODO: getAddressFromBytes Address start at Index 6.


        Debug.Log("Encoding Call: " + x + " - " + y + " - " + landId);
        //byte[] bigX = new BigInteger(x).ToByteArray();
        //byte[] bigY = new BigInteger(y).ToByteArray();
        //byte[] bigI = new BigInteger(landId).ToByteArray();

        byte[] result = new byte[32];



        result[0] = command;
        result[1] = BitConverter.GetBytes(x)[1];
        result[2] = BitConverter.GetBytes(x)[0];
        result[3] = BitConverter.GetBytes(y)[1];
        result[4] = BitConverter.GetBytes(y)[0];


        //for (int i = 0; i < 4; i++)
        // {
        //    result[i] = bigX[38 - 8 + i];
        //   result[i + 8]
        //}

        Debug.Log("Finished Encoding Call: " + x + " - " + y + " - " + landId);

        return result;
    }

    public Ownership CurrentOwnership = new Ownership();

    //cached fields.
    UnityEngine.UI.Text TxtBlockNumberDisplayText;


    string Words = "visit require silent museum allow awesome cook topple gauge lend rain mixed";
    string Password = "";

    public LandManager LandManager;


    private Dictionary<string, string> ContractMappingAddressToName = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    private Dictionary<string, string> ContractMappingNameToAddress = new Dictionary<string, string>();

    //string Words = "ripple scissors kick mammal hire column oak again sun offer wealth tomorrow wagon turn fatal";
    //string Password = "password";
    Nethereum.HdWallet.Wallet Wallet; // = new Nethereum.HdWallet.Wallet(Words, Password);
    private Account Account;
    private Nethereum.Web3.Web3 Web3;

    private Galleass3D.Contracts.WorldsRegistry.WorldsRegistryService WorldsRegistry;

    public Galleass3D.Contracts.Galleass.GalleassService Galleass;
    public Galleass3D.Contracts.Timber.TimberService Timber;
    public Galleass3D.Contracts.Copper.CopperService Copper;
    public Galleass3D.Contracts.Fillet.FilletService Fillet;
    public Galleass3D.Contracts.Dogger.DoggerService Dogger;
    public Galleass3D.Contracts.Bay.BayService Bay;
    public Galleass3D.Contracts.Citizens.CitizensService Citizens;
    public Galleass3D.Contracts.CitizensLib.CitizensLibService CitizensLib;
    public Galleass3D.Contracts.Land.LandService Land;
    public Galleass3D.Contracts.TimberCamp.TimberCampService TimberCamp;
    public Galleass3D.Contracts.LandLib.LandLibService LandLib;
    public Galleass3D.Contracts.Harbor.HarborService Harbor;
    public Galleass3D.Contracts.Fishmonger.FishmongerService Fishmonger;
    public Galleass3D.Contracts.Village.VillageService Village;
    public Galleass3D.Contracts.Market.MarketService Market;
    public Galleass3D.Contracts.Sea.SeaService Sea;




    //fishes.
    public Galleass3D.Contracts.Catfish.CatfishService Catfish;


    public StageMode CurrentStageMode;

    /// <summary>
    /// Blocknumber that got displayed in the UI
    /// </summary>
    private ulong LastBlockNumberDisplayed;
    private ulong LastBlockNumber;
    private ulong StartBlockNumber;
    private ulong LastBlockNumberProcessed;

    private string LatestBlockInformation;
    private bool AutoUpdateToLatestBlock = true;
    private ulong CurrentBlockNumberDisplayed;



    public int MainIslandX = -1;
    public int MainIslandY = -1;


    public int CurrentX = -1;
    public int CurrentY = -1;



    System.Collections.Concurrent.ConcurrentDictionary<string, TransactionDetails> LatestTransactionInformations = new System.Collections.Concurrent.ConcurrentDictionary<string, TransactionDetails>();
    System.Collections.Concurrent.ConcurrentDictionary<ulong, BlockDetails> LatestBlockDetails = new System.Collections.Concurrent.ConcurrentDictionary<ulong, BlockDetails>();

    //event Handlers.
    Event<Galleass3D.Contracts.Bay.ContractDefinition.FishEventDTO> Bay_FishEventHandler;

    int BlockTimeMs = 1000;

    //&& account = Wallet.GetAccount(0);
    //var toAddress = "0x13f022d72158410433cbd66f5dd8bf6d2d129924";
    //var web3 = new Web3(account);

    // Nethereum.Web3.Web3 web3 = new Nethereum.Web3.Web3(new Nethereum.HdWallet.Wallet("", ""));

    //private string WorldsRegistryAddress = "0x6EB0fadc34060AF5EfB053b4cB413CE5809b6f16";

    //    private string LastKnownGalleassAddress = "0x7BDcCd4bF7Cd764C20b6Da0AD1f91520A64641DC";

    private string LastKnownGalleassAddress = "0xcCA2A0478EcA1eA2242CC17c3aE072123631C5Be";

    bool ShallRun = true;


    private async Task<bool> StartBlockchainCommunication()
    {
        Debug.Log("Starting Blockchain Communication");
        //byte[] bytes = new byte[32];
        //string x = await WorldsRegistry.WorldsQueryAsync(null);

        //Task updatePanelTask = UpdateUIPanel();
        //updatePanelTask.Start();


        System.Threading.Thread thread = new System.Threading.Thread(new ThreadStart(UpdateUIPanel));
        thread.Start();


        Galleass = new Galleass3D.Contracts.Galleass.GalleassService(Web3, LastKnownGalleassAddress);

        Timber = await GetContract<Galleass3D.Contracts.Timber.TimberService>();
        Copper = await GetContract<Galleass3D.Contracts.Copper.CopperService>();
        Fillet = await GetContract<Galleass3D.Contracts.Fillet.FilletService>();
        Dogger = await GetContract < Galleass3D.Contracts.Dogger.DoggerService>();
        Bay =   await GetContract<Galleass3D.Contracts.Bay.BayService>();
        Citizens = await GetContract<Galleass3D.Contracts.Citizens.CitizensService>();
        CitizensLib = await GetContract<Galleass3D.Contracts.CitizensLib.CitizensLibService>();
        Land = await GetContract<Galleass3D.Contracts.Land.LandService>();
        TimberCamp = await GetContract<Galleass3D.Contracts.TimberCamp.TimberCampService>();
        LandLib = await GetContract<Galleass3D.Contracts.LandLib.LandLibService>();
        Harbor = await GetContract<Galleass3D.Contracts.Harbor.HarborService>();
        Fishmonger = await GetContract<Galleass3D.Contracts.Fishmonger.FishmongerService>();
        Village = await GetContract < Galleass3D.Contracts.Village.VillageService>();
        Market = await GetContract<Galleass3D.Contracts.Market.MarketService>();
        Sea = await GetContract<Galleass3D.Contracts.Sea.SeaService>();

        //fishes
        Catfish = await GetContract<Galleass3D.Contracts.Catfish.CatfishService>();

        Bay_FishEventHandler = Bay.ContractHandler.GetEvent<Galleass3D.Contracts.Bay.ContractDefinition.FishEventDTO>();



        UpdateBalances();

        MainIslandX = await Land.MainXQueryAsync();
        MainIslandY = await Land.MainYQueryAsync();

        Debug.Log("MainIsland:" + MainIslandX.ToString() + " - " + MainIslandY.ToString());

        bool stockCatfish = false;
       

        if (stockCatfish)
        {
            Debug.Log("Minting Catfish");
            TransactionReceipt mintedCatfish = await Catfish.MintRequestAndWaitForReceiptAsync(Account.Address, 10);

            var catFishBalance = await Catfish.BalanceOfQueryAsync(Account.Address);
            Debug.Log("CatfishBalance:" + catFishBalance.ToString());

            Debug.Log("Allowing Catfish in Bay");
            TransactionReceipt allowCatfishInBay = await Bay.AllowSpeciesRequestAndWaitForReceiptAsync(5, 5, Catfish.ContractHandler.ContractAddress);
            Debug.Log("Stocking Catfish in Bay");
            TransactionReceipt stockCatfishInBay = await Bay.StockRequestAndWaitForReceiptAsync(new Galleass3D.Contracts.Bay.ContractDefinition.StockFunction() { Gas = DefaultGas, GasPrice = DefaultGasPrice, X = 5, Y = 5, Species = Catfish.ContractHandler.ContractAddress });
            Bay.ContractHandler.EthApiContractService.TransactionManager.DefaultGas = new BigInteger(1000000);
            Debug.Log("Stocking Catfish in Bay -finished!");
            DebugTransactionReceipt(stockCatfishInBay);
        }

        //Debug.Log("Minting Timber");
        //var timberReceipt = await Timber.MintRequestAndWaitForReceiptAsync(Account.Address, new BigInteger(100));


        bool mineDogger = false;

        var setPermission = await Galleass.SetPermissionRequestAndWaitForReceiptAsync(Account.Address, Encoding.ASCII.GetBytes("buildDogger"), true);
        //var setPermission2 = await Galleass.SetPermissionRequestAndWaitForReceiptAsync(Account.Address, Encoding.ASCII.GetBytes("transferDogger"), true);

        if (mineDogger)
        {
            var doggerSupply = await Dogger.TotalSupplyQueryAsync();
            Debug.Log("Total Supply Doggers:" + doggerSupply.ToString());

            //var setPermission = await Galleass.SetPermissionRequestAndWaitForReceiptAsync(Account.Address, Encoding.ASCII.GetBytes("buildDogger"), true);
            var setPermission2 = await Galleass.SetPermissionRequestAndWaitForReceiptAsync(Account.Address, Encoding.ASCII.GetBytes("transferDogger"), true);


            //CancellationTokenSource s = new CancellationTokenSource(1500); 
            Debug.Log("Building Dogger");
            var buildDoggerReceipt = await Dogger.BuildRequestAndWaitForReceiptAsync(new Galleass3D.Contracts.Dogger.ContractDefinition.BuildFunction() { Gas = DefaultGas, GasPrice = DefaultGasPrice });

            Debug.Log("Dogger: <<");
            DebugTransactionReceipt(buildDoggerReceipt);
        }


        if (MainIslandX  > 0 && MainIslandY > 0)
        {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            LandManager.LoadIsland(MainIslandX, MainIslandY);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }



        var stageMode = await Galleass.StagedModeQueryAsync();

        CurrentStageMode = (StageMode)stageMode;


        //TODO: for some reason, for this Reiceipt we have to wait forever!!
        //but it seems to go throught.

        //Bay.FishQueryAsync()



        return true;
    }

    void HandleParameterizedThreadStart(object obj)
    {
    }

    async Task UpdateTimber()
    {
        CurrentOwnership.Timber = int.Parse((await Timber.BalanceOfQueryAsync(Account.Address)).ToString());
    }

    async Task UpdateEth()
    {
        CurrentOwnership.Ether = (await Web3.Eth.GetBalance.SendRequestAsync(Account.Address)).Value;
    }

    async Task UpdateCopper()
    {
        CurrentOwnership.Copper = int.Parse((await Copper.BalanceOfQueryAsync(Account.Address)).ToString());
    }
  



    private void DebugTransactionReceipt(TransactionReceipt receipt)
    {
        string hasErrors = receipt.HasErrors().HasValue ? receipt.HasErrors().Value.ToString() : "???";

        Debug.Log("TransactionHash: " + receipt.TransactionHash);
        Debug.Log("HasErrors: " + hasErrors);
        Debug.Log("Status: " + receipt.Status.Value.ToString());
        Debug.Log("Logs: " + receipt.Logs);
        //foreach(var log in receipt.Logs)


    }

    private ulong GetCurrentBlockNumber() 
    {
        var task = Web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
        //task.RunSynchronously();
        //task.Start();
        task.Wait();
        //Debug.Log("Current Block Number = " + task.Result.Value.ToString());
        return ulong.Parse(task.Result.Value.ToString());
    }

    public void CallGenerateLand()
    {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        GenerateLand();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    public async Task GenerateLand()
    {
        string generateLandResult = await LandLib.GenerateLandRequestAsync(new Galleass3D.Contracts.LandLib.ContractDefinition.GenerateLandFunction() { Gas = DefaultGas, GasPrice = DefaultGasPrice });

        Debug.Log("GenerateLand: " + generateLandResult);

        //return result;
    }

    //private IEnumerator ParseEvents()
    //{
    //    Debug.Log("Starting Parsing Events");
    //    while(ShallRun)
    //    {
    //        ulong startBlockNumber = GetCurrentBlockNumber() - 1;
    //        HandleFishEvents(startBlockNumber);
    //        System.Threading.Thread.Sleep(BlockTimeMs);
    //         Web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
    //        yield return startBlockNumber;
    //    }
    //}

    private async Task HandleFishEvents(ulong startBlockNumber)
    {
        //Debug.Log("Parsing events starting at Block " + startBlockNumber.ToString());
        var fishEvents = await Bay_FishEventHandler.GetAllChanges(new NewFilterInput() { FromBlock = new BlockParameter(startBlockNumber) });

        foreach(var fishEvent in fishEvents)
        {
            //DateTime ts = new DateTime(fishEvent.Event.Timestamp);
            Debug.Log("Found a fish at" + fishEvent.Event.X + " " + fishEvent.Event.Y + " ID" + fishEvent.Event.Id + " ts: " + fishEvent.Event.Timestamp + "species: " + fishEvent.Event.Species);
        }
    }

    private async Task<T> GetContract<T>()
    {
        string contractName = typeof(T).Name.Trim();
        contractName = contractName.Substring(0, contractName.Length - "Service".Length);
        Debug.Log("Getting Contract address:" + contractName);
        string contractAddress = await Galleass.GetContractQueryAsync(Encoding.ASCII.GetBytes(contractName));
        Debug.Log("Getting Contract:" + contractName + " at address " + contractAddress);
        T result = (T)Activator.CreateInstance(typeof(T), Web3, contractAddress);

        ContractMappingAddressToName.Add(contractAddress, contractName);
        ContractMappingNameToAddress.Add(contractName, contractAddress);
        //would be Nice: contractAddress to ContractHandler ?!



        return result;
    }

    void Reset() {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    void OnDestroy() {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    // Use this for initialization
    void Start () {

		if (Instance != null) {
            UnityEngine.Debug.LogError("EthKeyManager is already set. Additional EthKeyManager dit not get started.");
            return;
		}

        LandManager = GetComponent<LandManager>();

        if (string.IsNullOrEmpty(RpcUrl))
        {
            //RpcUrl = "http://localhost:9545";
            //RpcUrl = "http://116.203.118.82:8545";
            //RpcUrl = "https://rpc.tau1.artis.network";
            RpcUrl = "http://40.71.213.163:8545";
        }

        //if (!string.IsNullOrEmpty(PreselectedPrivateKey))
        //{
        //    privateKey = PreselectedPrivateKey;
        //}



        Wallet = new Nethereum.HdWallet.Wallet(Words, Password);

        Account = Wallet.GetAccount(0);



        Debug.Log("Address: " + Account.Address);
        //Wallet.GetAccount(0);
        //todo: find out how to create Key Pair
        Web3 = new Nethereum.Web3.Web3(Account, RpcUrl);


        Web3.Eth.TransactionManager.DefaultGas = new BigInteger(1000000);
        Web3.Eth.TransactionManager.DefaultGasPrice = new BigInteger(1000000000);
        // Account.TransactionManager.DefaultGas

        //WorldsRegistry = new Galleass3D.Contracts.WorldsRegistry.WorldsRegistryService(Web3, WorldsRegistryAddress);

      

        //TODO: find out how to call a async function on purpose.
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        StartBlockchainCommunication();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
    }

    void UpdateBalances()
    {
#pragma warning disable CS4014
        UpdateCopper();
        UpdateEth();
        UpdateTimber();
#pragma warning restore CS4014
    }

    void UpdateUIPanel()
    {
        while (ShallRun) 
        {

            ulong newBlockNumber = GetCurrentBlockNumber();
            UpdateBalances();
            if (StartBlockNumber == 0)
            {
                StartBlockNumber = newBlockNumber;
                LastBlockNumberProcessed = newBlockNumber;
            }

            //Web3.Eth.Blocks.GetBlockNumber();
            if (newBlockNumber > LastBlockNumber )
            {
                var blockNumber = new Nethereum.Hex.HexTypes.HexBigInteger(new BigInteger(newBlockNumber));

                var blockTask = Web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(blockNumber);
                blockTask.Wait();
                var block = blockTask.Result;

                BlockDetails blockDetails = new BlockDetails();
                blockDetails.BlockInfo = block;

                StringBuilder txInfos = new StringBuilder();
                txInfos.AppendLine(newBlockNumber.ToString());
                txInfos.AppendLine(block.BlockHash);

                List<Task<TransactionReceipt>> transactionReceiptTasks = new List<Task<TransactionReceipt>>();
                foreach (var tx in block.Transactions)
                {
                    //TODO: maybe just pick up transaction that point to one of our contracts ? see mapping ContractMappingAddressToName

                    txInfos.AppendLine(" - " + tx.TransactionHash);
                    //tx.TransactionHash;
                    //tx.
                    //tx.

                    Task<TransactionReceipt> receiptTask = Web3.Eth.TransactionManager.TransactionReceiptService.PollForReceiptAsync(tx.TransactionHash);
                    //receiptTask.Start();
                    transactionReceiptTasks.Add(receiptTask);
                }

                TimeSpan timeout = TimeSpan.FromSeconds(10);
                foreach(var task in transactionReceiptTasks)
                {

                    task.Wait(timeout);
                    TransactionDetails details = new TransactionDetails();
                    if (task.IsCompleted)
                    {
                        details.TransactionReceipt = task.Result;

                        if (!string.IsNullOrEmpty(details.TransactionReceipt.ContractAddress) && ContractMappingAddressToName.ContainsKey(details.TransactionReceipt.ContractAddress))
                        {
                            details.ContractName = ContractMappingAddressToName[details.TransactionReceipt.ContractAddress];
                        }

                        AddEventsFromReceipt(details.TransactionReceipt, details.FishEvents, details.AllEvents);
                        AddEventsFromReceipt(details.TransactionReceipt, details.LandEvents, details.AllEvents);
                        AddEventsFromReceipt(details.TransactionReceipt, details.LandOwner, details.AllEvents);
                        AddEventsFromReceipt(details.TransactionReceipt, details.DoggerWasBuild, details.AllEvents);
                       // AddEventsFromReceipt(details.TransactionReceipt, details.TimberMintEvents, details.AllEvents);
                       // AddEventsFromReceipt(details.TransactionReceipt, details.CopperMintEvents , details.AllEvents);





                        LatestTransactionInformations.TryAdd(details.TransactionReceipt.TransactionHash, details);
                        blockDetails.TransactionDetails.Add(details);
                    }
                    else
                    {
                        if (task.IsCanceled)
                        {
                            Debug.LogWarning("Receiving Transaction details was cancelled");
                        }

                        if (task.IsFaulted)
                        {
                            Debug.LogWarning("Receiving Transaction details Rand into an Error.");
                        }
                    }

                    //var fishEvents = details.TransactionReceipt.DecodeAllEvents<Galleass3D.Contracts.Bay.ContractDefinition.FishEventDTO>();
                    //details.
                    //task.Result
                }

                LatestBlockInformation = txInfos.ToString();

                if (!LatestBlockDetails.TryAdd(newBlockNumber, blockDetails))
                {
                    Debug.LogError("Could not add Block #" + newBlockNumber);
                }

                LastBlockNumber = newBlockNumber;
                //block.Result.Transactions
            }

            System.Threading.Thread.Sleep(BlockTimeMs);
        }
    }

    private void AddEventsFromReceipt<T>(TransactionReceipt receipt, List<T> addToList, List<IEventDTO> addToListUntyped)
        where T : IEventDTO,  new()
    {
        //var decodedEvents = receipt.DecodeAllEvents<Galleass3D.Contracts.Bay.ContractDefinition.FishEventDTO>();
        var decodedEvents = Nethereum.Contracts.EventExtensions.DecodeAllEvents<T>(receipt);

        foreach (var decodedEvent in decodedEvents)
        {
            Debug.Log("Found Event!!" + typeof(T).FullName);
            addToList.Add(decodedEvent.Event);
            addToListUntyped.Add(decodedEvent.Event);
        }
    }

    private void SetText(GameObject textHostObject, string text)
    {
        if (textHostObject != null)
        {
            UnityEngine.UI.Text txComponent = BlockInfoText.GetComponent<UnityEngine.UI.Text>();
            txComponent.text = text;
        }
    }

    private void DeployTest() 
    {
        Debug.Log("Deploying...");
                StartCoroutine(DoDeploySteps());
    }

    private IEnumerator DoDeploySteps()
    {
        yield break;
        //Nethereum.Contracts.ContractDeploymentMessage deployMessage = new Nethereum.Contracts.ContractDeploymentMessage("0x608060405234801561001057600080fd5b506100293361002e640100000000026401000000009004565b6101e8565b61004f816003610095640100000000026110d1179091906401000000009004565b8073ffffffffffffffffffffffffffffffffffffffff167f6ae172837ea30b801fbfcdd4108aa1d5bf8ff775444fd70256b44e6bf3dfc3f660405160405180910390a250565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff16141515156100d157600080fd5b6100ea8282610154640100000000026401000000009004565b1515156100f657600080fd5b60018260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff0219169083151502179055505050565b60008073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff161415151561019157600080fd5b8260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff16905092915050565b61125c806101f76000396000f3fe608060405234801561001057600080fd5b5060043610610128576000357c01000000000000000000000000000000000000000000000000000000009004806370a08231116100bf578063a457c2d71161008e578063a457c2d7146104f1578063a9059cbb14610557578063aa271e1a146105bd578063dd62ed3e14610619578063f3ccaac01461069157610128565b806370a08231146103c857806395d89b4114610420578063983b2d56146104a357806398650275146104e757610128565b80632ff2e9dc116100fb5780632ff2e9dc146102ba578063313ce567146102d857806339509351146102fc57806340c10f191461036257610128565b806306fdde031461012d578063095ea7b3146101b057806318160ddd1461021657806323b872dd14610234575b600080fd5b6101356106af565b6040518080602001828103825283818151815260200191508051906020019080838360005b8381101561017557808201518184015260208101905061015a565b50505050905090810190601f1680156101a25780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b6101fc600480360360408110156101c657600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001909291905050506106e8565b604051808215151515815260200191505060405180910390f35b61021e6106ff565b6040518082815260200191505060405180910390f35b6102a06004803603606081101561024a57600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610709565b604051808215151515815260200191505060405180910390f35b6102c26107ba565b6040518082815260200191505060405180910390f35b6102e06107bf565b604051808260ff1660ff16815260200191505060405180910390f35b6103486004803603604081101561031257600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001909291905050506107c4565b604051808215151515815260200191505060405180910390f35b6103ae6004803603604081101561037857600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919080359060200190929190505050610869565b604051808215151515815260200191505060405180910390f35b61040a600480360360208110156103de57600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610893565b6040518082815260200191505060405180910390f35b6104286108db565b6040518080602001828103825283818151815260200191508051906020019080838360005b8381101561046857808201518184015260208101905061044d565b50505050905090810190601f1680156104955780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b6104e5600480360360208110156104b957600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610914565b005b6104ef610934565b005b61053d6004803603604081101561050757600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291908035906020019092919050505061093f565b604051808215151515815260200191505060405180910390f35b6105a36004803603604081101561056d57600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803590602001909291905050506109e4565b604051808215151515815260200191505060405180910390f35b6105ff600480360360208110156105d357600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff1690602001909291905050506109fb565b604051808215151515815260200191505060405180910390f35b61067b6004803603604081101561062f57600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610a18565b6040518082815260200191505060405180910390f35b610699610a9f565b6040518082815260200191505060405180910390f35b6040805190810160405280600b81526020017f456e657267792043656c6c00000000000000000000000000000000000000000081525081565b60006106f5338484610ac3565b6001905092915050565b6000600254905090565b6000610716848484610c26565b6107af84336107aa85600160008a73ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054610df290919063ffffffff16565b610ac3565b600190509392505050565b600081565b600081565b600061085f338461085a85600160003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008973ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054610e1490919063ffffffff16565b610ac3565b6001905092915050565b6000610874336109fb565b151561087f57600080fd5b6108898383610e35565b6001905092915050565b60008060008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020549050919050565b6040805190810160405280600281526020017f454300000000000000000000000000000000000000000000000000000000000081525081565b61091d336109fb565b151561092857600080fd5b61093181610f89565b50565b61093d33610fe3565b565b60006109da33846109d585600160003373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008973ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054610df290919063ffffffff16565b610ac3565b6001905092915050565b60006109f1338484610c26565b6001905092915050565b6000610a1182600361103d90919063ffffffff16565b9050919050565b6000600160008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054905092915050565b7f656e6572677963656c6c0000000000000000000000000000000000000000000081565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515610aff57600080fd5b600073ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff1614151515610b3b57600080fd5b80600160008573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060008473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020819055508173ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff167f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925836040518082815260200191505060405180910390a3505050565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515610c6257600080fd5b610cb3816000808673ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054610df290919063ffffffff16565b6000808573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002081905550610d46816000808573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054610e1490919063ffffffff16565b6000808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020819055508173ffffffffffffffffffffffffffffffffffffffff168373ffffffffffffffffffffffffffffffffffffffff167fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef836040518082815260200191505060405180910390a3505050565b6000828211151515610e0357600080fd5b600082840390508091505092915050565b6000808284019050838110151515610e2b57600080fd5b8091505092915050565b600073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614151515610e7157600080fd5b610e8681600254610e1490919063ffffffff16565b600281905550610edd816000808573ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002054610e1490919063ffffffff16565b6000808473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff168152602001908152602001600020819055508173ffffffffffffffffffffffffffffffffffffffff16600073ffffffffffffffffffffffffffffffffffffffff167fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef836040518082815260200191505060405180910390a35050565b610f9d8160036110d190919063ffffffff16565b8073ffffffffffffffffffffffffffffffffffffffff167f6ae172837ea30b801fbfcdd4108aa1d5bf8ff775444fd70256b44e6bf3dfc3f660405160405180910390a250565b610ff781600361118190919063ffffffff16565b8073ffffffffffffffffffffffffffffffffffffffff167fe94479a9f7e1952cc78f2d6baab678adc1b772d936c6583def489e524cb6669260405160405180910390a250565b60008073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff161415151561107a57600080fd5b8260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff16905092915050565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff161415151561110d57600080fd5b611117828261103d565b15151561112357600080fd5b60018260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff0219169083151502179055505050565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff16141515156111bd57600080fd5b6111c7828261103d565b15156111d257600080fd5b60008260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff021916908315150217905550505056fea165627a7a72305820718ad52cdc7d599b27271362a72d1828e124674c8f752a9d35c022f0695c4cc80029");
        //TransactionSignedUnityRequest deployResult = SendDeployMessage(deployMessage);
        //yield return SendDeployMessage(deployMessage);
    }

    private void LogErrorException(string message, Exception exception)
    {
        Debug.LogError(message +":" + exception);
        LogErrorRecursive(exception.InnerException);
    }

    private void LogErrorRecursive(Exception exception)
    {
        if (exception != null)
        {
            Debug.LogError("InnerException: " + exception);
            LogErrorRecursive(exception.InnerException);
        }
    }

    public void SelectTransactionDetail(TransactionDetails details)
    {
        //Debug.Log("ethkeymanager:: SetTransactionDetails");
        if (this.TransactionDetailsObject != null)
        {
            TransactionDetailsHolder detailHolder = this.TransactionDetailsObject.GetComponent<TransactionDetailsHolder>();
            detailHolder.SetTransactionDetails(details);
        }
    }

    public void SetAutoUpdateToLatestBlock(UnityEngine.UI.Toggle change)
    {
        AutoUpdateToLatestBlock = change.isOn;
        //Debug.Log("AutoUpdateToLatestBlock:" + AutoUpdateToLatestBlock);
    }

    public void IncreaseCurrentBlockNumberDisplayed()
    {
        if (CurrentBlockNumberDisplayed < LastBlockNumber)
        {
            CurrentBlockNumberDisplayed++;
        }
    }

    public void DeceaseCurrentBlockNumberDisplayed()
    {

        if (CurrentBlockNumberDisplayed > StartBlockNumber)
        {
            CurrentBlockNumberDisplayed--;
        }
    }

    // Update is called once per frame
    void Update () 
    {
        if (AutoUpdateToLatestBlock)
        {
            CurrentBlockNumberDisplayed = LastBlockNumber;
        }

        if (TxtBlockNumberDisplayText == null)
        {
            TxtBlockNumberDisplayText = TxtBlockNumberDisplay.GetComponent<UnityEngine.UI.Text>();
        }

        TxtBlockNumberDisplayText.text = StartBlockNumber + " << " + CurrentBlockNumberDisplayed + " >> " + LastBlockNumber;

        if (LastBlockNumberDisplayed != CurrentBlockNumberDisplayed)        
        {
            BlockDetails details;
            if (LatestBlockDetails.TryGetValue(CurrentBlockNumberDisplayed, out details))
            {
                SetText(BlockInfoText, details.GetDescriptiveText());
                //details.GetDesc
                LastBlockNumberDisplayed = CurrentBlockNumberDisplayed;
                Transform blockInfoTransform = BlockInfoText.GetComponent<Transform>();

                float offsetY = 0;

                SelectTransaction[] oldSelectComponents = blockInfoTransform.GetComponentsInChildren<SelectTransaction>();

                foreach (var oldComponent in oldSelectComponents)
                {
                    Destroy(oldComponent.gameObject);
                }

                blockInfoTransform.DetachChildren();

                foreach (var tx in details.TransactionDetails)
                {
                    GameObject transactionSelector = Instantiate(this.SelectTransactionButtonPrefab, blockInfoTransform);

                    SelectTransaction selectTransactionScript = transactionSelector.GetComponent<SelectTransaction>();
                    selectTransactionScript.SetTransactionDetails(this, tx);

                    //here 

                    Transform transactionSelectorTransform = transactionSelector.GetComponent<Transform>();
                    transactionSelectorTransform.SetPositionAndRotation(new UnityEngine.Vector3(blockInfoTransform.position.x, blockInfoTransform.position.y + offsetY), UnityEngine.Quaternion.identity);
                    offsetY += 30;
                }
            }
            else
            {
                Debug.LogWarning("Could not display Block:" + CurrentBlockNumberDisplayed);
            }
        }

        if (LastBlockNumber > LastBlockNumberProcessed && /*we dont process the block before app start for now.*/ LastBlockNumber > StartBlockNumber)
        {
            BlockDetails blockDetails;

            //need to process this block.
            if (LatestBlockDetails.TryGetValue(LastBlockNumber, out blockDetails))
            {
                foreach(var tx in blockDetails.TransactionDetails)
                {
                    foreach (var eventDto in tx.LandEvents)
                    {
                        //Debug.Log("Last Block: " + LastBlockNumber + " Start: " + StartBlockNumber + " LastProcessed: " + LastBlockNumberProcessed);
                        HandleLandEvent(eventDto);
                    }

                    foreach (var eventDto in tx.FishEvents)
                    {
                        HandleFishEvent(eventDto);
                    }

                    foreach(var landOwnerEvent in tx.LandOwner)
                    {
                        HandleLandOwnerEvent(landOwnerEvent);
                    }

                    foreach(var doggerWasBuild in tx.DoggerWasBuild)
                    {
                        HandleDoggerWasBuildEvent(doggerWasBuild);
                    }
                }
            }
            else
            {
                Debug.LogError("Could  not precess block " + LastBlockNumber.ToString());
            }
            LastBlockNumberProcessed = LastBlockNumber;
        }

        //SetText(BlockInfoText, LatestBlockInformation);
    }

    private void HandleDoggerWasBuildEvent(BuildEventDTO doggerWasBuild)
    {
        Debug.Log("A Dogger was Build!!");
    }
   

    void HandleLandEvent(Galleass3D.Contracts.Land.ContractDefinition.LandGeneratedEventDTO generateLandEvent)
    {
        LandManager.NotifyLandGeneratedEvent(generateLandEvent);
    }

    private void HandleLandOwnerEvent(LandOwnerEventDTO landOwnerEvent)
    {
        LandManager.NotifyLandOwnerEvent(landOwnerEvent);
    }


    void HandleFishEvent(Galleass3D.Contracts.Bay.ContractDefinition.FishEventDTO eventDTO)
    {
        Debug.Log("Fish got generated: " + eventDTO.X + " " + eventDTO.Y + " - " + eventDTO.Species);
    }


    void HandleEvent(IEventDTO nonSpecificEvent)
    {
        Debug.Log("Handling non SpecificEvent!" + nonSpecificEvent.GetType().FullName);
    }

    void OnApplicationQuit()
    {
        ShallRun = false;
    }

    public string GetContractAddress(string contractName)
    {
        if (ContractMappingNameToAddress.ContainsKey(contractName))
        {
            return ContractMappingNameToAddress[contractName];
        }

        return "0x0000000000000000000000000000000000000000";
    }

    public void MintTimber()
    {
        Timber.MintRequestAsync(Account.Address, new BigInteger(10));
    }

    public void MintCopper()
    {
        Copper.MintRequestAsync(Account.Address, new BigInteger(10));
    }

}
