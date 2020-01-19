using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsSoundMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioMixer audioMixer;
    public Slider MusicSlider;
    public Slider SFXSlider;
    void Start()
    {
        
        MusicSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0);
        SFXSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
    }
    // Start is called before the first frame update
    public void SetMusicSound(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }
    public void SetSFXSound(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
    private void OnDisable()
    {
        float MusicVolume = 0;
        float SFXVolume = 0;
        audioMixer.GetFloat("MusicVolume", out MusicVolume);
        audioMixer.GetFloat("SFXVolume", out SFXVolume);

        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);
        PlayerPrefs.Save();
    }

}
