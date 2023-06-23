using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFaer sceneFaer;
    public string menuSceneName = "MainMenu";
    void Update()
    {
        puase();
    }

    public void PausePush()
    {
        ui.SetActive(!ui.activeSelf);
        puase();
    }

    public void Retry()
    {
        ui.SetActive(!ui.activeSelf);
        sceneFaer.fadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        ui.SetActive(!ui.activeSelf);
        sceneFaer.fadeTo(menuSceneName);
    }
    

    public void puase()
    {
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
