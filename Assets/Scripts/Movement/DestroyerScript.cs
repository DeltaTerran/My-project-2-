using UnityEngine;

public class DeleteCollider : MonoBehaviour
{
    private float _dSpeed = 5;
    private bool _isMaxed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isMaxed && moveorb.Speed == moveorb.MaxSpeed)
        {
            _dSpeed = moveorb.MaxSpeed;
            _isMaxed = true;
        }
        GetComponent<Rigidbody>().linearVelocity = new Vector3(GM.HorizVel, GM.VertVel, moveorb.Speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
