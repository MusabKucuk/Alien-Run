using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private AnimationController animationController;
    private AudioController audioController;
    public GameObject MainMenu;
    public GameObject OptionsMenu;

    private IEnumerator FireAnim()
    {
        animationController = GetComponentInChildren<AnimationController>();
        audioController = GetComponentInChildren<AudioController>();
        Time.timeScale = 0.3f;
        animationController.PlayFireAnim();
        audioController.playFireSound();
        yield return new WaitForSeconds(0.20f);
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
        yield break;
    }

    public void PlayGame()
    {
        StartCoroutine(FireAnim());
        
    }

    public void Info()
    {
        SceneManager.LoadScene("Info");
    }

    public void back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Menu"))
        {
            if (Input.GetKeyDown(KeyCode.Escape) && MainMenu.activeInHierarchy)
            {
                QuitGame();
            }

            if (Input.GetKeyDown(KeyCode.Escape) && OptionsMenu.activeInHierarchy)
            {
                MainMenu.SetActive(true);
                OptionsMenu.SetActive(false);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Info"))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
