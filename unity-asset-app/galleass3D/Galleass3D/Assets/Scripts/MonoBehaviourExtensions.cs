using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Galleass3D
{
    public static class MonoBehaviourExtensions 
    {
        public static GameObject FindRecursiveByName(this GameObject go, string name)
        {
            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform childTransform = go.transform.GetChild(i);
                if (childTransform.name == name)
                    return childTransform.gameObject;
            }

            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform childTransform = go.transform.GetChild(i);
                return FindRecursiveByName(childTransform.gameObject, name);
            }

            return null;
        }
    }
}