using System;
using Firebase.Auth;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI, _inGameUI;
    [SerializeField] private TMP_Text _gameT, _pauseT;
    private bool _isPaused;
    private FirebaseAuth auth;

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
        //Код для определения нажата кнопка или нет
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
        //if (_isPaused)
        //{
        //    if (Input.GetKeyDown(KeyCode.Mouse0))
        //    {
        //        Unpause();
        //    }
        //}


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
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag != "Button")
        {
            Unpause();
        }
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
        Application.Quit();
    }
    public void SignOutButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        if (auth != null)
        {
            auth.SignOut();
            Debug.Log("Пользователь вышел из аккаунта.");

        }
        else
        {
            Debug.LogWarning("FirebaseAuth не инициализирован.");
        }
    }
    #endregion
}
