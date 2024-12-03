using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;
using Unity.VisualScripting;
using Unity.Cinemachine;

public class RestartLvl : MonoBehaviour
{
    [SerializeField] GameObject _player;
    private InterstitialAd _interstitialAd;
    [SerializeField] GameObject _camera;
    [SerializeField] GameObject _gameManager;
    [SerializeField] GameObject _outroUI;

    GM _gM;
    //private const string _interstitialId = "ca-app-pub-1266056041937204/7234272623";
    private const string _adUnitId = "ca-app-pub-1266056041937204/7234272623";
    void Start()
    {
        _gM = _gameManager.GetComponent<GM>();
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

            RebornTM();

        };
        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
        };
    }

    private void RebornTM()
    {
        Debug.Log(123);

        _gM.IsDead = false;
        _gM.AddedtoLB = false;
        _gM.LvlCompStatus = "";
        //Debug.Log(GM.LvlCompStatus);
        _gM.Waittoload = 0;

        //_gM.ResetGMValues();
        //moveorb.ResetMVValues();
        _outroUI.SetActive(false);
        Debug.Log(567);
        GameObject _playerprefab = Instantiate(_player, moveorb._deathPos, _player.transform.rotation);
        _camera.GetComponent<CinemachineCamera>().Target.TrackingTarget = _playerprefab.transform;
        _playerprefab.GetComponent<moveorb>().GameManager = GameObject.Find("GM");
        
        _gM.Unpause();
    }
    #region Buttons
    public void RestartLevel()
    {
        moveorb.ResetMVValues();
        _gM.ResetGMValues();
        BlockSpawner.ResetBSValues();
        SceneManager.LoadScene("Game");
    }
    public void Reborn()
    {
        ShowInterstitialAd();
    }
    #endregion
}
