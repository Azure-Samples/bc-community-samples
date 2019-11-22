using System;
using System.Collections;
using System.Collections.Generic;
using Galleass3D;
using Galleass3D.Contracts.Land.ContractDefinition;
using UnityEngine;
using UnityEngine.UI;

public class LandTileDialoge : MonoBehaviour
{
    Text OwnerText;
    Text TypeText;
    Text BuyAmountText;
    Button BuyButton;
    LandManager LandManager;


    //GetTileOutputDTO ContextObject;
    LandTileLogic ContextObject;

    public GameObject LandTileDialogeGameObject;
    public GameObject GeneralDialogsContainer;

    public GameObject HaborSpecificOptions;

    public void SetLandManager(LandManager landManager)
    {
        LandManager = landManager;
    }

    // Start is called before the first frame update
    void Start()
    {

        //Debug.LogWarning(transform.name);

        //LandTileDialoge
        Transform childTransform = LandTileDialogeGameObject.transform;

        OwnerText = childTransform.Find("OwnerText").GetComponent<Text>();
        TypeText = childTransform.Find("TypeText").GetComponent<Text>();
        BuyButton = childTransform.Find("BuyButton").GetComponent<Button>();

        BuyAmountText = BuyButton.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //internal void Show(GetTileOutputDTO getTileOutputDTO)
    //{

    //    OwnerText.text = getTileOutputDTO.Owner;
    //    TypeText.text = LandManager.MappingIDToName[getTileOutputDTO.Tile];


    //    BuyAmountText.IsActive();
    //    BuyAmountText.text = "Buy for " + getTileOutputDTO.Price.ToString();

    //    //Debug.LogWarning("Child: " + transform.GetChild(0).name + " " + (transform.GetChild(0).name == "LandTileDialoge"));
    //    transform.GetChild(0).gameObject.SetActive(true);

    //    ContextObject = getTileOutputDTO;
    //    //transform.gameObject.FindRecursiveByName("LandTileDialoge").SetActive(true);
    //    //transform.Find("LandTileDialoge").gameObject.SetActive(true); ;
    //}

    public void SetHarbor()
    {
        ContextObject.MakeTileHarbor();
        //ContextObject.SetTileInfo
    }

    public void EditTile(string tileType)
    {
        ContextObject.EditTile(tileType);
        //ContextObject.SetTileInfo
    }

    public void StockDogger()
    {
        //TODO: check if its a harbor.
        ContextObject.StockDogger();
        //LandManager.EthKeyManager.
    }

    internal void Show(LandTileLogic landTileLogic)
    {
        ContextObject = landTileLogic;

        OwnerText.text = ContextObject.TileInfo.Owner;
        TypeText.text = LandManager.MappingIDToName[ContextObject.TileInfo.Tile];

        BuyAmountText.IsActive();
        BuyAmountText.text = "Buy for " + ContextObject.TileInfo.Price.ToString();

        GeneralDialogsContainer.SetActive(true);
        LandTileDialogeGameObject.SetActive(true);

        bool isHabor = LandManager.MappingIDToName[ContextObject.TileInfo.Tile] == "Harbor";

        HaborSpecificOptions.SetActive(isHabor);
    }

    public void CloseDialoge()
    {
        GeneralDialogsContainer.SetActive(false);
        LandTileDialogeGameObject.SetActive(false);
    }
}
