using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Links
    public GameObject GameManager;
    [SerializeField] private GM _gM;
    [SerializeField] GameObject _player;
    public Transform Player_Transform;
    //[SerializeField] Rigidbody _playerRigidbody;
    //[SerializeField] CapsuleCollider _playerCollider;
    [SerializeField]Rigidbody _playerRigidbody;
    [SerializeField]CapsuleCollider _playerCollider;
    [SerializeField]private PlayerStateMachine _stateMachine;
    #endregion
    //[SerializeField]
    //private TMP_Text _gScore, _oScore;

    #region Windows System
    //public KeyCode KeyL;
    //public KeyCode KeyR;
    //public KeyCode KeyUp;
    //public KeyCode KeyDown;
    #endregion
    #region Phone System
    //private Vector2 _startTouchPosition;
    //private Vector2 _currentTouchPosition;
    //private bool stopTouch = false;
    //private float swipeRange = 50;
    private string _controlLocked = "n";
    #endregion

    #region Animator
    private Animator _animator;
    //public static bool CanPlayAnimation = true;
    //private bool isJumping = false;
    //private bool isRolling = false;
    #endregion



    #region Configuration
    //private float _laneDistance = 2.5f;
    //private float _laneSwitchSpeed = 10f;
    private int _laneNum = 0;
    //private float _startYPos = 0.46f;
    public static float Speed = 4;
    public static float Timer = 0f;
    public static float DelayAmount = 1;
    public static float MaxSpeed = 10;
    public static Vector3 _deathPos;
    private float _laneWidth = 1f;
    public static bool _isDead = false;
    //public float HorizVel = 0;
    #endregion
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_playerCollider = _player.GetComponent<CapsuleCollider>();
        //_playerRigidbody = _player.GetComponent<Rigidbody>();
        //_gM = GameManager.GetComponent<GM>();
        _animator = GetComponentInChildren<Animator>();
        _stateMachine.ChangeState(new RunningState(_player, _animator, _playerCollider, _stateMachine));

        SwipeDetector.OnSwipe += HandleSwipe;

    }
    private void OnDestroy()
    {
        SwipeDetector.OnSwipe -= HandleSwipe;
    }

    // Update is called once per frame

    void Update()
    {
        AccelerateSpeed();
        _playerRigidbody.linearVelocity = new Vector3(GM.HorizVel, GM.VertVel, Speed);

        Vector3 targetPosition = new Vector3(_laneNum * _laneWidth, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);

        //stateMachine.Update();
        _stateMachine.Update();
        #region Mobile System
        
        //SwipeCheck();
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
   
    private bool IsInAnimationState(string stateName)
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
    private void SetCollider(float height, Vector3 center)
    {
        _playerCollider.height = height;
        _playerCollider.center = center;
    }
    #region old systems
    //void SwipeCheck()
    //if (Input.touchCount > 0)
    //{
    //    Touch touch = Input.GetTouch(0);
    //    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    //    touchPosition.z = 0f;
    //}
    //{
    //    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
    //    {
    //        _startTouchPosition = Input.GetTouch(0).position;
    //        stopTouch = false;
    //    }
    //    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !stopTouch)
    //    {
    //        _currentTouchPosition = Input.GetTouch(0).position;
    //        Vector2 swipeDelta = _currentTouchPosition - _startTouchPosition;
    //        if (swipeDelta.magnitude > swipeRange)
    //        {
    //            stopTouch = true;

    //            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
    //            {
    //                if (swipeDelta.x > 0 )
    //                {
    //                    if (_controlLocked == "n" && _laneNum < 1)
    //                    {
    //                        _laneNum++;
    //                        MoveRight();
    //                    }
    //                }
    //                else
    //                {
    //                    if (_controlLocked == "n" && _laneNum > -1)
    //                    {
    //                        _laneNum--;
    //                        MoveLeft();
    //                    }

    //                }
    //            }
    //            else
    //            if (swipeDelta.y > 0)
    //            {

    //                //if (CanPlayAnimation)
    //                //{
    //                stateMachine.ChangeState(new JumpingState(_player, _animator, _playerCollider));
    //                //    CanPlayAnimation = false;
    //                //    //MoveUP();
    //                //}

    //            }
    //            //else
    //            //{
    //            //    _animator.SetTrigger("SlideTr");
    //            //    MoveDown();

    //            //}
    //            if(swipeDelta.y < 0)
    //            {

    //                //if (CanPlayAnimation)
    //                //{
    //                stateMachine.ChangeState(new SlidingState(_player, _animator, _playerCollider));
    //                    //CanPlayAnimation = false;
    //                //    //MoveDown();
    //                //}

    //            }
    //        }
    //    }
    //}

    //private IEnumerator ResetSlideFlag()
    //{
    //    yield return new WaitForSeconds(animationDurationSlide); // ”кажите длительность вашей анимации
    //    canPlayAnimation = true;
    //}



    //private void MoveUP()
    //{
    //    //GM.VertVel = 6;
    //    //Player.GetComponent<CapsuleCollider>().height = 1;
    //    if (isJumping) return;
    //    isJumping = true;
    //    SetCollider(2, new Vector3(0, 1, 0));
    //    StartCoroutine(stopJump());
    //}
    // private void MoveDown()
    //{
    //    if (isRolling) return;
    //    isRolling = true;
    //    SetCollider(1, new Vector3(0, 0.5f, 0));
    //    _playerCollider.center = new Vector3(0, 0.5f, 0);

    //    StartCoroutine(StopRoll());
    //}
    //IEnumerator stopJump()
    //{

    //    yield return new WaitForSeconds(jumpDuration);
    //    //Player.GetComponent<CapsuleCollider>().height = 2;
    //    _playerCollider.center = new Vector3(0, 1, 0);
    //    //isJumping = true;
    //    //while (Player.transform.position.y != StartYPos && GM.VertVel != -2) 
    //    //{
    //    //    GM.VertVel = -2;
    //    //}
    //    //GM.VertVel = -6;
    //    //yield return new WaitForSeconds(.5f);
    //    //GM.VertVel = 0;
    //    // Player.position = new Vector3(Player.position.x, _startYPos, Player.position.z);
    //}


    //IEnumerator StopRoll()
    //{
    //    yield return new WaitForSeconds(rollDuration);
    //    //ColliderSliding.SetActive(false);
    //    //ColliderStanding.SetActive(true);

    //    //Player.position = new Vector3(Player.position.x, _startYPos, Player.position.z);
    //    ////Player.localScale = new Vector3(1,1,1);
    //    _playerCollider.height = 2;
    //    _playerCollider.center = new Vector3(0, 1, 0);
    //    //isRolling = false;
    //}

    //Old Sistem
    //if (other.gameObject.name == "PowerUp(Clone)")
    //{
    //    Destroy(other.gameObject);
    //}
    #endregion
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
        transform.position = new Vector3(_laneNum, Player_Transform.position.y, Player_Transform.position.z);
    }
    
    public IEnumerator IFrames()
    {
        _playerCollider.enabled = false;
        yield return new WaitForSeconds(.9f);
        _playerCollider.enabled = true;
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
                _stateMachine.ChangeState(new RunningState(_player,_animator,_playerCollider, _stateMachine));
                _animator.ResetTrigger("JumpTr");
                _animator.ResetTrigger("SlideTr");
                _animator.ResetTrigger("JumpSlideTr");
                //Instantiate(boomObj, _deathPos, boomObj.rotation);
                _gM.LvlCompStatus = "Fail";
                _gM.IsDead = true;
            }


        }

    }


    public static void ResetMVValues()
    {
        Speed = 4;
        Timer = 0f;
        DelayAmount = 1;


    }

    private void HandleSwipe(SwipeDetector.PlayerSwipeDetector direction)
    {
        switch (direction)
        {
            case SwipeDetector.PlayerSwipeDetector.Up:
                _stateMachine.ChangeState(new JumpingState(_player, _animator, _playerCollider, _stateMachine));
                break;
                case SwipeDetector.PlayerSwipeDetector.Down:
                _stateMachine.ChangeState(new SlidingState(_player, _animator, _playerCollider, _stateMachine)); 
                break;
                case SwipeDetector.PlayerSwipeDetector.Left:
                if (_controlLocked == "n" && _laneNum > -1)
                {
                    _laneNum--;
                    MoveLeft();
                }
                break;
            case SwipeDetector.PlayerSwipeDetector.Right:
                if (_controlLocked == "n" && _laneNum < 1)
                {
                    _laneNum++;
                    MoveRight();
                }
                break;
        }
    }

}
