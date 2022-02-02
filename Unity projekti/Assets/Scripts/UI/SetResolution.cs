using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

//Asetus jolla voi vaihtaa kuvatarkkuutta pelin asetuksista

public class SetResolution : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    //Ottaa saatavilla olevat resoluutiot ja laittaa ne dropdowniin
    private void Start()
    {                                                                                                                             //estää montaa samaa resoluutiota ilmestymästä listaan näytön virkistystaajuuden takia
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray(); 

        resolutionDropdown.ClearOptions(); //tyhjentää dropdownin ennen resoluutioden lisäämistä sinne

        List<string> options = new List<string>(); //uusi luettelo saatavilla olevista vaihtoehdoista

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height/* + ", " + resolutions[i].refreshRate + " hz"*/;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) 
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution", currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();
    }

    //Metodi jolla itse resoluution vaihtaminen pelissä tapahtuu
    public void SetResolutionOption(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode);
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
    }
}
