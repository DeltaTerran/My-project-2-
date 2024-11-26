using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using TMPro;

public class RestartLvl : MonoBehaviour
{
    [SerializeField]
    private InterstitialAd _interAd;
    private const string _interstitialId = "ca-app-pub-1266056041937204~6113929937";
    void Start()
    {
        
    }
    void RequestInterstitial()
    {
        _interAd = new InterstitialAd(_interstitialId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        _interAd.LoadAd(adRequest);
    }
    public void ShowAd()
    {
        _interAd.Show();
    }
    public void QuitButton() 
    {
        Application.Quit(); 
    }

    public void Reborn()
    {

    }
    public void RestartLevel()
    {
        moveorb.ResetMVValues();
        GM.ResetGMValues();
        BlockSpawner.ResetBSValues();
        SceneManager.LoadScene("Game");
    }
}
