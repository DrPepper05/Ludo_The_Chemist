using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
   
    public Transform cameraPosition;
    void Update()
    {
        transform.position = cameraPosition.position;
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            cameraPosition.position = Vector3.Lerp(cameraPosition.position, cameraPosition.position - new Vector3(0, 0.5f, 0) ,2f);
            Debug.Log("Pepsi");
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            cameraPosition.position += new Vector3(0, 0.5f, 0);

        }

    }
}
