using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSLimiterSetting : MonoBehaviour
{
    public TMP_Dropdown fpsLimiterDropdown;
    private int numberFromPlayerPrefs;

    private void Start()
    {
        fpsLimiterDropdown.value = PlayerPrefs.GetInt("FPSLimit", 4);
        GetNumber();
        SetFPSLimit(numberFromPlayerPrefs);
    }

    private void GetNumber()
    {
        numberFromPlayerPrefs = PlayerPrefs.GetInt("FPSLimit", 4);
    }
    
    public void SetFPSLimit(int fpsLimit)
    {
        if(fpsLimit == 0)
        {
            Application.targetFrameRate = -1;
        }
        else if(fpsLimit == 1)
        {
            Application.targetFrameRate = 30;
        }
        else if(fpsLimit == 2)
        {
            Application.targetFrameRate = 60;
        }
        else if(fpsLimit == 3)
        {
            Application.targetFrameRate = 120;
        }
        else
        {
            Application.targetFrameRate = 240;
        }

        PlayerPrefs.SetInt("FPSLimit", fpsLimit);
    }
}
