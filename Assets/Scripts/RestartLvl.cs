using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLvl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RestartLevel()
    {
        moveorb.ResetMVValues();
        GM.ResetGMValues();
        BlockSpawner.ResetBSValues();
        SceneManager.LoadScene("lvl1");
    }
}