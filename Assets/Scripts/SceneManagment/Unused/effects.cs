using UnityEngine;

public class effects : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "PowerUp(Clone)")
        {
            transform.Rotate(3, 0, 0);
        }
        if (gameObject.name == "coin(Clone)")
        {
            transform.Rotate(0, 0, 3);
        }
        
    }
}
