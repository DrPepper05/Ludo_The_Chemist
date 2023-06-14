using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject mainMenu;
    public Slider slider;
    public TMP_Text highScoretext;
    bool isFirstTime;
    public void Awake()
    {
         isFirstTime = PlayerPrefs.GetInt("FirstTime", 1) == 1;
        
    }
    public void Start()
    {
        HighscoreCounter.highScore = PlayerPrefs.GetFloat("highScore");
        highScoretext.text = HighscoreCounter.highScore.ToString();
    }
    public void PlayGame(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        mainMenu.SetActive(false);
        StartCoroutine(WaitAndLoadScene(sceneIndex));
    }

    IEnumerator WaitAndLoadScene(int sceneIndex)
    {
        yield return new WaitForSeconds(10f); // Add a 10-second delay

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Se inchide jocu");
        Application.Quit();
    }
}