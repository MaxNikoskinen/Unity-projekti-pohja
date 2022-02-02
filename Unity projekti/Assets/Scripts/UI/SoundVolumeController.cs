﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System;

//Luokka jolla äänitehosteiden voimakkuuden vaihtaminen asetuksista on mahdollista

public class SoundVolumeController : MonoBehaviour 
{
    public AudioMixer mixer;
    public Slider soundSlider;
    public TMP_Text sliderValueText;
    private double convertedNumber;

    //Asettaa asetuksen arvoksi sen, mikä on muistissa ja näyttää äänenvoimakkuuden prosentteina asetuksissa
    private void Start()
    {
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume", 1.00f);
        convertedNumber = Math.Round(soundSlider.value, 2) * 100;
        sliderValueText.text = convertedNumber.ToString() + " %";
    }

    //Metodi jolla äänenvoimakkuuden voi asettaa pelin asetuksista
    public void SetSoundVolume (float soundVolume)
	{
		mixer.SetFloat ("volumeSound", Mathf.Log10(soundVolume) * 20);
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
        convertedNumber = Math.Round(soundSlider.value, 2) * 100;
        sliderValueText.text = convertedNumber.ToString() + " %";
    }
}
