using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTransaction : MonoBehaviour
{
    private TransactionDetails TransactionDetails;
    private EthKeyManager EthKeyManager;


    public void SetTransactionDetails(EthKeyManager keyManager, TransactionDetails details)
    {
        UnityEngine.UI.Text text = GetComponentInChildren<UnityEngine.UI.Text>();
        text.text = (details.ContractName != null ? details.ContractName  + " - " : "" ) + details.TransactionReceipt.TransactionHash;
        TransactionDetails = details;
        EthKeyManager = keyManager;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        EthKeyManager.SelectTransactionDetail(TransactionDetails);
    }




}
