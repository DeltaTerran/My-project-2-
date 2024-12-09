using UnityEngine;

public class DestroyerCollider : MonoBehaviour
{
    private bool _isMaxed = false;
    private Rigidbody _destroyer_rigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _destroyer_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isMaxed && PlayerController.Speed == PlayerController.MaxSpeed)
        {
            _isMaxed = true;
        }
        _destroyer_rigidbody.linearVelocity = new Vector3(GM.HorizVel, GM.VertVel, PlayerController.Speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
