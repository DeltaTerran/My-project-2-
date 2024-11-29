using System.Collections;
using UnityEngine;

public class moveorb : MonoBehaviour
{

    //[SerializeField]
    //private TMP_Text _gScore, _oScore;
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



    private int LaneNum = 2;
    //public float HorizVel = 0;
    private string _controlLocked = "n";
    private float _startYPos = 0.46f;
    public static float Speed = 4;
    public static float Timer = 0f;
    public static float DelayAmount = 1;
    public static float MaxSpeed = 10;
    public static Vector3 _deathPos;
    //private bool _isDead = false;


    public Transform boomObj;
    public Transform Player;

    //Rigidbody mover;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AccelerateSpeed();
        GetComponent<Rigidbody>().linearVelocity = new Vector3(GM.HorizVel, GM.VertVel, Speed);
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
                    if (swipeDelta.x > 0)
                    {
                        MoveRight();
                    }
                    else
                    {
                        MoveLeft();
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

        Player.GetComponent<CapsuleCollider>().height = 1;
        Player.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.5f, 0);
        Debug.Log(Player.GetComponent<CapsuleCollider>().height);


        StartCoroutine(StopRoll());
    }

    private void MoveUP()
    {
        GM.VertVel = 6;
        StartCoroutine(stopJump());
        _controlLocked = "y";
    }

    private void MoveRight()
    {
        GM.HorizVel = 4;
        StartCoroutine(stopSlide());
        LaneNum += 1;
        _controlLocked = "y";
    }

    private void MoveLeft()
    {
        GM.HorizVel = -4;
        StartCoroutine(stopSlide());
        LaneNum -= 1;
        _controlLocked = "y";
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.25f);
        GM.HorizVel = 0;
        _controlLocked = "n";
    }
    IEnumerator stopJump()
    {

        yield return new WaitForSeconds(.5f);
        //while (Player.transform.position.y != StartYPos && GM.VertVel != -2) 
        //{
        //    GM.VertVel = -2;
        //}
        GM.VertVel = -6;
        yield return new WaitForSeconds(.5f);
        GM.VertVel = 0;
        Player.position = new Vector3(Player.position.x, _startYPos, Player.position.z);
        _controlLocked = "n";
    }
    IEnumerator StopRoll()
    {
        yield return new WaitForSeconds(.9f);
        //ColliderSliding.SetActive(false);
        //ColliderStanding.SetActive(true);

        //Player.position = new Vector3(Player.position.x, _startYPos, Player.position.z);
        ////Player.localScale = new Vector3(1,1,1);
        Player.GetComponent<CapsuleCollider>().height = 2;
        Player.GetComponent<CapsuleCollider>().center = new Vector3(0, 1, 0);
        _controlLocked = "n";
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
            Destroy(other.gameObject);
            Destroy(gameObject);
            GM.ZVelAdj = 0;
            _deathPos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            Instantiate(boomObj, _deathPos, boomObj.rotation);
            GM.LvlCompStatus = "Fail";

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
