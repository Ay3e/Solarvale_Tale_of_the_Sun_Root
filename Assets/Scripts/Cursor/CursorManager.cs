using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static bool setCursor;

    private void Start()
    {
        setCursor = false;
    }

    void Update()
    {
        Cursor.visible = setCursor;  
    }
}
