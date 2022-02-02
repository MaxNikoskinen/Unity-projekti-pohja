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
    [System.Serializable]
    public class LevelData
    {
        public string LevelName; 
        public SceneReference Scene;
    }

    private string sceneList;
    [SerializeField] private LevelData MainMenu;
    [SerializeField] private List<LevelData> Levels = new List<LevelData>();

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
            sceneList += ", " + data.LevelName.ToString();
        }
        UIManager.Instance.UpdateSceneList("Main Menu" + sceneList);
    }
    
    //Lataa skene kirjoittamalla sille levelmanageriin asetettu nimi
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
            
        }
        else //Tee jos skene ei ole päävalikko
        {
            
        }
    }
}
