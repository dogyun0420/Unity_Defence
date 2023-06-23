using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UPBluePrint
{
    public int Upcost;
    public Button UpButton;
    public int Level;
    public List<GameObject> Bullet = new List<GameObject>();
    public Text LevelText;

    public UPBluePrint(UPBluePrint upblueprint)
    {
        this.Upcost = upblueprint.Upcost;
        this.UpButton = upblueprint.UpButton;
        this.Level = upblueprint.Level;
    }
}
