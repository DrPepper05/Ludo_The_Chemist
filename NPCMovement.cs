using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 2f;
    private Animator animator;
    private Vector3 previousPosition;
    public GameObject timer;
    private TimerScript timerScript;
    public bool taskCompleted;
    public bool canBereplaced;
    public GameObject startPosition;

    void Start()
    {
        timerScript = timer.GetComponent<TimerScript>();
        animator = GetComponent<Animator>();
        previousPosition = transform.position;
    }

    void Update()
    {
        if (timerScript.TimeLeft == 0 || taskCompleted == true)
        {
            ChangeWaypoints();
            taskCompleted = false;
            timerScript.TimeLeft = 60 ;
            timerScript.gameobjectoftimer.SetActive(false); 
            var prevPos = this.gameObject.GetComponent<NPCInteraction>().prevReq;
            this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(prevPos).gameObject.SetActive(false);

        }
        if(canBereplaced)
        {
            ChangeWaypoints();
            canBereplaced = false;
        }
    

        int index = 0;
        Vector3 targetPosition = waypoints[index].transform.position;
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = newPosition;

        // Rotate towards the target waypoint
        Vector3 direction = targetPosition - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            Quaternion newRotation = targetRotation * Quaternion.Euler(0,90,0);
            transform.rotation = newRotation;
        }

        Vector3 currentPosition = transform.position;
        Vector3 displacement = currentPosition - previousPosition;
        float velocity = displacement.magnitude / Time.deltaTime;
        previousPosition = currentPosition;

        animator.SetFloat("speed", velocity);

    }
    public void ChangeWaypoints()
    {
        var aux = waypoints[0];
        waypoints[0] = waypoints[1];
        waypoints[1] = aux;

    }
}