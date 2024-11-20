using UnityEngine;

public class movecam : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().linearVelocity = new Vector3(0, GM.VertVel, 4*GM.ZVelAdj);
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, GM.VertVel * GM.ZVelAdj, moveorb.Speed * GM.ZVelAdj);
    }
}
