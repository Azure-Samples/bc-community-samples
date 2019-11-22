using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Galleass3D;
using UnityEngine;
using System.Linq;
using System;
using System.Numerics;
using Galleass3D.Contracts.StandardTile.ContractDefinition;

namespace Galleass3D
{
    public class LandDetails
    {
        public int Y;
        public int X;
        public List<Galleass3D.Contracts.Land.ContractDefinition.GetTileOutputDTO> TileInfoRaw = new List<Contracts.Land.ContractDefinition.GetTileOutputDTO>();
    }

    public class LandManager : MonoBehaviour
    {

        #region static
        public static readonly Dictionary<string, int> MappingNameToID = new Dictionary<string, int>();
        public static readonly Dictionary<int, string> MappingIDToName = new Dictionary<int, string>();

        static LandManager()
        {
            MappingNameToID.Add("MainHills", 1);
            MappingNameToID.Add("MainGrass", 2);

            MappingNameToID.Add("MainStream", 30);

            MappingNameToID.Add("Grass", 50);
            MappingNameToID.Add("Forest", 51);
            MappingNameToID.Add("Mountain", 52);
            MappingNameToID.Add("CopperMountain", 53);
            MappingNameToID.Add("SilverMountain", 54);

            MappingNameToID.Add("Harbor", 100);
            MappingNameToID.Add("Fishmonger", 101);
            MappingNameToID.Add("Market", 102);

            MappingNameToID.Add("TimberCamp", 150);

            MappingNameToID.Add("Village", 2000);


            foreach (var dictItem in MappingNameToID)
            {
                MappingIDToName.Add(dictItem.Value, dictItem.Key);
            }
        }
        #endregion


        public GameObject DialogeBaseObject;


        public EthKeyManager EthKeyManager { get; private set; }
        LandTileDialoge LandTileDialoge;




        LandDetails CurrentLandDetails;
        bool CurrentLandDetailsDirty = false;

        List<LandTileLogic> LandTileLogics;

        // Start is called before the first frame update
        void Start()
        {
            EthKeyManager = GetComponent<EthKeyManager>();

            LandTileDialoge = DialogeBaseObject.GetComponentInChildren<LandTileDialoge>();

            if (LandTileDialoge == null)
            {
                Debug.LogError("LandTileDialog not found.");
            }

            //NOTE: this works if everything is setup correct.
            LandTileLogic[] landTileLogics = GetComponentsInChildren<LandTileLogic>();
            LandTileLogics = landTileLogics.OrderBy(x => x.IslandNumber).ToList();

            if (LandTileLogics.Count != 18)
            {
                Debug.LogError("Expected to have 18 LandTileLogics as children!");
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (CurrentLandDetails != null)
            {
                if (CurrentLandDetailsDirty)
                {
                    for (int i = 0; i < 18; i++)
                    {
                        LandTileLogics[i].SetTileInfo(CurrentLandDetails.TileInfoRaw[i], CurrentLandDetails.X, CurrentLandDetails.Y);
                    }
                    CurrentLandDetailsDirty = false;
                }
            }
        }

        public async void NotifyLandGeneratedEvent(Galleass3D.Contracts.Land.ContractDefinition.LandGeneratedEventDTO generateLandEvent)
        {
            await SetToNewLand(generateLandEvent);
        }

        async Task SetToNewLand(Galleass3D.Contracts.Land.ContractDefinition.LandGeneratedEventDTO generateLandEvent)
        {
            Debug.Log("Land got generated: " + generateLandEvent.X + " " + generateLandEvent.Y + " - " + generateLandEvent.Island1 + " - " + generateLandEvent.Island2 + " - " + generateLandEvent.Island3 + " - " + generateLandEvent.Island4 + " - " + generateLandEvent.Island5 + " - " + generateLandEvent.Island6 + " - " + generateLandEvent.Island7 + " - " + generateLandEvent.Island8 + " - " + generateLandEvent.Island9);
            CurrentLandDetails = await GetLandDetails(generateLandEvent.X, generateLandEvent.Y);
            CurrentLandDetailsDirty = true;
        }

        async Task<LandDetails> GetLandDetails(ushort x, ushort y)
        {
            LandDetails result = new LandDetails() { X = x, Y = y };

            //System.Threading.Thread.Sleep(5000);
            //StringBuilder sb = new StringBuilder();

            List<Task<Contracts.Land.ContractDefinition.GetTileOutputDTO>> getTileTasks =
                new List<Task<Contracts.Land.ContractDefinition.GetTileOutputDTO>>();

            for (byte i = 0; i < 18; i++)
            {
                getTileTasks.Add(EthKeyManager.Land.GetTileQueryAsync(x, y, i));
            }

            for (byte i = 0; i < 18; i++)
            {
                var tileOutput = await getTileTasks[i];
                result.TileInfoRaw.Add(tileOutput);
            }

            return result;
        }

        internal async Task LoadIsland(int mainIslandX, int mainIslandY)
        {
            Debug.Log("Loading Island " + mainIslandX + " " + mainIslandY);
            CurrentLandDetails = await GetLandDetails((ushort)mainIslandX, (ushort)mainIslandY);
            CurrentLandDetailsDirty = true;
        }


        //public void ShowDialoge(int islandX, int islandY, int islandIndex)
        //{
        //    if (CurrentLandDetails.X != islandX || CurrentLandDetails.Y != islandY)
        //    {
        //        Debug.LogError("Unexpected Dialoge from other Land! requested:" + islandX + " - " + islandY + " Current: " + CurrentLandDetails.X  + " - " + CurrentLandDetails.Y);
        //    }   

        //    LandTileDialoge.Show(CurrentLandDetails.TileInfoRaw[islandIndex]);
        //}

        public void ShowDialoge(LandTileLogic landTileLogic)
        {
            LandTileDialoge.Show(landTileLogic);
        }

        internal void NotifyLandOwnerEvent(LandOwnerEventDTO landOwnerEvent)
        {
            //check if we are talking about this land.

            if (landOwnerEvent.X == CurrentLandDetails.X && landOwnerEvent.Y == CurrentLandDetails.Y)
            {
                UpdateLandTile(landOwnerEvent.X, landOwnerEvent.Y, landOwnerEvent.Tile);
            }
        }
        //public void NotifyLandChanges()

        private async Task UpdateLandTile(ushort x, ushort y, byte tile)
        {
            var newTileInfo = await EthKeyManager.Land.GetTileQueryAsync(x, y, tile);

            CurrentLandDetails.TileInfoRaw[tile] = newTileInfo;
            CurrentLandDetailsDirty = true;
        }
    }

}