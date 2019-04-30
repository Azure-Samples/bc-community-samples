using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using UnityEngine;

namespace Galleass3D
{
    public class LandTileLogic : MonoBehaviour
    {
        enum TransferTimberToHarborCallType
        {
            SendToken = 0,
            BuildShip = 1,
            BuyShip = 2
        }


        private EthKeyManager EthKeyManager;
        private LandManager LandManager;
        public Galleass3D.Contracts.Land.ContractDefinition.GetTileOutputDTO TileInfo;
        private int LandX;
        private int LandY;

        private UnityEngine.TextMesh Text;
        private UnityEngine.Terrain Terrain;

        [SerializeField]
        public int IslandNumber;

        public static string GetTileNameFromID(int id)
        {
            return LandManager.MappingIDToName[id];
        }

        public void SetTileInfo(Galleass3D.Contracts.Land.ContractDefinition.GetTileOutputDTO tileInfo, int landX, int landY)
        {
            TileInfo = tileInfo;
            LandX = landX;
            LandY = landY;

            // TileInfo.Tile
            string islandType = "Unknown " + TileInfo.Tile.ToString();

            if (LandManager.MappingIDToName.ContainsKey(TileInfo.Tile))
            {
                islandType = LandManager.MappingIDToName[TileInfo.Tile];

            }

            Text.text = islandType;

            bool showTile = (TileInfo.Tile != 0);
            Terrain.gameObject.SetActive(showTile);
            Text.gameObject.SetActive(showTile);
        }

        void Start()
        {
            EthKeyManager = GetComponentInParent<EthKeyManager>();
            LandManager = GetComponentInParent<LandManager>();

            Text = GetComponentInChildren<TextMesh>();
            Terrain = GetComponentInChildren<Terrain>();

            Text.gameObject.SetActive(false);
            Terrain.gameObject.SetActive(false);
        }

        void Update()
        {

        }

        public void BuyTile()
        {

        }

        public void MakeTileHarbor()
        {
            EditTile("Harbor");
        }

        public void EditTile(string tileTypeName)
        {
            Debug.Log("EditTile" + tileTypeName);
            EthKeyManager.Land.EditTileRequestAndWaitForReceiptAsync(new Contracts.Land.ContractDefinition.EditTileFunction()
            {
                X = (ushort)LandX,
                Y = (ushort)LandY,
                Tile = (byte)IslandNumber,
                Update = (ushort)LandManager.MappingNameToID[tileTypeName],
                Contract = EthKeyManager.GetContractAddress(tileTypeName)
            });
            Debug.Log("EditTile Sent!! " + tileTypeName);
        }

        public void ShowLandTileDialoge()
        {
            //LandManager.ShowDialoge(LandX, LandY, IslandNumber);
            LandManager.ShowDialoge(this);
        }

        byte[] EncodeTransferTimberToHarborCall(ushort x, ushort y, ushort ix, string shipName, TransferTimberToHarborCallType callType)
        {
            byte[] result = EthKeyManager.GetEncodedDataCall(x, y, ix, (byte)callType);
            byte[] shipNameEncoded = System.Text.Encoding.ASCII.GetBytes(shipName);

            for (int i = 0; i < shipNameEncoded.Length; i++)
            {
                result[6 + i] = shipNameEncoded[i];
            }

            return result;
        }

        internal async Task StockDogger()
        {
            //int amountTimber = 2;
            //Debug.Log("Approving " + amountTimber + " to Harbor for Creating a Dogger");
            //await EthKeyManager.Timber.ApproveRequestAsync(EthKeyManager.Harbor.ContractHandler.ContractAddress, new System.Numerics.BigInteger(2) );


            //transferAndCall
            byte[] callData = EncodeTransferTimberToHarborCall((ushort)LandX, (ushort)LandY, (ushort)IslandNumber, "Dogger", TransferTimberToHarborCallType.BuildShip);

            HexBigInteger hex = new HexBigInteger(new BigInteger(callData));

            Debug.Log("StockDOgger Hex: " + hex.HexValue);

            Debug.Log("StockDOgger Hex - correct order: " + BitConverter.ToString(callData));

            Galleass3D.Contracts.Timber.ContractDefinition.TransferAndCallFunction call =
                new Contracts.Timber.ContractDefinition.TransferAndCallFunction();

            call.Value = new BigInteger(2);
            call.To = EthKeyManager.Harbor.ContractHandler.ContractAddress;
            call.Data = callData;

            call.Gas = EthKeyManager.DefaultGas;

            var request = await EthKeyManager.Timber.TransferAndCallRequestAsync(call);
            Debug.Log("Dogger Call is out!! "  + request);



            //Debug.Log("StockDOgger Call Finished Hex: " + callData);
            //TileInfo.Tile
        }
    }
}
