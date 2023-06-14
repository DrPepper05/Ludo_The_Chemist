using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerCounter : MonoBehaviour
{
    static public int customerCount = 0;
    void Update()
    {
        Debug.Log(customerCount);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            customerCount++;
        }
    }
}
