using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class Ads : MonoBehaviour
{
    private InterstitialAd interstitial;
    private BannerView bannerView;
    private RewardedAd rewardedAd; 
    string adUnitId = "ca-app-pub-5032464936788022/7207099694";
    string banner = "ca-app-pub-5032464936788022/7601984815";
    string rewarded = "ca-app-pub-5032464936788022/6318561410";
    private DeadMenu deadMenu;

    private void Awake()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
    }

    private void RequestInterstitial()
    {
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }
        this.interstitial = new InterstitialAd(adUnitId);

        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        this.interstitial.OnAdClosed += HandleAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);       
    }

    private void RequestBanner()
    {
        this.bannerView = new BannerView(banner, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }

    private void RequestRewardedAd()
    {
        if (this.rewardedAd != null)
        {
            this.rewardedAd.Destroy();
        }
        this.rewardedAd = new RewardedAd(rewarded);

        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        deadMenu = GetComponent<DeadMenu>();
        deadMenu.continueText.text = "Watch To The End";
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        deadMenu = GetComponent<DeadMenu>();
        deadMenu.playRewarded();
        deadMenu.contAd = 1;
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }       
    }
    public void HandleAdClosed(object sender, EventArgs args)
    {
        deadMenu = GetComponent<DeadMenu>();
        for (int i = 0; i < deadMenu.buttons.Length; i++)
        {
            deadMenu.buttons[i].enabled = !deadMenu.buttons[i].enabled;
        }
        if (deadMenu.contAd == 1)
            deadMenu.continueText.text = "Game Over";
        else
            deadMenu.continueText.text = "Watch Video\nFor Second Chance";
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();          
        }
    }

    public void ShowAD()
    {       
        this.RequestInterstitial();
        deadMenu = GetComponent<DeadMenu>();

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            deadMenu.continueText.text = "Internet Connection Lost";
        }
        else
        {
            deadMenu.continueText.text = "Loading Video";

            for (int i = 0; i < deadMenu.buttons.Length; i++)
            {
                deadMenu.buttons[i].enabled = !deadMenu.buttons[i].enabled;
            }           
        }
    }

    public void ShowRewarded()
    {
        this.RequestRewardedAd();
    }

}
