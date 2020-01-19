using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPauesd = false;
    public GameObject pauseMenuUI;
    public GameObject settingMenuUI;
    public GameObject settingSoundMenuUI;
    public GameObject settingGraphicMenuUI;
    public GameObject settingControlsMenuUI;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if button is pressed and it's true, it's ok to start game again
            if (GameIsPauesd)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        settingMenuUI.SetActive(false);
        settingSoundMenuUI.SetActive(false);
        settingGraphicMenuUI.SetActive(false);
        settingControlsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPauesd = false;
    }
    void Pause() 
    {
        pauseMenuUI.SetActive (true);
        Time.timeScale = 0f;
        GameIsPauesd = true;
    }
    public void LoadMainMenu()
    { 
        Debug.Log("Loading Main");
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadSettingMenu() 
    {
        Debug.Log("Loading Setting");

    }

}
