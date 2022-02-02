using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Asetus jolla voi päättää näytetäänkö peli kokonäytöllä, ikkunassa vai reunattomassa ikkunassa

public class FullscreenMode : MonoBehaviour
{
    public TMP_Dropdown fullscreenModeDropdown;

    //Asettaa asetuksen arvoksi sen, mikä on muistissa
    private void Start()
    {
        fullscreenModeDropdown.value = PlayerPrefs.GetInt("FullscreenMode", 1);
    }

    //Metodi jolla ikkunatilaa voi vaihtaa pelin asetuksista
    public void SetFullscreenMode(int fullscreenMode)
    {
        if(fullscreenMode == 0)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else if(fullscreenMode == 1)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }

        PlayerPrefs.SetInt("FullscreenMode", fullscreenMode);
    }
}
