using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;

public class RestartLvl : MonoBehaviour
{
    private InterstitialAd _interstitialAd;
    //private const string _interstitialId = "ca-app-pub-1266056041937204/7234272623";
    private const string _adUnitId = "ca-app-pub-1266056041937204/7234272623";
    void Start()
    {
        MobileAds.Initialize(initStatus =>{});
        LoadInterstitialAd();
        RegisterEventHandlers(_interstitialAd);

    }
    

    //void RequestInterstitial()
    //{
    //    string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // Тестовый ID
    //    var adRequest = new AdRequest();
    //    InterstitialAd.Load(adUnitId, adRequest,
    //        (InterstitialAd ad, LoadAdError error) =>
    //        {
    //            if (error != null || ad == null)
    //            {
    //                Debug.LogError("Не удалось загрузить межстраничную рекламу: " + error);
    //                return;
    //            }

    //            Debug.Log("Межстраничная реклама загружена.");
    //            _interstitialAd = ad;

    //            // Подписка на события
    //        });
    //}
    //void ShowAd()
    //{

    //    if (interstitial.IsLoaded())
    //    {
    //        interstitial.Show();
    //    }
    //}
    void ClosesInterstitialAd()
    {
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }
        else
        {
            Debug.Log("Баннер не существует или уже был закрыт.");
        }
    }
    public void LoadInterstitialAd()
    {
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");
        var adRequest = new AdRequest();
        InterstitialAd.Load(_adUnitId, adRequest, (InterstitialAd ad, LoadAdError error) =>
          {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
              {

                  Debug.LogError("interstitial ad failed to load an ad with error : " + error);

                  return;
              }

              Debug.Log("Interstitial ad loaded with response : "
                        + ad.GetResponseInfo());

              _interstitialAd = ad;
          });
    }
    public void ShowInterstitialAd()
    {
        if(_interstitialAd != null && _interstitialAd.CanShowAd())
    {
            Debug.Log("Showing interstitial ad.");
            _interstitialAd.Show();
        }
    else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }


    public void RestartLevel()
    {
        moveorb.ResetMVValues();
        GM.ResetGMValues();
        BlockSpawner.ResetBSValues();
        SceneManager.LoadScene("Game");
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
            ClosesInterstitialAd();
            
        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }
    #region Buttons
    public void QuitButton()
    {
        Application.Quit();
    }

    public void Reborn()
    {
        ShowInterstitialAd();
    }
    #endregion
}
