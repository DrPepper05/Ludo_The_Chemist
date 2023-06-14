using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighscoreCounter : MonoBehaviour
{
    float score = 0;
    public TMP_Text scoreText;
    public TMP_Text moneyText;
    public TMP_Text highScoreText;
    public static float highScore;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
       
    }
    void Update()
    {
        float monero = Economy.money;
        int customerCounty = CustomerCounter.customerCount;
    
        score = monero * customerCounty;
    
        scoreText.text = score.ToString();
        moneyText.text = monero.ToString() + "$";
        highScoreText.text = highScore.ToString();
        if (score > highScore)
        {
            highScore = score;
        }
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("highScore", highScore);
        PlayerPrefs.Save();
    }
}
