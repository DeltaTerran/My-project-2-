using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public Transform Block;
    private static int _platformPos =4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(transform.parent.gameObject);
        _platformPos += 64;
        Instantiate(Block, new Vector3(0,0,_platformPos),Block.rotation);
    }
    public static void ResetBSValues()
    {
        _platformPos = 4;
    }
}
