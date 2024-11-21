using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveorb : MonoBehaviour
{
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
    private float _maxSpeed = 12;

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
            //Debug.Log(Player.GetComponent<CapsuleCollider>().height);
            Player.GetComponent<CapsuleCollider>().height = 1;
            Player.GetComponent<CapsuleCollider>().center = Vector3.zero;
            Player.position = new Vector3(Player.position.x, _startYPos, Player.position.z);
            //Debug.Log(Player.GetComponent<CapsuleCollider>().height);
            //Player.localScale = new Vector3(1, 0.25f, 1);
            //Player.position = new Vector3(Player.position.x, 0.65f, Player.position.z);

            StartCoroutine(StopRoll());
        }
    }

    private void AccelerateSpeed()
    {
        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            if (Speed < _maxSpeed)
            {
                Speed += 0.25f;
            }

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Lethal")
        {
            Destroy(gameObject);
            GM.ZVelAdj = 0;
            Instantiate(boomObj, transform.position, boomObj.rotation);
            GM.LvlCompStatus = "Fail";
        }
        //if (other.gameObject.name == "PowerUp(Clone)")
        //{
        //    Destroy(other.gameObject);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "rampbottomtrig")
        //{
        //    GM.VertVel = 1.5f;
        //}
        //if (other.gameObject.name == "ramptoptrig")
        //{
        //    GM.VertVel = 0;
        //}
        if (other.gameObject.name == "exit")
        {
            GM.LvlCompStatus = "Sucess";
            SceneManager.LoadScene("LevelComp");
        }
        //if (other.gameObject.name == "coin(Clone)")
        //{
        //    Destroy(other.gameObject);
        //    GM.CoinTotal += 1;
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
        //Player.position = new Vector3(Player.position.x, _startYPos, Player.position.z);
        ////Player.localScale = new Vector3(1,1,1);
        Player.GetComponent<CapsuleCollider>().height = 2;
        Player.GetComponent<CapsuleCollider>().center = new Vector3(0,1,0);
        _controlLocked = "n";
    }
    public static void ResetMVValues()
    {
        Speed = 4;
        Timer = 0f;
        DelayAmount = 1;
    }
}
