using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sisältää asioita pelissä yleisesti käytettäviin asioihin esim. pelaaja ja rahamäärä

[RequireComponent(typeof(DontDestroyOnLoad))]
public class GameManager : Singleton<GameManager>
{
    [SerializeField] private bool is3d;

    //Poistu pelistä metodi, sulkee pelin
    public void ExitGame()
    {
        #if UNITY_EDITOR
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #else
        {
            Application.Quit();
        }
        #endif
    }

    private bool isPaused;
    private bool canPause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            //Jos peli on pysäytetty
            if (isPaused)
            {
                ResumeGame();
            }
            //Jos peliä ei ole pysäytetty
            else
            {
                PauseTheGame();
            }
        }
    }

    //Pysäytä peli
    public void PauseTheGame()
    {
        isPaused = true;
        UIManager.Instance.TogglePauseScreen(true);
        if (is3d)
        {
            ShowCursor();
        }
    }

    //Jatka peliä
    public void ResumeGame()
    {
        isPaused = false;
        UIManager.Instance.TogglePauseScreen(false);
        UIManager.Instance.ToggleSettingsScreen(false);
        UIManager.Instance.ToggleBackToMenuScreen(false);
        UIManager.Instance.ToggleGuideScreen(false);
        if(is3d)
        {
            HideCursor();
        }
    }

    //Onko pelaaja päävalikossa vai ei
    public void ToggleCanPause(bool value)
    {
        canPause = value;
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
