using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionDetailsHolder : MonoBehaviour
{
    [SerializeField]
    public GameObject ScrollContentForDetails;

    public EthKeyManager EthKeyManager;

    public string TransactionHash;

    public string Details;

    private TransactionDetails currentDisplayedDetails;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTransactionDetails(TransactionDetails details)
    {
        if (currentDisplayedDetails == details) return;
        if (details == null) return;

        //Debug.Log("holder:: SetTransactionDetails");
        TransactionHash = details.TransactionReceipt.TransactionHash;

        if (ScrollContentForDetails != null)
        {
            Transform scrollTransform = ScrollContentForDetails.GetComponent<Transform>();
            //todo: Maybe delete children - or are they garbage collected ??
            //scrollTransform.DetachChildren();


            UnityEngine.UI.InputField infoText = scrollTransform.gameObject.GetComponentInChildren<UnityEngine.UI.InputField>();

            

            //if (infoText == null)
            //{
            //    infoText = scrollTransform.gameObject.AddComponent<UnityEngine.UI.InputField>();
            //}


           //Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
           // infoText.font = ArialFont;
           // infoText.material = ArialFont.material;
           // infoText.material.color = new Color(0, 0, 0);

            infoText.text = details.GetDescriptiveText();
            currentDisplayedDetails = details;
            Debug.Log("Text set to " + infoText.text);
        }
        DisplayTransactionDetails();
    }

    public void DisplayTransactionDetails()
    {
        Transform t = this.GetComponent<Transform>();
        Transform child = t.GetChild(0);
        child.gameObject.SetActive(true);
    }

    public void StopDisplayingTransactionDetails()
    {
        Transform t = this.GetComponent<Transform>();
        Transform child = t.GetChild(0);
        child.gameObject.SetActive(false);
    }
}
