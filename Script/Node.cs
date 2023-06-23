using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
 
    [Header("optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (!buildManager.CnaBuild)
            return;
        if (turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        buildManager.BuildTurretOn(this);
        
        
    }

    void OnMouseEnter() 
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(!buildManager.CnaBuild)
            return;

        rend.material.color = hoverColor;
    }

    void OnMouseExit() 
    {
        rend.material.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
