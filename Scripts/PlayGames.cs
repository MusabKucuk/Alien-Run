using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class PlayGames : MonoBehaviour
{
    string leaderboardID = "CgkIoOXngv8dEAIQAA";
    public static PlayGamesPlatform platform;
    private static bool isTried = false;

    private void Start()
    {
        if (isTried == false)
        {
            isTried = true;
            signInPlayServices();
        }
    }

    private void signInPlayServices()
    {
        if (platform == null)
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            platform = PlayGamesPlatform.Activate();
        }

        Social.Active.localUser.Authenticate(success =>
        {
            if (success)
            {
                Debug.Log("Logged in successfully");
            }
            else
            {
                Debug.Log("Login Failed");
            }
        });

        /* PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) =>
         {
             switch (result)
             {
                 case SignInStatus.Success:
                     Debug.Log("Logged in successfully");
                     break;

                 default:
                     Debug.Log("Login Failed");
                     break;
             }
         });*/
    }

    public void AddScoreToLeaderboard(int playerScore)
    {
        if (Social.Active.localUser.authenticated)
        {
            Social.ReportScore(playerScore, leaderboardID, success => { });
        }
    }

    public void ShowLeaderboard()
    {
        if (Social.Active.localUser.authenticated)
        {
            platform.ShowLeaderboardUI();
        }
        else
        {
            signInPlayServices();
        }
    }
}
