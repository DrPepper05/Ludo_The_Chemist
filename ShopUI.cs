using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject Shop;
    public bool shopState = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Shop != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } 
    }
    public void Exit()
    {   Time.timeScale = 1f;
        Debug.Log("Shop Exited");
        Shop.SetActive(false);
        shopState = false;
    }
}
