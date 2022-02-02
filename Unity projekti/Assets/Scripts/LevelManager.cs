using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

//Sallii vaihtamisen skenejen välillä helposti
[RequireComponent(typeof(DontDestroyOnLoad))]
public class LevelManager : Singleton<LevelManager>
{
    // Serialzied class that allows you to create a specific level data
    [System.Serializable]
    public class LevelData
    {
        public string LevelName; 
        public SceneReference Scene;
    }

    private string sceneList;
    [SerializeField] private LevelData MainMenu;                                    // LevelData for the Main Menu
    [SerializeField] private List<LevelData> Levels = new List<LevelData>();        // LevelData list for all the levels in the game

    void Start()
    {
        SceneManager.sceneLoaded += OnLevelLoaded; // When ever a new scene file is loaded, the OnLevelLoaded event is called

        // If the Main Menu Scene is not assigned, add a warning message to the console
        if (MainMenu.Scene == null) 
        {
            Debug.LogWarning("No main menu detected");
            return;
        }

        //Lataa päävalikon, kun peli käynnistyy
        LoadMainMenu();

        //Näyttää skenet skenenlatausruudussa
        UIManager.Instance.UpdateSceneList("");
        foreach (LevelData data in Levels)
        {
            sceneList += ", " + data.LevelName.ToString();
        }
        UIManager.Instance.UpdateSceneList("Main Menu" + sceneList);
    }

    /// <summary>
    /// Load Level usign the name set in the LevelData class.
    /// </summary>
    /// <param name="name">Nimi on tämä</param>
    public void LoadLevel(string name)
    {
        foreach (LevelData data in Levels)
        {
            if(data.LevelName.Equals(name))
            {
                SceneManager.LoadScene(data.Scene);
                return;
            }
            if(name == "Main Menu")
            {
                LoadMainMenu();
            }
        }
    }

    /// <summary>
    /// Loads the Main Menu scene
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu.Scene);
    }

    /// <summary>
    /// Load Level usign a SceneReference asset
    /// </summary>
    /// <param name="scene"></param>
    public void LoadLevel(SceneReference scene)
    {
        Debug.Log("ASD");
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// OnLevelLoaded is called when ever a new scene is loaded
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        // If the Main Menu is loaded, hide the in game HUD and show the Options UI
        // else, hide Options UI and show the HUD
        if (scene.path == MainMenu.Scene.ScenePath)
        {/*
            UIManager.Instance.ToggleHUD(false);
            UIManager.Instance.ToggleOptionsUI(true);
        }
        else
        {
            UIManager.Instance.ToggleHUD(true);
            UIManager.Instance.ToggleOptionsUI(false);*/
        }
    }
}
