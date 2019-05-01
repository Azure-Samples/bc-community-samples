using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStoreInfo : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public GameObject ButtonPanel;

    public List<Button> Buttons;


    //public Text GameStoreAddress;
    public InputField GameStoreAddress;
    public InputField GameAccountAddress;
    public InputField GameAccountPassword;

    private GameStoreConnectionObject gameStore;

    public void Apply()
    {


        GameAccountAddress.onEndEdit.AddListener(OnGameAccountAddressChanged);
        GameStoreAddress.onEndEdit.AddListener(OnGameStoreAddressChanged);
        GameAccountPassword.onEndEdit.AddListener(OnGameAccountPasswordChanged);
    }

    public void OnGameAccountAddressChanged(string value)
    {
        gameStore = Resources.Load<GameStoreConnectionObject>("1GameStore\\GameStoreConnectionObject");
        if (gameStore != null)
        {
            gameStore.GameAccountAddress = value;
        }
    }

    public void OnGameAccountPasswordChanged(string value)
    {
        gameStore = Resources.Load<GameStoreConnectionObject>("1GameStore\\GameStoreConnectionObject");
        if (gameStore != null)
        {
            gameStore.GameAccountPassword = value;
        }
    }
    public void OnGameStoreAddressChanged(string value)
    {
        gameStore = Resources.Load<GameStoreConnectionObject>("1GameStore\\GameStoreConnectionObject");
        if (gameStore != null)
        {
            gameStore.GameStoreAddress = value;
        }
    }

    public void LoadFromGameStore()
    {
        gameStore = Resources.Load<GameStoreConnectionObject>("1GameStore\\GameStoreConnectionObject");
        if (gameStore && ButtonPrefab && ButtonPanel)
        {
            GameStoreAddress.text = gameStore.GameStoreAddress;
            GameAccountAddress.text = gameStore.GameAccountAddress;
            GameAccountPassword.text = gameStore.GameAccountPassword;

            Buttons = new List<Button>();
            gameStore.LoadItems();

            string activeAddress = gameStore.OwnedActiveItem;
            var activeItem = gameStore.AllItems.Find(a => !string.IsNullOrEmpty(a.Address) && a.Address == activeAddress);
            ButtonPanel.transform.DetachChildren();
            foreach (var item in gameStore.AllItems.FindAll(a => !string.IsNullOrEmpty(a.Address)))
            {
                var btn = Instantiate(ButtonPrefab);
                btn.transform.SetParent(ButtonPanel.transform, false);
                GameStoreAbilityButton gameStoreButton = btn.GetComponent<GameStoreAbilityButton>();
                gameStoreButton.Setup(gameStore, item, activeItem);

                Button tempBtn = btn.GetComponent<Button>();
                tempBtn.onClick.AddListener(() => ButtonClicked(item));
            }
        }
    }

    bool isOwned(GameStoreItemObject item)
    {
        if (gameStore != null)
        {
            return gameStore.GameAccountAddress == item.Owner;
        }
        return false;
    }

    bool isActive(GameStoreItemObject item)
    {
        if (gameStore != null)
        {
            return gameStore.OwnedActiveItem == item.Address;
        }
        return false;
    }

    public void ButtonClicked(GameStoreItemObject item)
    {
        if (gameStore)
        {
            if (isOwned(item) && !isActive(item))
            {
                gameStore.OwnedActiveItem = item.Address;
            }
            else if (!isOwned(item) && item.Price > 0)
            {
                gameStore.BuyItem(item);
                LoadFromGameStore();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadFromGameStore();
    }

    //// Update is called once per frame
    void Update()
    {
        Apply();
    }
}
