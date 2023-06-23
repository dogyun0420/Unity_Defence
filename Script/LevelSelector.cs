using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFaer fader;

    public Button[] levelButton;

    void Start() 
    {
        int levelReached = PlayerPrefs.GetInt ("levelReached", 1);

        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButton[i].interactable = false;
        }
    }

    public void Select (string levelName)
    {
        fader.fadeTo (levelName);
    }
}
