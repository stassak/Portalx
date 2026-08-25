using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class ApplyySettings : MonoBehaviour
{
    public AudioMixer mainMixer;
    //  public AudioMixerGroup gameMixer;

    void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            mainMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
        }

        if (PlayerPrefs.HasKey("fullscreen"))
        {
            Screen.fullScreen = PlayerPrefs.GetInt("fullscreen") == 1;
        }

        if (PlayerPrefs.HasKey("quality"))
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
        }


    }
}
