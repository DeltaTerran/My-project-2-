using System;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GM : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI, _gameUI, _outroUI, _leaderboardUI;
    [SerializeField] private TMP_Text _gameT, _pauseT, _outroT;
    private bool _isPaused;

    public static float VertVel = 0;
    public static float HorizVel = 0;
    //public static int CoinTotal = 0;
    public static float Score = 0;
    public float waittoload = 0;
    bool _addedtoLB = false;
    bool _isDead = false;
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
        
        //Debug.Log(camera.GetComponent<CinemachineCamera>().Target.TrackingTarget);
        Score += Time.deltaTime*4;
        _gameT.text = $"Score: {Convert.ToInt32(Score)}";
        //Код для определения нажата кнопка или нет
        //if (Input.GetMouseButtonDown(0))
        //{
        //    MouseClick();
        //}
        //if (Input.touchCount > 0)
        //{
        //    _touch = Input.GetTouch(0);
        //    touchPosition = _touch.position;
        //}
        //if (_isPaused)
        //{

        //}

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{

        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    //RaycastHit hit;

        //    //if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.CompareTag("Button"))
        //    if (Physics.Raycast(ray, out RaycastHit hit))
        //    {
        //        if (hit.collider.CompareTag("Button"))
        //        {
        //            Debug.Log("Пользователь нажал на кнопку");
        //        }
        //        else
        //        {
        //            Debug.Log("Пользователь He нажал на кнопку");
        //            Unpause();
        //        }

        //    }

        //}
        #region Raycast Check
        if (Input.touchCount > 0) // Если есть касания
        {
            Touch touch = Input.GetTouch(0); // Берем первое касание

            if (touch.phase == TouchPhase.Began) // Начало касания
            {
                // Проверка, попали ли в объект
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("btn")) // Если тег совпадает
                    {
                        return;
                    }
                }

                // Если не по кнопке, запускаем игру
                //Unpause();
            }
        }
        #endregion
        #region UI-Button Check
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId)) // Проверяем касание по UI
        //        {
        //            Debug.Log("Клик по UI-кнопке через Touch!");
        //            return;
        //        }

        //        // Если не по кнопке, запускаем игру
        //        Debug.Log("Клик не по UI-кнопке через Touch!");
        //        Unpause();
        //    }
        //}
        #endregion
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
        if (waittoload > 0.5f)
        {
            
            //SceneManager.LoadScene("Outro");

            if (!_isDead)
            {
                _outroUI.SetActive(true);
                _gameUI.SetActive(false);
                _isDead = true;
                _isPaused = true;
                Time.timeScale = 0;
            }
            
            _outroT.text = _gameT.text;

            if (FirebaseManager.Instance.Auth != null && !_addedtoLB)
            {
                FirebaseManager.Instance.AddPlayerToLeaderboard(FirebaseManager.Instance.Auth.CurrentUser.UserId,
                    FirebaseManager.Instance.Auth.CurrentUser.DisplayName,
                    Convert.ToInt32(Score));
                // FirebaseManager.Instance.AddPlayerToLeaderboard("user123", "TestPlayer", 100);
                _addedtoLB = true;
            }
            else
            {
                _addedtoLB = true;
            }

        }
    }

    //private void MouseClick()
    //{
    //    RaycastHit raycastHit;
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if (Physics.Raycast(ray, out raycastHit, 100f))
    //    {
    //        if (raycastHit.transform != null)
    //        {
    //            //Our custom method. 
    //            CurrentClickedGameObject(raycastHit.transform.gameObject);
    //        }
    //    }
    //}

    public static void ResetGMValues()
    {
        VertVel = 0;
        HorizVel = 0;
        //CoinTotal = 0;
        Score = 0;
        ZVelAdj = 0;
        LvlCompStatus = "";
    }
    //public void CurrentClickedGameObject(GameObject gameObject)
    //{
    //    if (gameObject.CompareTag("Button"))
    //    {
    //        Debug.Log(gameObject.name);
    //    }
    //    else
    //    {
    //        Unpause();
    //    }
    //}
    
   public void Pause()
    {
        Time.timeScale = 0;
        _isPaused = true;
        if (_isPaused)
        {
            _pauseT.text = _gameT.text;
            _pauseUI.SetActive(true);
            _gameUI.SetActive(false);
            
        }
    }
    public void Unpause()
    {
        _isPaused = false;
        Time.timeScale = 1;
        if (!_isPaused)
        {
            _pauseUI.SetActive(false);
            _gameUI.SetActive(true);
            _leaderboardUI.SetActive(false);
        }
    }

    #region Buttons
    public void PauseButton()
    {
        Pause();
        
    }
    public void QuitButton()
    {
        moveorb.ResetMVValues();
        ResetGMValues();
        BlockSpawner.ResetBSValues();
        SceneManager.LoadScene("Game");
    //Application.Quit();
    }
    public void SignOutButton()
    {
        
        if (FirebaseManager.Instance.Auth != null)
        {
            FirebaseManager.Instance.Auth.SignOut();
            Debug.Log("Пользователь вышел из аккаунта.");

        }
        else
        {
            Debug.LogWarning("FirebaseAuth не инициализирован.");
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void LeaderBoardButton()
    {
        _pauseUI.SetActive(false);
        _leaderboardUI.SetActive(true);
    }
    public void BoBackFromLeaderBoardButton()
    {
        _leaderboardUI.SetActive(false);
        _pauseUI.SetActive(true);
    }
    #endregion
    #region Events
    #endregion

}


