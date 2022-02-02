using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

//FPS-mittari jonka voi ottaa käyttöön asetuksista

public class FPSCounter : MonoBehaviour 
{	
    public TMP_Text fpsCounterText;
    public GameObject fpsCounter;
    public TMP_Dropdown fpsCounterDropdown;

	private int frameCount;
	private float deltaTime;
	private double fps;
	private float updateRate = 2.0f;

    //Asettaa asetukset arvoksi sen mikä on tallennettu
    private void Start()
    {
        fpsCounterDropdown.value = PlayerPrefs.GetInt("FPSCounterStage", 0);
    }

    private void Update() 
	{
        //Laskee fps:sän ja näyttää sen tekstissä
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

    //Ottaa fps-mittarin käyttöön / pois asetuksella
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
