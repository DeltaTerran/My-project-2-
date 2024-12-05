using System.Collections;
using UnityEngine;

public class moveorb : MonoBehaviour
{

    //[SerializeField]
    //private TMP_Text _gScore, _oScore;
    [SerializeField] Rigidbody player_rigidbody;
    [SerializeField] CapsuleCollider player_collider;
    #region Windows System
    //public KeyCode KeyL;
    //public KeyCode KeyR;
    //public KeyCode KeyUp;
    //public KeyCode KeyDown;
    #endregion
    private Vector2 _startTouchPosition;
    private Vector2 _currentTouchPosition;
    private bool stopTouch = false;
    private float swipeRange = 50;
    private Animator _animator;



    private int _laneNum = 0;
    //private float _laneDistance = 2.5f;
    //private float _laneSwitchSpeed = 10f;
    
    private string _controlLocked = "n";
    //private float _startYPos = 0.46f;
    public static float Speed = 4;
    public static float Timer = 0f;
    public static float DelayAmount = 1;
    public static float MaxSpeed = 10;
    public static Vector3 _deathPos;
    private float _laneWidth = 1f;
    //private bool _isDead = false;
    //public float HorizVel = 0;

    public GameObject GameManager;
    private GM _gM;
    //public Transform boomObj;
    public Transform Player;

    //Rigidbody mover;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gM = GameManager.GetComponent<GM>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    
    void Update()
    {
        AccelerateSpeed();
        player_rigidbody.linearVelocity = new Vector3(GM.HorizVel, GM.VertVel, Speed);

        Vector3 targetPosition = new Vector3(_laneNum * _laneWidth, transform.position.y, transform.position.z); // 2.5f Ч ширина полосы
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f); // 10f Ч скорость смены полосы

        #region Mobile System
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        //    touchPosition.z = 0f;
        //}
        SwipeCheck();
        #endregion
        #region Windows System;
        //if (Input.GetKeyDown(KeyL) && LaneNum > 1 && _controlLocked == "n")
        //{
        //    MoveLeft();
        //}
        //if (Input.GetKeyDown(KeyR) && LaneNum < 3 && _controlLocked == "n")
        //{
        //    MoveRight();
        //}
        //if (Input.GetKeyDown(KeyUp) && _controlLocked == "n")
        //{
        //    MoveUP();
        //}
        //if (Input.GetKeyDown(KeyDown) && _controlLocked == "n")
        //{
        //    MoveDown();
        //}
        #endregion

    }
    #region Movement
    void SwipeCheck()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _startTouchPosition = Input.GetTouch(0).position;
            stopTouch = false;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !stopTouch)
        {
            _currentTouchPosition = Input.GetTouch(0).position;
            Vector2 swipeDelta = _currentTouchPosition - _startTouchPosition;
            if (swipeDelta.magnitude > swipeRange)
            {
                stopTouch = true;

                if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    if (swipeDelta.x > 0 )
                    {
                        if (_controlLocked == "n" && _laneNum < 1)
                        {
                            _laneNum++;
                            MoveRight();
                        }
                    }
                    else
                    {
                        if (_controlLocked == "n" && _laneNum > -1)
                        {
                            _laneNum--;
                            MoveLeft();
                        }
                        
                    }
                }
                else
                if (swipeDelta.y > 0)
                {
                        MoveUP();
                        _animator.SetTrigger("JumpTr");                   
                }
                else
                {
                        MoveDown();
                        _animator.SetTrigger("SlideTr");
                }
            }
        }
    }
    private void MoveDown()
    {

        player_collider.height = 1;
        player_collider.center = new Vector3(0, 0.5f, 0);


        StartCoroutine(StopRoll());
    }

    private void MoveUP()
    {
        //GM.VertVel = 6;
        //Player.GetComponent<CapsuleCollider>().height = 1;
        player_collider.center = new Vector3(0, 3.5f, 0);
        StartCoroutine(stopJump());
    }

    private void MoveRight()
    {
        StartCoroutine(stopSlide());
        //_laneNum += 1;
        _controlLocked = "y";
    }

    private void MoveLeft()
    {
        StartCoroutine(stopSlide());
        //_laneNum -= 1;
        _controlLocked = "y";
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.125f);
        GM.HorizVel = 0;
        _controlLocked = "n";
        transform.position = new Vector3(_laneNum, Player.transform.position.y, Player.transform.position.z);
    }
    IEnumerator stopJump()
    {

        yield return new WaitForSeconds(.9f);
        //Player.GetComponent<CapsuleCollider>().height = 2;
        player_collider.center = new Vector3(0, 1, 0);
        //while (Player.transform.position.y != StartYPos && GM.VertVel != -2) 
        //{
        //    GM.VertVel = -2;
        //}
        //GM.VertVel = -6;
        //yield return new WaitForSeconds(.5f);
        //GM.VertVel = 0;
        // Player.position = new Vector3(Player.position.x, _startYPos, Player.position.z);
    }
    IEnumerator StopRoll()
    {
        yield return new WaitForSeconds(.9f);
        //ColliderSliding.SetActive(false);
        //ColliderStanding.SetActive(true);

        //Player.position = new Vector3(Player.position.x, _startYPos, Player.position.z);
        ////Player.localScale = new Vector3(1,1,1);
        player_collider.height = 2;
        player_collider.center = new Vector3(0, 1, 0);
    }
    #endregion
    private void AccelerateSpeed()
    {
        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            if (Speed < MaxSpeed)
            {
                Speed += 0.25f;
            }


        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Lethal")
        {
            if (!_gM.IsDead)
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                GM.ZVelAdj = 0;
                _deathPos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
                //Instantiate(boomObj, _deathPos, boomObj.rotation);
                _gM.LvlCompStatus = "Fail";
                _gM.IsDead = true;
            }


        }

        //Old Sistem
        //if (other.gameObject.name == "PowerUp(Clone)")
        //{
        //    Destroy(other.gameObject);
        //}
    }



    public static void ResetMVValues()
    {
        Speed = 4;
        Timer = 0f;
        DelayAmount = 1;
    }
}
