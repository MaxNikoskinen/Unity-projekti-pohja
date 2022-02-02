using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System;

//Luokka jolla pää-äänenvoimakkuuden vaihtaminen asetuksista on mahdollista

public class MasterVolumeController : MonoBehaviour 
{
    public AudioMixer mixer;
    public Slider masterSlider;
    public TMP_Text sliderValueText;
    private double convertedNumber;

    //Asettaa asetuksen arvoksi sen, mikä on muistissa ja näyttää äänenvoimakkuuden prosentteina asetuksissa
    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.00f);
        convertedNumber = Math.Round(masterSlider.value, 2) * 100;
        sliderValueText.text = convertedNumber.ToString() + " %";
    }

    //Metodi jolla äänenvoimakkuuden voi asettaa pelin asetuksista
    public void SetMasterVolume (float masterVolume)
	{
		mixer.SetFloat ("volumeMaster", Mathf.Log10(masterVolume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        convertedNumber = Math.Round(masterSlider.value, 2) * 100;
        sliderValueText.text = convertedNumber.ToString() + " %";
    }
}
