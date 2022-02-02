using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class FPSCounter : MonoBehaviour 
{	
    public TMP_Text fpsCounterText;
    public GameObject fpsCounter;
    public TMP_Dropdown fpsCounterDropdown;

	private int frameCount;
	private float deltaTime;
	private double fps;
	private float updateRate = 2.0f;

    private void Start()
    {
        fpsCounterDropdown.value = PlayerPrefs.GetInt("FPSCounterStage", 0);
    }

    private void Update() 
	{
		frameCount++;
		deltaTime += Time.unscaledDeltaTime;

		if(deltaTime > 1 / updateRate) 
		{
			fps = Math.Round (frameCount / deltaTime, 0);
			fpsCounterText.text = fps.ToString() + " fps";
			frameCount = 0;
			deltaTime -= 1 / updateRate;
		}
	}

    public void FPSCounterActive(int counterActive)
    {
        if (counterActive == 0)
        {
            fpsCounter.SetActive(false);
        }
        else if (counterActive == 1)
        {
            fpsCounter.SetActive(true);
        }

        PlayerPrefs.SetInt("FPSCounterStage", counterActive);
    }
}
