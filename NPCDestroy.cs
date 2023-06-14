using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject startPosition;

    private void OnTriggerEnter(Collider col)
    {
    if (col.gameObject.tag == "NPC")
    {
            col.gameObject.SetActive(false);
            col.GetComponent<NPCMovement>().canBereplaced = true;
            col.transform.position = startPosition.transform.position;
            col.gameObject.SetActive(true);
            }
    }
}

