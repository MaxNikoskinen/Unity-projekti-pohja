using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

// Hallitsee käyttöliittymään liittyviä asioita, asetukset ja muut

[RequireComponent(typeof(DontDestroyOnLoad))]
public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMP_Text sceneList;
    private bool canLoad;
    [SerializeField] private TMP_InputField SceneInputField;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject backToMenuScreen;
    [SerializeField] private GameObject guideScreen;
    [SerializeField] private GameObject quitGameScreen;
    [SerializeField] private GameObject sceneLoadingScreen;
    [SerializeField] private TMP_Text noSceneWarningText;
    [SerializeField] private GameObject noSceneWarning;

    private void Update()
    {
        //Lataa skene skenenlatausruudussa
        if(canLoad && Input.GetKeyDown(KeyCode.Return))
        {
            LevelManager.Instance.LoadLevel(SceneInputField.text);
            SceneInputField.text = "";
            SceneInputField.Select();
            SceneInputField.ActivateInputField();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            bool isInMenu = LevelManager.Instance.MenuDetect();
            if (isInMenu)
            {
                mainMenuScreen.SetActive(true);
                settingsScreen.SetActive(false);
                guideScreen.SetActive(false);
                quitGameScreen.SetActive(false);
            }
            sceneLoadingScreen.SetActive(false);
            ToggleCanLoad(false);
        }
    }

    //Onko pelaaja skenenlatausruudussa
    public void ToggleCanLoad(bool value)
    {
        canLoad = value;
    }

    //Metodi skenenlatausruudun skeneluettelon päivittämiselle
    public void UpdateSceneList(string list)
    {
        sceneList.text = list;
    }

    //Ota pelin pysäytysruutu käyttöön / pois
    public void TogglePauseScreen(bool value)
    {
        pauseScreen.SetActive(value);
    }

    //Ota päävalikko käyttöön / pois
    public void ToggleMainMenuScreen(bool value)
    {
        mainMenuScreen.SetActive(value);
    }

    //
    public void ToggleSettingsScreen(bool value)
    {
        settingsScreen.SetActive(value);
    }

    //
    public void ToggleBackToMenuScreen(bool value)
    {
        backToMenuScreen.SetActive(value);
    }

    //
    public void ToggleGuideScreen(bool value)
    {
        guideScreen.SetActive(value);
    }

    //
    public void BackToMenu()
    {
        bool isInMenu = LevelManager.Instance.MenuDetect();
        if(isInMenu)
        {
            mainMenuScreen.SetActive(true);
        }
        else
        {
            pauseScreen.SetActive(true);
        }
    }

    //
    public void WarnIfNoScene(string name)
    {
        noSceneWarning.SetActive(true);
        noSceneWarningText.text = "Skeneä \"" + name + "\" ei ole olemassa";
    }
}


