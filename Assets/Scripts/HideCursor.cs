using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    [SerializeField] private bool _cursorIsHide = false;

    void Start()
    {
        if(_cursorIsHide)
        {
            Cursor.visible = false;
        }    
    }
}
