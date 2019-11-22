using System;
using System.Collections.Generic;
using UnityEngine;

namespace Galleass3D

{
    public class OwnershipHud : MonoBehaviour
    {
        [SerializeField]
        EthKeyManager EthKeyManager;

        //Ownership Ownership;

        UnityEngine.UI.Text EtherText;
        UnityEngine.UI.Text CopperText;
        UnityEngine.UI.Text TimberText;
        UnityEngine.UI.Text DoggerText;


        public OwnershipHud()
        {
        }

        public void Start() 
        {
            //Transform transform = GetComponent<Transform>();
            EtherText = GetText("Text_Eth");
            EtherText.text = "Hallo";
            CopperText = GetText("Text_Copper");
            TimberText = GetText("Text_Timber");
            DoggerText = GetText("Text_Dogger");
        }

        UnityEngine.UI.Text GetText(string id)
        {
            //transform.
            Transform wantedTransform = FindDeepChild(transform, id);
            return wantedTransform.GetComponent<UnityEngine.UI.Text>();
        }

        public Transform FindDeepChild(Transform aParent, string aName)
        {
            Queue<Transform> queue = new Queue<Transform>();
            queue.Enqueue(aParent);
            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                if (c.name == aName)
                    return c;
                foreach (Transform t in c)
                    queue.Enqueue(t);
            }
            return null;
        }

        public void Update()
        {
            //System.Numerics.BigInteger eth = EthKeyManager.CurrentOwnership.Ether / new System.Numerics.BigInteger(System.Math.Pow(10,18));
            var fullEther = double.Parse(EthKeyManager.CurrentOwnership.Ether.ToString()) / System.Math.Pow( 10, 18);

            SetValue(EtherText, fullEther);
            SetValue(CopperText, EthKeyManager.CurrentOwnership.Copper);
            SetValue(TimberText, EthKeyManager.CurrentOwnership.Timber);
            SetValue(DoggerText, EthKeyManager.CurrentOwnership.Doggers.Count);
        }

        void SetValue(UnityEngine.UI.Text textComponent, int value)
        {
            textComponent.text = value.ToString();
        }

        void SetValue(UnityEngine.UI.Text textComponent, double value)
        {
            textComponent.text = value.ToString("0.00000");
        }


    }
}
