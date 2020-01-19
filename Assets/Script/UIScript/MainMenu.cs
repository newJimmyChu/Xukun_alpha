using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        Debug.Log("in the start menu");
        Screen.SetResolution(PlayerPrefs.GetInt("resolutionWidth", Screen.currentResolution.width), PlayerPrefs.GetInt("resolutionHeight", Screen.currentResolution.height), bool.Parse(PlayerPrefs.GetString("isFullScreen", "false")));
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityLevel", 1));
        //Debug.Log(Screen.currentResolution.width + "x" + Screen.currentResolution.height);
    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
    }
    public void QuitGame() {

        Debug.Log("quit");
       
        Application.Quit();
    
    
    }
    // Start is called before the first frame update
   
}
