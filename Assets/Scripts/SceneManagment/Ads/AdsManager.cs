using System;
using System.Collections;
using GoogleMobileAds.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour
{
    private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
    public RewardedInterstitialAd RewardedInterstitialAd;
    public static AdsManager Instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        
       
       
    }
    private void Start()
    {
        MobileAds.Initialize(initStatus =>
        {
            Debug.Log("AdMob SDK ���������������");
        });
        LoadInterstitialAd();
    }
    
    public void LoadInterstitialAd()
    {
        if (RewardedInterstitialAd != null)
        {
            RewardedInterstitialAd.Destroy();
            RewardedInterstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");
        var adRequest = new AdRequest();
        RewardedInterstitialAd.Load(_adUnitId, adRequest, (RewardedInterstitialAd ad, LoadAdError error) =>
        {
            // if error is not null, the load request failed.
            if (error != null || ad == null)
            {

                Debug.LogError("interstitial ad failed to load an ad with error : " + error);

                return;
            }

            Debug.Log("Interstitial ad loaded with response : "
                      + ad.GetResponseInfo());

            RewardedInterstitialAd = ad;
            RegisterEventHandlers(RewardedInterstitialAd);
        });
    }
    
    public void ShowInterstitialAd()
    {
        if (RewardedInterstitialAd != null && RewardedInterstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            RewardedInterstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
        //LoadInterstitialAd();
    }
    void ClosesInterstitialAd()
    {
        if (RewardedInterstitialAd != null)
        {
            RewardedInterstitialAd.Destroy();
            RewardedInterstitialAd = null;
        }
        else
        {
            Debug.Log("������ �� ���������� ��� ��� ��� ������.");
        }
    }


    private void RegisterEventHandlers(InterstitialAd interstitialAd)
    {
        // Raised when the ad is estimated to have earned money.
        interstitialAd.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        interstitialAd.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        interstitialAd.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        interstitialAd.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
            if (!SceneManager.GetActiveScene().isLoaded)
            {
                Debug.LogError("Scene is not fully loaded. Delaying RebornTM.");
                return;
            }
            ClosesInterstitialAd();
            
            //GameObject outroMenu = GameObject.Find("OutroMenu");
            //if (outroMenu == null)
            //{
            //    Debug.LogError("OutroMenu object not found.");
            //    return;
            //}
            //StartCoroutine(RespawnAfterDelay());
            //IEnumerator RespawnAfterDelay()
            //{
            //    yield return new WaitForSeconds(0.5f); // ���� ����� Unity ������������ ��������
            //    outroMenu.GetComponent<RestartLvl>().RebornTM();
            //}
            
            //outroMenu.GetComponent<RestartLvl>().RebornTM();
            //LoadInterstitialAd();
            //RebornTM();

        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }


}
