using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;


/// Hallitsee käyttöliittymään liittyviä asioita, asetukset ja muut

[RequireComponent(typeof(DontDestroyOnLoad))]
public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMP_Text sceneList;
    private bool canLoad;
    [SerializeField] private TMP_InputField SceneInputField;

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
}


