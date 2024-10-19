using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Adiomanager : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        if (PlayerPrefs.HasKey("audioVolume"))          //basic data persistance functions for volume slider
        {
            LoadSettings();
        }   
        else
        {
            PlayerPrefs.SetFloat("audioVolume", 1);
                LoadSettings();
        }
    }
    public void Volume()
    {
        AudioListener.volume=slider.value;
        SaveSettings();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("audioVolume", slider.value);  //save slider settings
    }

    public void LoadSettings()
    {
        slider.value = PlayerPrefs.GetFloat("audioVolume");     //load them back in 
    }
}
