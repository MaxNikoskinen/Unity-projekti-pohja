using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Asetus jolla voi määrittää käytetäänkö pystytahdistusta

public class VSyncSetting : MonoBehaviour 
{
    public TMP_Dropdown vSyncDropdown;

    //Asettaa asetuksen arvoksi sen mikä on muistissa
    private void Start()
    {
        vSyncDropdown.value = PlayerPrefs.GetInt("VSyncMode", 1);
    }

    //Metodi jolla voi asettaa käytetäänkö pystytahdistusta asetuksista
    public void SetVsync(int vsyncIndex)
	{
		QualitySettings.vSyncCount = vsyncIndex;
        PlayerPrefs.SetInt("VSyncMode", vsyncIndex);
    }
}
