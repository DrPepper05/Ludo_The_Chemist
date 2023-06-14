using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractUI : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public GameObject timer;
    public GameObject npc;
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private Interaction playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;
    public bool canInteract = true;

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null)
        {
            if (timer.GetComponent<TimerScript>().gameobjectoftimer.activeSelf == false)
            {
                if (npc.transform.rotation.eulerAngles.y > 80f)
                {
                    Show(playerInteract.GetInteractableObject());
                }
            }
            if (canInteract && Input.GetKeyDown(KeyCode.E) && npc.GetComponent<Rigidbody>().velocity == Vector3.zero)
            {
                Hide();
                timer.GetComponent<TimerScript>().TimerOn = true;
                timer.GetComponent<TimerScript>().gameobjectoftimer.SetActive(true);
                canInteract = false;
            }
        }
        else
        {
            Hide();
            canInteract = false;
        }
    }

    private void Show(NPCInteraction npcInteraction)
    {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = npcInteraction.GetInteractText();
        canInteract = true;
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
        canInteract = false;
    }
}