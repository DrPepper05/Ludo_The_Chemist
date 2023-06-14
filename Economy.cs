using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Economy : MonoBehaviour
{
    public int[,] shopItems = new int [10,10];
    static public float money=100;
    public TMP_Text moneytext;
    public TMP_Text moneytextshop;
    void Start()
    {
        
        shopItems[1,1] = 1;
        shopItems[1,2] = 1;
        shopItems[1,3] = 1;
        shopItems[1,4] = 1;
        shopItems[1,5] = 1;
        shopItems[1,6] = 1;
        shopItems[1,7] = 1;

        shopItems[2,1] = 5;
        shopItems[2,2] = 1;
        shopItems[2,3] = 3;
        shopItems[2,4] = 2;
        shopItems[2,5] = 10;
        shopItems[2,6] = 3;
        shopItems[2,7] = 2;
    }
    void Update()
    {
        moneytext.text = "Money: " + money.ToString() + "$";
        moneytextshop.text = moneytext.text;

    }
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if(money>= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            money -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            moneytext.text = "Money: " + money.ToString() + "$";
            moneytextshop.text = moneytext.text;

        }
    }
}
