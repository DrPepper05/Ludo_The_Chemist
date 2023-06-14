using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject Shop;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 1.5f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                NPCInteraction npcInteraction = collider.GetComponent<NPCInteraction>();
                if (npcInteraction != null)
                {
                    npcInteraction.ActivatePrefab();                
                }
                ShopInteractable shopInteraction = collider.GetComponent<ShopInteractable>();
                if (shopInteraction != null)
                {
                    shopInteraction.OpenShop();  
                    Shop.GetComponent<ShopUI>().shopState = true;            
                }
            }
        }
    }
    public NPCInteraction GetInteractableObject(){
        List<NPCInteraction> npcInteractableList = new List<NPCInteraction>();
            float interactRange = 1.5f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                NPCInteraction npcInteraction = collider.GetComponent<NPCInteraction>();
                if (npcInteraction != null)
                {
                    npcInteractableList.Add(npcInteraction);
                    return npcInteraction;              
                }
            }
            return null;
            NPCInteraction closestNPCInteraction = null;
            foreach(NPCInteraction npcInteraction in npcInteractableList)
            {
                if(closestNPCInteraction == null)
                    closestNPCInteraction = npcInteraction;
                else
                    if(Vector3.Distance(transform.position, npcInteraction.transform.position) < Vector3.Distance(transform.position, closestNPCInteraction.transform.position))
                        closestNPCInteraction = npcInteraction;

            }
            return closestNPCInteraction;
     }   
}
