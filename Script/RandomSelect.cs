 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSelect : MonoBehaviour
{
    public List<Random>deck = new List<Random>();
    public List<Random>Changedeck = new List<Random>();
    public Random Chagesele;
    public int total = 0;
    public int BuyCost;
    public static int cost;
    public Button Random;
    [Header("Change")]
    public Image selectChangeImage;
    public Button selectChangeButton;
    public Image choiceChangeImage;
    public Button choiceChangeButton;
    public Button ChangeButton;
    int b = 0;
    int ChangeNum = 0;
    bool PushButton;

    public List<Random>changeList = new List<Random>();
    public List<Button>changeCancelButton = new List<Button>();
    public List<Image>changeCancelImage = new List<Image>();
    [Header("Sell")]
    public List<Random>SellList = new List<Random>();
    public List<int>SellNum = new List<int>();
    public List<Text>SellNunText = new List<Text>();
    public List<Image>SellSelectImage = new List<Image>();
    public List<Button>SellCancelButton = new List<Button>();
    public int SellCost = 0;
    public Text TotalSellCost;


    private void seammoney()
    {
        cost = BuyCost;
    }
    public void ResultSelect()// 랜덤 알고리즘 실행
    {
        RandomTurret();
        PlayerStats.Money -= cost;
    }

    public Random RandomTurret() // 랜덤 알고리즘
    {
        int weight = 0;
        int selectNum = 0;
        selectNum = Mathf.FloorToInt(total * UnityEngine.Random.Range(0.0f, 1.0f));
        for (int i = 0; i < deck.Count; i++)
        {
            if (selectNum <= weight)
            {
                Random temp = new Random(deck[i]);
                deck[i].num++;
                return temp;
            }
            weight += deck[i].weight;
        }
        return null;
    }

    void Start()
    {
        for (int i = 0; i<deck.Count; i++)
        {
            total += deck[i].weight;
        }
        SetOffButton();
        seammoney();
        Changedeck.Clear();
        SellList.Clear();
        SellNum.Clear();
        GrayImageSell();
    }

    private void SetOffButton() // 모든 버튼 끄기
    {
        for (int i = 0; i < deck.Count; i++)
            {
                deck[i].billdd[0].interactable = false;
                deck[i].buttonImage.color = new Color(deck[i].buttonImage.color.r, deck[i].buttonImage.color.g, deck[i].buttonImage.color.b, 0.5f);
            }
        selectChangeButton.interactable = false;
        choiceChangeButton.interactable = false;
        ChangeButton.interactable = false;
    }

    private void OnOffButton() //버튼 온오프 관리
    {
        if (PlayerStats.Money < cost)
            Random.interactable = false;
        else
            Random.interactable = true;

        for (int i = 0; i < deck.Count; i++)
        {
            for (int j = 0; j < deck[i].billdd.Count; j++)
            {
                if (deck[i].num > 0)
                {
                    deck[i].billdd[j].interactable = true;
                    deck[i].buttonImage.color = new Color(deck[i].buttonImage.color.r, deck[i].buttonImage.color.g, deck[i].buttonImage.color.b, 1f);
                    deck[i].numText[j].text = deck[i].num.ToString();
                }
                else
                {
                    deck[i].billdd[j].interactable = false;
                    deck[i].buttonImage.color = new Color(deck[i].buttonImage.color.r, deck[i].buttonImage.color.g, deck[i].buttonImage.color.b, 0.5f);
                    deck[i].numText[j].text = deck[i].num.ToString();
                }
            }
        }
        

    }

    void Update()
    {
        OnOffButton();
        changeImageUp();
    }

///////////////////////////////////////////////////////////////////////////////////체인지/////////////////////////////////////////////////////////////
    public void selectChange(Button b)
    {
        
        for (int i = 0; i < deck.Count; i++)
        {
            for(int j = 0; j < deck[i].billdd.Count; j++)
            {
                if (b == deck[i].billdd[j])
                {
                    if (Changedeck.Count == 0)
                    {
                        ChangeSystem(i);
                    }
                    else
                    {
                        deck[ChangeNum].num++;
                        ChangeSystem(i);
                    }
                }  
            }   
        }
    }

    public void ChangeSystem(int i)
    {
        selectChangeButton.interactable = true;
        selectChangeImage.color = new Color(deck[i].buttonImage.color.r, deck[i].buttonImage.color.g, deck[i].buttonImage.color.b, 1f);
        selectChangeImage.sprite = deck[i].buttonImage.sprite;
        deck[i].num--;
        ChangeNum = i;
        for (int w = 0; w < deck.Count; w++)
        {
            if (deck[i].weight == deck[w].weight)
            {
                Changedeck.Add(deck[w]);
            }
        }
    }

    public void cancelChange()
    {
        deck[ChangeNum].num++;
        selectChangeImage.color = Color.gray;
        selectChangeImage.sprite = null;
        selectChangeButton.interactable = false;
        ChangeNum = 0;
    }

    public void Change()
    {
        if (Changedeck.Count > 0)
        {
            Chagesele = Changedeck[UnityEngine.Random.Range(0,Changedeck.Count)];
            choiceChangeImage.color = new Color(Chagesele.buttonImage.color.r, Chagesele.buttonImage.color.g, Chagesele.buttonImage.color.b, 1f);
            choiceChangeImage.sprite = Chagesele.buttonImage.sprite;
            choiceChangeButton.interactable = true;
            selectChangeButton.interactable = false;
        }
    }

    public void choiceChange()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            if (Chagesele.TurretName == deck[i].TurretName)
            {
                Changedeck.Clear();
                selectChangeImage.color = Color.gray;
                selectChangeImage.sprite = null;
                choiceChangeImage.color = Color.gray;
                choiceChangeImage.sprite = null;
                selectChangeButton.interactable = false;

                deck[i].num++;
                Changedeck.Clear();
                choiceChangeButton.interactable = false;
            }
        }
    }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
