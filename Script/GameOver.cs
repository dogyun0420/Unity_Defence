using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFaer sceneFaer;

    public string menuSceneName = "MainMenu";


    public void Retry()
    {
        sceneFaer.fadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFaer.fadeTo(menuSceneName);
    }
    
}
