using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake() 
    {
        if (instance != null)
        {
            Debug.LogError("More then one...");
        }
        instance = this;    
    }
    public GameObject BuildEffect;

    private TurretBlueprint turretToBuild;
    private int randomnum;

    public bool CnaBuild 
    {
        get { return turretToBuild != null;}
        set
        {
            turretToBuild = null;
        }
    }

    public void BuildTurretOn(Node node)
    {
        GameObject.Find("Gacha").GetComponent<RandomSelect>().deck[randomnum].num--;
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        CnaBuild = false;

        GameObject effect = (GameObject) Instantiate(BuildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
    }

    public void SelectTurretToBuild (TurretBlueprint turret, int num)
    {
        turretToBuild = turret;
        randomnum = num;
    }
}
