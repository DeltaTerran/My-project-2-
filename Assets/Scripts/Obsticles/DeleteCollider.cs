using UnityEngine;

public class DeleteCollider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().linearVelocity = new Vector3(GM.HorizVel, GM.VertVel, moveorb.Speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
