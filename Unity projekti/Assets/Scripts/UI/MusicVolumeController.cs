using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using System;

//Luokka jolla musiikin äänenvoimakkuuden vaihtaminen asetuksista on mahdollista
public class MusicVolumeController : MonoBehaviour 
{
    public AudioMixer mixer;
    public Slider musicSlider;
    public TMP_Text sliderValueText;
    private double convertedNumber;

    //Asettaa asetuksen arvoksi sen, mikä on muistissa ja näyttää äänenvoimakkuuden prosentteina asetuksissa
    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.00f);
        convertedNumber = Math.Round(musicSlider.value, 2) * 100;
        sliderValueText.text = convertedNumber.ToString() + " %";
    }

    //Metodi jolla äänenvoimakkuuden voi asettaa pelin asetuksista
    public void SetMusicVolume (float musicVolume)
	{
		mixer.SetFloat ("volumeMusic", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        convertedNumber = Math.Round(musicSlider.value, 2) * 100;
        sliderValueText.text = convertedNumber.ToString() + " %";
    }
}
