using UnityEngine;
using System.Collections;

public class GameStoreController : MonoBehaviour
{

    public GameObject storePanel;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Player"))
            OpenStore();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            OpenStore();

    }

    void OpenStore()
    {
        storePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseShop()
    {
        storePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
