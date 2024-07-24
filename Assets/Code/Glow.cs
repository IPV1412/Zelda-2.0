using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Glow : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelGlow;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Brillo", 0.5f);
        panelGlow.color = new Color(panelGlow.color.r, panelGlow.color.g, panelGlow.color.b, sliderValue);
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("Brillo", sliderValue);
        panelGlow.color = new Color(panelGlow.color.r, panelGlow.color.g, panelGlow.color.b, sliderValue);
        
    }

}
