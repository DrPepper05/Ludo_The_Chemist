using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject camera;
    public GameObject shop;
    public GameObject pauseMenuUI;
    public static bool Paused = false;
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    void Start()
{
    int currentResolutionIndex = 0;
    resolutions = Screen.resolutions;

    System.Array.Reverse(resolutions);

    resolutionDropdown.ClearOptions();
    List<string> options = new List<string>();
    for (int i = 0; i < resolutions.Length; i++)
    {
        string option = resolutions[i].width + " x " + resolutions[i].height;
        options.Add(option);
        if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
        {
            currentResolutionIndex = i;
        }
    }
    resolutionDropdown.AddOptions(options);
    resolutionDropdown.value = currentResolutionIndex;
    resolutionDropdown.RefreshShownValue();
}
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void SetSensitivity (float sens)
    {
        camera.GetComponent<FirstPersonCamera>().sens = sens;
    }
    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen Off/On");
    }
    public void QuitGame()
    {
        Debug.Log("§Se inchide jocu§");
        Application.Quit();
    }
    void Update(){
        
    if (Paused && pauseMenuUI != null)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    } 
    if(Paused==false && shop.GetComponent<ShopUI>().shopState == false)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
        if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(Paused)
                {
                    Resume();
                    if(shop.GetComponent<ShopUI>().shopState == false)
                        Cursor.visible = false;
                }
                else
                {   if (shop.GetComponent<ShopUI>().shopState == false)
                        Pause();
                }
            }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("Loading Menu...");
    }

}
