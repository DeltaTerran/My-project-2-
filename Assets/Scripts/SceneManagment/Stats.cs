using TMPro;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "StatsTxt")
        {
            GetComponent<TextMeshPro>().text = GM.LvlCompStatus;
        }
        //if (gameObject.name == "CoinsTxt")
        //{
        //    GetComponent<TextMeshPro>().text = "Coins : " + GM.CoinTotal;
        //}
        if (gameObject.name == "TimeTxt")
        {
            GetComponent<TextMeshPro>().text = "Time : " + GM.Score;
        }
        
    }
}