public void SelsectChange0(Button ChangeButton)
{
    if (changeList.Count == 0)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            for (int j = 0; j < deck[i].billdd.Count; j++)
            {
                if (ChangeButton == deck[i].billdd[j])
                {
                    deck[i].num--;
                    changeList.Add(deck[i]);
                }
            }
        }
    }
    else if (changeList.Count == 1)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            for (int j = 0; j < deck[i].billdd.Count; j++)
            {
                if (ChangeButton == deck[i].billdd[j])
                {
                    if (deck[i].weight == changeList[0].weight)
                    {
                        deck[i].num--;
                        changeList.Add(deck[i]);
                        ChangeButton.interactable = true;
                    }
                    else
                        Debug.Log("!!!!!!");
                }
            }
        }
    }
}

public void changeImageUp()
{
    if (changeList.Count == 0)
    {
        GrayImageChange();
    }
    else
    {
        for (int i = 0; i < changeList.Count; i++)
        {
            changeCancelButton[i].interactable = true;
            changeCancelImage[i].color= new Color(changeList[i].buttonImage.color.r, changeList[i].buttonImage.color.g, changeList[i].buttonImage.color.b, 1f);
            changeCancelImage[i].sprite = changeList[i].buttonImage.sprite;
        }
    }

}


private void GrayImageChange()
{
    for (int i = 0; i < changeCancelButton.Count; i++)
    {
        changeCancelButton[i].interactable = false;
        changeCancelImage[i].color = Color.gray;
        changeCancelImage[i].sprite = null;
    }
}

/////////////////////////////////////////////////////////////////////판매/////////////////////////////////////////////////////////////////////////////////////////
    private void GrayImageSell()
    {
        for (int i = 0; i < SellSelectImage.Count; i++)
        {
            SellCancelButton[i].interactable = false;
            SellSelectImage[i].color = Color.gray;
            SellSelectImage[i].sprite = null;
            SellNunText[i].text = ("0");
        }
    }
    
    public void selectSell(Button SellButton)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            for(int j = 0; j < deck[i].billdd.Count; j++)
            {
                if (SellButton == deck[i].billdd[j])
                {
                    if (SellList.Contains(deck[i]))
                    {
                        deck[i].num--;
                        for (int m = 0; m < SellList.Count; m++)
                        {
                            if(SellList[m].TurretName == deck[i].TurretName)
                            {
                                SellNum[m]++;
                                SellNunText[m].text = SellNum[m].ToString();
                                SellCostUpDate();
                            }
                        }
                        Debug.Log("======");
                    }
                    else
                    {
                        deck[i].num--;
                        SellList.Add(deck[i]);
                        SellNum.Add(1);
                        SellCancelButton[SellList.Count-1].interactable = true;
                        //SellNunText[SellList.Count-1].text = SellNum[SellList.Count-1].ToString();
                        SellSelectImage[SellList.Count-1].color= new Color(deck[i].buttonImage.color.r, deck[i].buttonImage.color.g, deck[i].buttonImage.color.b, 1f);
                        SellSelectImage[SellList.Count-1].sprite = deck[i].buttonImage.sprite;
                        SellCostUpDate();
                        Debug.Log("!!!!!!!!!!!!");
                    }
                    
                }
            }
        }
    }

    public void SellCostUpDate()
    {
        int tteemmpp = 0;
        for (int i = 0; i < SellList.Count; i++)
        {
            tteemmpp = tteemmpp + (SellList[i].TurretName.cost * SellNum[i]);
            SellNunText[i].text = SellNum[i].ToString();
        }
        SellCost = tteemmpp;
        TotalSellCost.text = "+" + SellCost.ToString() + "$";
    }

    public void SellPush()
    {
        if (SellCost > 0)
        {
            PlayerStats.Money += SellCost;
            SellCost = 0;
            SellList.Clear();
            SellNum.Clear();
            GrayImageSell();
            SellCostUpDate();
        }
        else
            Debug.Log("NOT THING");
    }

    public void CancelSellButton(Button Cancel)
    {
        int IndexNum = SellCancelButton.IndexOf(Cancel);
        Debug.Log(IndexNum);
        for (int i = 0; i < deck.Count; i++)
        {
            if (SellList[IndexNum].TurretName == deck[i].TurretName)
            {
                SellNum[IndexNum]--;
                deck[i].num++;
            }
        }
        if (SellNum[IndexNum] == 0)
        {
            for (int i = IndexNum; i < SellList.Count; i++)
            {
                if (i == SellList.Count+1)
                {
                    SellCancelButton[i].interactable = false;
                    SellSelectImage[i].color = Color.gray;
                    SellSelectImage[i].sprite = null;
                    
                }
                else
                {
                    SellCancelButton[i].interactable = SellCancelButton[i+1].interactable;
                    SellSelectImage[i].color = SellSelectImage[i+1].color;
                    SellSelectImage[i].sprite = SellSelectImage[i+1].sprite;
                }
            }
            SellNum.RemoveAt(IndexNum);
            SellList.RemoveAt(IndexNum);
        }
        SellCostUpDate();
    }

    
///////////////////////////////////////////////////////////건설////////////////////////////////////////////////////////////////////

    public void BilldTurret(Button a) // 버튼 클릭 확인 후 짓기
    {
        
        for (int i = 0; i < deck.Count; i++)
        {
            if (a == deck[i].billdd[0])
            {
                deck[i].buildManger.SelectTurretToBuild(deck[i].TurretName, i);
            }     
        }
    }
}



