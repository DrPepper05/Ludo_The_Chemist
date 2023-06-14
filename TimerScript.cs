using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public Text TimerTxt;
    public GameObject gameobjectoftimer;
    void Start()
    {
        TimerOn = false;
        gameobjectoftimer.SetActive(false);
    }

    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                gameobjectoftimer.SetActive(true);
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
            }
        }
        if(TimeLeft == 0)
            gameobjectoftimer.SetActive(false);
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        TimerTxt.text = string.Format("Time for Delivery {0:00} : {1:00} ", minutes, seconds);
    }
}
