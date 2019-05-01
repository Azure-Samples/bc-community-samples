using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStoreAbilityButton : MonoBehaviour
{
    private GameStoreConnectionObject gameStore;
    public GameStoreItemObject item;
    public GameStoreItemObject activeItem;

    public Text ItemKey;
    public Text ItemType;
    public Text Multiplier;
    public Text Address;
    public Text Owner;
    public Text Price;
    public Text Status;


    bool isOwned()
    {
        if (gameStore != null) {
            return gameStore.GameAccountAddress == item.Owner;
        }
        return false;
    }

    bool isActive()
    {
        if (gameStore != null)
        {
            return gameStore.OwnedActiveItem == item.Address;
        }
        return false;
    }

    public void Setup(GameStoreConnectionObject gameStore, GameStoreItemObject item, GameStoreItemObject activeItem)
    {
        this.gameStore = gameStore;
        this.item = item;
        this.activeItem = activeItem;
        SetButton();
    }

    public void SetButton()
    {
        try {
            ItemKey.text = item.ItemKey;
            ItemType.text = item.ItemType;
            Multiplier.text = item.Multiplier.ToString() + "xJump";
            Price.text = "$" + item.Price.ToString();
            Address.text = item.Address;
            Owner.text = item.Owner;

            if (item != null)
            {
                if (isOwned())
                {
                    if (isActive())
                    {
                        Status.text = "ACTIVE";
                    }
                    else
                    {
                        Status.text = "Activate Now!";
                    }
                }
                else
                {
                    if (item.Price > 0)
                    {
                        Status.text = "Buy this Item!";
                    }
                    else
                    {
                        Status.text = "Not For Sale!";
                    }
                }
            }
        } catch (System.Exception ex)
        {
            Debug.Log(ex);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetButton();
    }

    // Update is called once per frame
    void Update()
    {
        SetButton();
    }
}
