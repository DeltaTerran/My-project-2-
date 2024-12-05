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
        _factories = new Dictionary<int, IObstacleFactory>
        {
            { 0, new BigObstacleFactory(obsticleObj_Big, obsticleObj) },
            { 1, new UpperObstacleFactory(obsticleObj, obsticleObj_Upper) },
            { 2, new MixedObstacleFactory(obsticleObj, obsticleObj_Big) },
            { 3, new UpperObstacleFactory(obsticleObj, obsticleObj_Upper) },
            { 4, new MixedObstacleFactory(obsticleObj, obsticleObj_Big) },
            { 5, new DoubleUpperObstacleFactory(obsticleObj, obsticleObj_Upper) },
            { 6, new MixedObstacleFactory(obsticleObj, obsticleObj_Big) },
            { 7, new BigObstacleFactory(obsticleObj_Big, obsticleObj) },
            { 8, new UpperObstacleFactory(obsticleObj, obsticleObj_Upper) },
            { 9, new BigObstacleFactory(obsticleObj_Big, obsticleObj) },
            { 10, new UpperObstacleFactory(obsticleObj, obsticleObj_Upper) },
            { 11, new BigObstacleFactory(obsticleObj_Big, obsticleObj) },
        };

        // ¬ыбор случайной фабрики и генераци€ преп€тствий
        int randomIndex = Random.Range(0, _factories.Count);
        if (_factories.TryGetValue(randomIndex, out var factory))
        {
            factory.CreateObstacles(transform.position);
        }
    }
}
