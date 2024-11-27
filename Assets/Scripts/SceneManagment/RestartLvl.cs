using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class RestartLvl : MonoBehaviour
{
    private InterstitialAd _interstitialAd;
    //private const string _interstitialId = "ca-app-pub-1266056041937204/7234272623";
    private const string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
    void Start()
    {
        MobileAds.Initialize(initStatus =>{});
        LoadInterstitialAd();

    }
    //void RequestInterstitial()
    //{
    //    string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // �������� ID
    //    var adRequest = new AdRequest();
    //    InterstitialAd.Load(adUnitId, adRequest,
    //        (InterstitialAd ad, LoadAdError error) =>
    //        {
    //            if (error != null || ad == null)
    //            {
    //                Debug.LogError("�� ������� ��������� ������������� �������: " + error);
    //                return;
    //            }

    //            Debug.Log("������������� ������� ���������.");
    //            _interstitialAd = ad;

    //            // �������� �� �������
    //        });
    //}
    //void ShowAd()
    //{

    //    if (interstitial.IsLoaded())
    //    {
    //        interstitial.Show();
    //    }
    //}
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
