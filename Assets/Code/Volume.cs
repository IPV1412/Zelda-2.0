using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imageMute;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Audio", 50f);
        AudioListener.volume = slider.value;
        Mute();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("Audio", sliderValue);
        AudioListener.volume = slider.value;
        Mute();
        
    }

    void Mute()
    {
        if(sliderValue == 0)
        {
            imageMute.enabled = true;
        }else
        {
            imageMute.enabled = false;
        }
    }      
}


