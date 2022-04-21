using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadMenu : MonoBehaviour
{
    public GameObject avatar1;
    public GameObject avatar2;
    public GameObject avatar3;
    public GameObject avatar4;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI continueText;
    private float highScore;
    private static int adsCounter = 0;
    public int contAd = 0;
    [SerializeField] GameObject deadMenu;
    [SerializeField] GameObject MainMenu;
    public Button[] buttons;

    private Ads ads;
    private PlayGames playGames;

    private void Awake()
    {
        ads = GetComponent<Ads>();
        playGames = GetComponent<PlayGames>();
    }

    public void OpenDeadMenu()
    {

        if (contAd == 1)
            continueText.text = "Game Over";
        else
            continueText.text = "Watch Video\nFor Second Chance";

        if (avatar1.GetComponent<IsDead>().IsCharacterDead && avatar1.activeInHierarchy)
        {
            deadMenu.SetActive(true);
            MainMenu.SetActive(false);
            WriteScore();
            //Time.timeScale = 0f;
        } 
        
        if (avatar2.GetComponent<IsDead>().IsCharacterDead && avatar2.activeInHierarchy)
        {
            deadMenu.SetActive(true);
            MainMenu.SetActive(false);
            WriteScore();
            //Time.timeScale = 0f;
        }

        if (avatar3.GetComponent<IsDead>().IsCharacterDead && avatar3.activeInHierarchy)
        {
            deadMenu.SetActive(true);
            MainMenu.SetActive(false);
            WriteScore();
           //Time.timeScale = 0f;
        }

        if (avatar4.GetComponent<IsDead>().IsCharacterDead && avatar4.activeInHierarchy)
        {
            deadMenu.SetActive(true);
            MainMenu.SetActive(false);
            WriteScore();
            //Time.timeScale = 0f;
        }

        ShowwAd();
    }

    private void ShowwAd()
    {
        if (avatar1.activeInHierarchy)
        {
            if (avatar1.GetComponent<Texts>().score > 1000)
            {
                ads.ShowAD();
                adsCounter = 0;
            } 
            else if(avatar1.GetComponent<Texts>().score > 150)
            {
                adsCounter++;
            }

            if (adsCounter == 3)
            {
                ads.ShowAD();
                adsCounter = 0;
            }
        }

        if (avatar2.activeInHierarchy)
        {
            if (avatar2.GetComponent<Texts>().score > 1000)
            {
                ads.ShowAD();
                adsCounter = 0;
            }
            else if (avatar2.GetComponent<Texts>().score > 150)
            {
                adsCounter++;
            }

            if (adsCounter == 3)
            {
                ads.ShowAD();
                adsCounter = 0;
            }
        }

        if (avatar3.activeInHierarchy)
        {
            if (avatar3.GetComponent<Texts>().score > 1000)
            {
                ads.ShowAD();
                adsCounter = 0;
            }
            else if (avatar3.GetComponent<Texts>().score > 150)
            {
                adsCounter++;
            }

            if (adsCounter == 3)
            {
                ads.ShowAD();
                adsCounter = 0;
            }
        }

        if (avatar4.activeInHierarchy)
        {
            if (avatar4.GetComponent<Texts>().score > 1000)
            {
                ads.ShowAD();
                adsCounter = 0;
            }
            else if (avatar4.GetComponent<Texts>().score > 150)
            {
                adsCounter++;
            }

            if (adsCounter == 3)
            {
                ads.ShowAD();
                adsCounter = 0;
            }
        }
    }

    public void countinuePlay()
    {
        if (contAd == 1)         
            return;

        ads.ShowRewarded();

        if (Application.internetReachability == NetworkReachability.NotReachable)
            continueText.text = "Internet Connection Lost";
        else
            continueText.text = "Loading Video";
    }

    public void playRewarded()
    {
        deadMenu.SetActive(false);
        MainMenu.SetActive(true);

        if (avatar1.activeInHierarchy)
        {
            avatar1.GetComponent<IsDead>().countinuePlay();
        }

        if (avatar2.activeInHierarchy)
        {
            avatar2.GetComponent<IsDead>().countinuePlay();
        }

        if (avatar3.activeInHierarchy)
        {
            avatar3.GetComponent<IsDead>().countinuePlay();
        }

        if (avatar4.activeInHierarchy)
        {
            avatar4.GetComponent<IsDead>().countinuePlay();
        }
    }

    public void WriteScore()
    {
        if (avatar1.activeInHierarchy)
        {
            scoreText.text = "Score: " + avatar1.GetComponent<Texts>().score.ToString("0");

            if (PlayerPrefs.HasKey("High Score"))
            {
                highScore = PlayerPrefs.GetFloat("High Score");
            }

            if (avatar1.GetComponent<Texts>().score > highScore)
            {
                highScore = avatar1.GetComponent<Texts>().score;
                PlayerPrefs.SetFloat("High Score", highScore);
                playGames.AddScoreToLeaderboard(int.Parse(highScore.ToString("0")));
            }

            highScoreText.text = "High Score: " + highScore.ToString("0");
        }
        
        if (avatar2.activeInHierarchy)
        {
            scoreText.text = "Score: " + avatar2.GetComponent<Texts>().score.ToString("0");

            if (PlayerPrefs.HasKey("High Score"))
            {
                highScore = PlayerPrefs.GetFloat("High Score");
            }

            if (avatar2.GetComponent<Texts>().score > highScore)
            {
                highScore = avatar2.GetComponent<Texts>().score;
                PlayerPrefs.SetFloat("High Score", highScore);
                playGames.AddScoreToLeaderboard(int.Parse(highScore.ToString("0")));
            }

            highScoreText.text = "High Score: " + highScore.ToString("0");
        }

        if (avatar3.activeInHierarchy)
        {
            scoreText.text = "Score: " + avatar3.GetComponent<Texts>().score.ToString("0");

            if (PlayerPrefs.HasKey("High Score"))
            {
                highScore = PlayerPrefs.GetFloat("High Score");
            }

            if (avatar3.GetComponent<Texts>().score > highScore)
            {
                highScore = avatar3.GetComponent<Texts>().score;
                PlayerPrefs.SetFloat("High Score", highScore);
                playGames.AddScoreToLeaderboard(int.Parse(highScore.ToString("0")));
            }

            highScoreText.text = "High Score: " + highScore.ToString("0");
        }

        if (avatar4.activeInHierarchy)
        {
            scoreText.text = "Score: " + avatar4.GetComponent<Texts>().score.ToString("0");

            if (PlayerPrefs.HasKey("High Score"))
            {
                highScore = PlayerPrefs.GetFloat("High Score");
            }

            if (avatar4.GetComponent<Texts>().score > highScore)
            {
                highScore = avatar4.GetComponent<Texts>().score;
                PlayerPrefs.SetFloat("High Score", highScore);
                playGames.AddScoreToLeaderboard(int.Parse(highScore.ToString("0")));
            }

            highScoreText.text = "High Score: " + highScore.ToString("0");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
}
