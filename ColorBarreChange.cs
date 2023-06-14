using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBarreChange : MonoBehaviour
{

   
private void OnTriggerEnter(Collider other)
{
    if(other.transform.childCount != 0)
        if (other.transform.GetChild(0).tag == "rawMaterial" )
        {
               other.transform.GetChild(0).tag = this.tag;
       
        }

}
}

