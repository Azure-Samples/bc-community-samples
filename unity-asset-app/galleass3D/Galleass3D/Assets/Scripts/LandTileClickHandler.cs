using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Galleass3D;

namespace Galleass
{
    public class LandTileClickHandler : MonoBehaviour
    {
        LandTileLogic LandTileLogic;

        // Start is called before the first frame update
        void Start()
        {
            LandTileLogic = gameObject.GetComponentInParent<LandTileLogic>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMouseDown()
        {
            LandTileLogic.GetComponent<LandTileLogic>().ShowLandTileDialoge();
        }
    }
}