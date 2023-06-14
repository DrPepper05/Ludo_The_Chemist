using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteractable : MonoBehaviour
{
    public GameObject shop;
    public Camera mainCamera;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OpenShop()
    {
        Time.timeScale = 0f;
        shop.GetComponent<ShopUI>().shopState = true;
        shop.SetActive(true);
    }
}
