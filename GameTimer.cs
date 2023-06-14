using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float gameTimeLeft;
    public bool gameTimerOn = false;
    public TMP_Text gameTimerTxt;
    public GameObject gameobjectoftimer;
    void Start()
    {
        gameTimerOn = true;
        gameobjectoftimer.SetActive(true);
    }

    void Update()
    {
        if(gameTimerOn)
        {
            if(gameTimeLeft > 0)
            {
                gameobjectoftimer.SetActive(true);
                gameTimeLeft -= Time.deltaTime;
                updateTimer(gameTimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                gameTimeLeft = 0;
                gameTimerOn = false;
            }
        }
        if(gameTimeLeft == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);
        gameTimerTxt.text = string.Format("Game Time Left {0:00} : {1:00} ", minutes, seconds);
    }
}

