using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";
    public SceneFaer sceneFaer;
    public void Play()
    {
        sceneFaer.fadeTo(levelToLoad);
    }
}
