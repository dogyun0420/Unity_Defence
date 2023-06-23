using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    BuildManager buildManger;

    void Start() 
    {
        buildManger = BuildManager.instance;
        
    }
    public void SelectStandaedTurret()
    {
        //buildManger.SelectTurretToBuild(standardTurret);
    }
    public void SelectAnotherTurret()
    {
       // buildManger.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaserBeamerTurret()
    {
        //buildManger.SelectTurretToBuild(laserBeamer);
    }
}
