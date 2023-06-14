using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private string interactText;
    private Animator animator;
    public GameObject req;
    public int prevReq;
    public bool canOrder = true;
    public GameObject PlayerInteract;
    private void Awake(){
        animator = GetComponent<Animator>();
    }
    public void ActivatePrefab()
    {
        if (canOrder == true)
        {
            var randomNumber = Random.Range(0, 18);
            req.transform.GetChild(randomNumber).gameObject.SetActive(true);
            req.transform.GetChild(prevReq).gameObject.SetActive(false);
            req.tag = req.transform.GetChild(randomNumber).gameObject.tag;
            prevReq = randomNumber;
            canOrder = false;
        }
            animator.SetTrigger("hello");
    }
    public string GetInteractText(){
        return interactText;
    }
}