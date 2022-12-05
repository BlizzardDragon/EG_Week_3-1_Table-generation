using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    [ContextMenu("CleanChildren")] 
    public void CleanChildren()
    {
        //GameObject[] children = transform.GetComponentsInChildren<GameObject>();
        int childrenCount = transform.childCount;

        for (int i = 0; i < childrenCount; i++)
        {
            DestroyImmediate(GetComponentInChildren<Transform>().gameObject);
        }
    }
}
