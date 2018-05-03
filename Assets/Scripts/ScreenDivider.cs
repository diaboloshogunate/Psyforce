using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDivider : MonoBehaviour
{
    void OnGUI()
    {
        GUI.Box(new Rect(0, Screen.height / 2, Screen.width, 1f), "");
    }
}
