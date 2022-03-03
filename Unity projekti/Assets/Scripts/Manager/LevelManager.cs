using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Sallii vaihtamisen skenejen välillä helposti

[RequireComponent(typeof(DontDestroyOnLoad))]
public class LevelManager : Singleton<LevelManager>
{
    [System.Serializable]
    public class LevelData
    {
        public string LevelName; 
        public SceneReference Scene;
    }

    private string sceneList;
    [SerializeField] private LevelData MainMenu;
    [SerializeField] private List<LevelData> Levels = new List<LevelData>();

    private bool isInMenu;

    void Start()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;

        //Jos päävalikkoaskeneä ei ole asetettu, laita ilmoitus konsoliin
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
            sceneList += ", " + data.LevelName;
        }
        UIManager.Instance.UpdateSceneList(MainMenu.LevelName + sceneList);
    }
    
    //Lataa skene kirjoittamalla sille levelmanageriin asetettu nimi
    public void LoadLevel(string name)
    {
        foreach (LevelData data in Levels)
        {
            if (data.LevelName.Equals(name))
            {
                SceneManager.LoadScene(data.Scene);
                return;
            }
        }

        if (name.Equals(MainMenu.LevelName))
        {
            LoadMainMenu();
        }
        else if (name == "")
        {
            return;
        }
        else
        {
            Debug.Log("Scene \"" + name + "\" doesn't exist in the level manager");
            UIManager.Instance.WarnIfNoScene(name);
        }
    }

    //Metodi jolla ladataan päävalikko
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu.Scene);
    }

    //Lataa taso käyttäen skenereferenseä
    public void LoadLevel(SceneReference scene)
    {
        SceneManager.LoadScene(scene);
    }

    //Eventti jolla voi tietää kun skene ladataan
    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        //Tee jos skene on päävalikko
        if (scene.path == MainMenu.Scene.ScenePath)
        {
            GameManager.Instance.ToggleCanPause(false);

            UIManager.Instance.ToggleMainMenuScreen(true);

            bool isPaused = GameManager.Instance.GetIsPaused();
            if(isPaused)
            {
                GameManager.Instance.ResumeGame();
            }
            isInMenu = true;

            bool is3d = GameManager.Instance.GetIs3d();
            if (is3d)
            {
                GameManager.Instance.ShowCursor();
            }
        }
        else //Tee jos skene ei ole päävalikko
        {
            GameManager.Instance.ToggleCanPause(true);

            UIManager.Instance.ToggleMainMenuScreen(false);

            isInMenu = false;

            bool is3d = GameManager.Instance.GetIs3d();
            if(is3d)
            {
                GameManager.Instance.HideCursor();
            }
        }
    }

    //
    public bool MenuDetect()
    {
        return isInMenu;
    }
}
