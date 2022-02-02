using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sisältää asioita pelissä yleisesti käytettäviin asioihin esim. pelaaja ja rahamäärä

[RequireComponent(typeof(DontDestroyOnLoad))]
public class GameManager : Singleton<GameManager>
{
    //Poistu pelistä metodi, sulkee pelin
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

        #else
	    	Application.Quit();

        #endif
    }
}
