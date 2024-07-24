using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fullscreen : MonoBehaviour
{
    public Toggle toggle;

    void Start()
    {
        if(Screen.fullScreen)
        {
            toggle.isOn = true;
        }else
        {
            toggle.isOn = false;
        }

    }
        
    public void FullScreen(bool pantalla)
    {
        Screen.fullScreen = pantalla;       
    }
}
