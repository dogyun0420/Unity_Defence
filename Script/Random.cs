using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TurretGrade{cat, dog, pang}

[System.Serializable]
public class Random
{
    public TurretBlueprint TurretName;
    //public Button billdd;
    public List<Button> billdd = new List<Button>();
    public Image buttonImage;
    //public Text numText;
    public List<Text> numText = new List<Text>();
    public TurretGrade turretGrade;
    public int weight;
    public int num;
    public BuildManager buildManger;
    
    
    
    public Random(Random random)
    {
        this.TurretName = random.TurretName;
        this.billdd = random.billdd;
        this.buttonImage = random.buttonImage;
        this.numText = random.numText;
        this.turretGrade = random.turretGrade;
        this.weight = random.weight;
        this.num = random.num;
        buildManger = BuildManager.instance;
    }
    
}
