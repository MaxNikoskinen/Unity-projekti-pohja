using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sisältää asioita pelissä yleisesti käytettäviin asioihin esim. pelaaja ja rahamäärä

[RequireComponent(typeof(DontDestroyOnLoad))]
public class GameManager : Singleton<GameManager>
{
    [SerializeField] private bool is3d;

    private GameObject playerReference;

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
    private int randomValue;

    private void Start()
    {
        randomValue = Random.Range(0, 10000);
    }

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
        Time.timeScale = 1;
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
        Time.timeScale = 0;
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

    public int GetRandomValue()
    {
        return randomValue;
    }

    public GameObject player
    {
        get
        {
            return playerReference;
        }
        set
        {
            playerReference = value;
            Debug.Log("Player added to gamemanager", value);
        }
    }

    public bool GetIsPaused()
    {
        return isPaused;
    }

    public bool GetIs3d()
    {
        return is3d;
    }
}
