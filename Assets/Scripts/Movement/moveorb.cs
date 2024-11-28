using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

public class moveorb : MonoBehaviour
{

    //[SerializeField]
    //private TMP_Text _gScore, _oScore;
    public KeyCode MoveL;
    public KeyCode MoveR;
    public KeyCode MoveUp;
    public KeyCode MoveDown;
    

    private int LaneNum = 2;
    //public float HorizVel = 0;
    private string _controlLocked = "n";
    private float _startYPos = 0.46f;
    public static float Speed=4;
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
        // mover.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        AccelerateSpeed();
        //Debug.Log(name);
        GetComponent<Rigidbody>().linearVelocity = new Vector3(GM.HorizVel, GM.VertVel, Speed);
        //Debug.Log(Speed);

        if (Input.GetKeyDown(MoveL) && LaneNum > 1 && _controlLocked == "n")
        {
            // Wait for seconds - .5f
            //GM.HorizVel = -2;
            // Wait for seconds - .25f


            GM.HorizVel = -4;
            StartCoroutine(stopSlide());
            LaneNum -= 1;
            _controlLocked = "y";
        }
        if (Input.GetKeyDown(MoveR) && LaneNum < 3 && _controlLocked == "n")
        {


            // Wait for seconds - .5f
            //GM.HorizVel = 2;
            // Wait for seconds - .25f


            GM.HorizVel = 4;
            StartCoroutine(stopSlide());
            LaneNum += 1;
            _controlLocked = "y";
        }
        if (Input.GetKeyDown(MoveUp) && _controlLocked == "n")
        {
            GM.VertVel = 6;
            StartCoroutine(stopJump());
            _controlLocked = "y";
        }
        if (Input.GetKeyDown(MoveDown) && _controlLocked == "n")
        {
            Player.GetComponent<CapsuleCollider>().height = 1;
            Player.GetComponent<CapsuleCollider>().center = new Vector3(0,0.5f, 0);
            Debug.Log(Player.GetComponent<CapsuleCollider>().height);

            
            StartCoroutine(StopRoll());
        }
    }

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
            _deathPos = new Vector3(transform.position.x, transform.position.y+0.1f, transform.position.z);
            Instantiate(boomObj, _deathPos, boomObj.rotation);
            GM.LvlCompStatus = "Fail";

        }

        //Old Sistem
        //if (other.gameObject.name == "PowerUp(Clone)")
        //{
        //    Destroy(other.gameObject);
        //}
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
    IEnumerator StopRoll ()
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
    public static void ResetMVValues()
    {
        Speed = 4;
        Timer = 0f;
        DelayAmount = 1;
    }
}
