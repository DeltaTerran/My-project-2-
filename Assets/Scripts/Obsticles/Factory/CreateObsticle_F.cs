using System.Collections.Generic;
using UnityEngine;

public class CreateObsticle_F : MonoBehaviour
{
    public GameObject obsticleObj_Big;
    public GameObject obsticleObj_Upper;
    public GameObject obsticleObj;
    private Dictionary<int, IObstacleFactory> _factories;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
