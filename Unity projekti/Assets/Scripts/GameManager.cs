using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game Manageriin voi ja kannattaa laittaa kaikki sellaiset toiminnot jota voitaisiin useammin käyttää
// Esim pelaajan voi referoida täällä, pelin tallennus ja lataus tapahtuisi täällä yms.

/// <summary>
/// Game Manager singleton that handles the games main logic
/// </summary>
[RequireComponent(typeof(DontDestroyOnLoad))]
public class GameManager : Singleton<GameManager>
{
    private void Start()
    {

    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

        #else
	    	Application.Quit();

        #endif
    }
}
