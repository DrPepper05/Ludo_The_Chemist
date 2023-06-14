using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public TMP_Text priceText;
    public GameObject EconomyComponent;
    void Start()
    {
        
    }
    void Update()
    {
        priceText.text = "Price: $" + EconomyComponent.GetComponent<Economy>().shopItems[2, ItemID].ToString();
    }
}
