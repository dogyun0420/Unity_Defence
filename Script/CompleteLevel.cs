using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public SceneFaer sceneFader;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock); //레벨 2 열기
        sceneFader.fadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.fadeTo(menuSceneName);
    }
}
