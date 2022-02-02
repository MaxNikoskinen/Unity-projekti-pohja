using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System;

public class MasterVolumeController : MonoBehaviour 
{
    public AudioMixer mixer;
    public Slider masterSlider;
    public TMP_Text sliderValueText;
    private double convertedNumber;

    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.00f);
        convertedNumber = Math.Round(masterSlider.value, 2) * 100;
        sliderValueText.text = convertedNumber.ToString() + " %";
    }

    public void SetMasterVolume (float masterVolume)
	{
		mixer.SetFloat ("volumeMaster", Mathf.Log10(masterVolume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        convertedNumber = Math.Round(masterSlider.value, 2) * 100;
        sliderValueText.text = convertedNumber.ToString() + " %";
    }
}
