using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsGraphic : MonoBehaviour
{

    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Toggle isFullScreenToggle;
    private int resolutionWidth, resolutionHeight;
    
    void Start()
    {

        
        //Get the value for dropdown
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        Debug.Log("In Graphic settings");
        int currentResolution = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            //if (resolutions[i].width == 1024 && resolutions[i].height == 768)
            {
                currentResolution = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolution;
        
        
    }
    // Start is called before the first frame update


    // Update is called once per frame
    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
    public void SetGraphic(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        this.resolutionWidth = resolution.width;
        this.resolutionHeight = resolution.height;
        Debug.Log(this.resolutionWidth + "x" + this.resolutionHeight);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    private void OnDisable()
    {

        PlayerPrefs.SetString("isFullScreen", Screen.fullScreen.ToString());
        PlayerPrefs.SetInt("qualityLevel", QualitySettings.GetQualityLevel());
        PlayerPrefs.SetInt("resolutionWidth", this.resolutionWidth);
        PlayerPrefs.SetInt("resolutionHeight", this.resolutionHeight);
        PlayerPrefs.Save();

    }
}
