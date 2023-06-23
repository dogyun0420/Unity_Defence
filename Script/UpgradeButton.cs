using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public List<UPBluePrint>Level = new List<UPBluePrint>();
    void Start()
    {
        for (int i = 0; i<Level.Count; i++)
        {
            Level[i].Level = 1;
            for (int j = 0; j < Level[i].Bullet.Count; j++)
                {
                    Level[i].Bullet[j].GetComponent<Bullet>().damage = Level[i].Bullet[j].GetComponent<Bullet>().Damage;
                }
        }
    }

    void Update()
    {
        OnOffButton();
        LVText();
    }

    public void LVText()
    {
        for (int i = 0; i < Level.Count; i++)
        {
            Level[i].LevelText.text = "LV." + Level[i].Level.ToString();
        }
    }


    public void OnOffButton()
    {
        for (int i = 0; i < Level.Count; i++)
        {
            if (PlayerStats.Money >= Level[i].Upcost)
                Level[i].UpButton.interactable = true;
            else
                Level[i].UpButton.interactable = false;
        }
    }
    public void Upgrade(Button a)
    {
        for (int i = 0; i < Level.Count; i++)
        {
            if (a == Level[i].UpButton)
            {
                PlayerStats.Money -= Level[i].Upcost;
                Level[i].Level++;
                for (int j = 0; j < Level[i].Bullet.Count; j++)
                {
                    Level[i].Bullet[j].GetComponent<Bullet>().damage = Level[i].Bullet[j].GetComponent<Bullet>().Damage * Level[i].Level;
                }
                Level[i].Upcost = Level[i].Upcost+10;
            }     
        }
    }
}
