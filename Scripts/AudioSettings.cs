using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public GameObject mute;
    public GameObject unmute;
    float volumeValue = 5f;
    int muted = 0;

    private void muteButton()
    {
        mute.SetActive(false);
        unmute.SetActive(true);
    }

    private void unmuteButton()
    {
        mute.SetActive(true);
        unmute.SetActive(false);
    }

    public void muteVolume()
    {
        volumeValue = 0f;
        muted = 1;
        muteButton();
        PlayerPrefs.SetFloat("Volume", volumeValue);
        PlayerPrefs.SetInt("Muted", muted);
        AudioListener.volume = volumeValue;
    }

    public void unmuteVolume()
    {
        volumeValue = 5f;
        muted = 0;
        unmuteButton();
        PlayerPrefs.SetFloat("Volume", volumeValue);
        PlayerPrefs.SetInt("Muted", muted);
        AudioListener.volume = volumeValue;
    }

    public void Start()
    {
        volumeValue = PlayerPrefs.GetFloat("Volume");
        muted = PlayerPrefs.GetInt("Muted");
        AudioListener.volume = volumeValue;

        if (muted == 0)
            unmuteButton();
        
        if (muted == 1)
            muteButton();
    }
}
