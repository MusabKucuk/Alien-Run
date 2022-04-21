using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource onGoingAudio, dead, fire, jump;
    public AudioSource[] allAudioSources;
    private bool isPaused = false;

    public void playDeadSound()
    {
        onGoingAudio.enabled = !onGoingAudio.enabled;
        dead.Play();
    }

    public void playFireSound()
    {
        fire.Play();
    }

    public void playJumpSound()
    {
        jump.Play();
    }

    public void PauseResumeAudio()
    {
        if (Time.timeScale == 0f)
        {
            foreach (var item in allAudioSources)
            {
                item.Pause();
                isPaused = true;
            }
        }

        if(Time.timeScale == 1f && isPaused)
        {
            foreach (var item in allAudioSources)
            {
                item.UnPause();
                isPaused = false;
            }
        }
    }

    public void Update()
    {
        PauseResumeAudio();
    }
}
