using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class MonetizationBehavior : MonoBehaviour, IUnityAdsListener
{
    private string googlePlay_ID = "3569583";
    private string appleApp_ID = "null";
    public bool testMode = true;
    public bool isTargetGooglePlay;

    private string intersticialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";

    private int adsInterval;


    void Start()
    {
        testMode = true;
        isTargetGooglePlay = true;
        adsInterval = PlayerPrefs.GetInt("Ads");

        Advertisement.AddListener(this);
        InitializeAdvertisement();
    }

    public void InitializeAdvertisement()
    {
        if (isTargetGooglePlay)
        {
            Advertisement.Initialize(googlePlay_ID, testMode);
        }
        else
        {
            Advertisement.Initialize(appleApp_ID, testMode);
        }

    }



    public void DisplayInterstitialAD(bool win)
    {
        if (Advertisement.IsReady(intersticialAd) && adsInterval >= 4)
        {
            Advertisement.Show(intersticialAd);
            adsInterval = 0;
        }
        else
        {
            if (win)
            {
                adsInterval += 2;
            }
            else
            {
                adsInterval += 1;
            }

        }
        PlayerPrefs.SetInt("Ads", adsInterval);
    }

    public void DisplayRewardedAD()
    {
        if (Advertisement.IsReady(rewardedVideoAd))
        {
            Advertisement.Show(rewardedVideoAd);
        }
    }


    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                if(placementId == rewardedVideoAd)
                {
                    Debug.Log("A reward video has seen !");

                }
                if(placementId == intersticialAd) 
                { 
                    Debug.Log("Finished Interstitial"); 
                }
                break;
        }
    }
}
