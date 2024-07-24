using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quality : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int calidad; 

    void Start()
    {
        calidad = PlayerPrefs.GetInt("Quality", 2);
        dropdown.value = calidad; 
        ApplyQualityLevel(); 
    }

    public void ApplyQualityLevel()
    {
        QualitySettings.SetQualityLevel(dropdown.value); 
        PlayerPrefs.SetInt("Quality", dropdown.value);
        calidad = dropdown.value; 
    }
}

