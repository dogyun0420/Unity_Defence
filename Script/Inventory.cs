using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject UpgradeInventory;
    public GameObject ChangeInventory;
    public GameObject SellInventory;
    // Start is called before the first frame update
    void Start()
    {
        hind();
        UpgradeInventory.SetActive(true);
    }

    public void upgrad()
    {
        hind();
        UpgradeInventory.SetActive(true);
    }

    public void change()
    {
        hind();
        ChangeInventory.SetActive(true);
    }

    public void sell()
    {
        hind();
        SellInventory.SetActive(true);
    }

    void hind()
    {
        UpgradeInventory.SetActive(false);
        ChangeInventory.SetActive(false);
        SellInventory.SetActive(false);
    }

}
