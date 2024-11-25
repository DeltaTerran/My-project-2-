using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI, _inGameUI;
    [SerializeField] private TMP_Text _gameT, _pauseT;
    private bool _isPaused;

    public static float VertVel = 0;
    public static float HorizVel = 0;
    //public static int CoinTotal = 0;
    public static float Score = 0;
    public float waittoload = 0;

    public static float ZVelAdj = 1;

    public static string LvlCompStatus = "";
    public int RandNum;

    void Start()
    {
        Pause();

    }

    // Update is called once per frame
    void Update()
    {
        Score += Time.deltaTime*4;
        _gameT.text = $"Score: {Convert.ToInt32(Score)}";
        if (_isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Unpause();
            }
        }
        
        
        if (LvlCompStatus == "Fail")
        {
            waittoload += Time.deltaTime;
        }
        if (waittoload > 2)
        {
            SceneManager.LoadScene("Outro");
        }
    }
    public static void ResetGMValues()
    {
        VertVel = 0;
        HorizVel = 0;
        //CoinTotal = 0;
        Score = 0;
        ZVelAdj = 0;
        LvlCompStatus = "";
    }
    void Pause()
    {
        Time.timeScale = 0;
        _isPaused = true;
        if (_isPaused)
        {
            _pauseT.text = _gameT.text;
            _pauseUI.SetActive(true);
            _inGameUI.SetActive(false);
            
        }
    }
    void Unpause()
    {
        _isPaused = false;
        Time.timeScale = 1;
        if (!_isPaused)
        {
            _pauseUI.SetActive(false);
            _inGameUI.SetActive(true);
        }
    }

    #region Buttons
    public void PauseButton()
    {
        Pause();
        
    }
    public void QuitButton()
    {

    }
    #endregion
}
