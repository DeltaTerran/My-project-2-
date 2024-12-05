using System.Collections.Generic;
using UnityEngine;

public class BetterObsticles : MonoBehaviour
{
    public GameObject obsticleObj_Big;
    public GameObject obsticleObj_Upper;
    public GameObject obsticleObj;

    private List<List<(GameObject prefab, Vector3 offset)>> _obstacleConfigurations;

    void Start()
    {
        // Инициализация конфигураций
        _obstacleConfigurations = new List<List<(GameObject prefab, Vector3 offset)>>
        {
            new List<(GameObject, Vector3)>
            {
                (obsticleObj_Big, new Vector3(1, 0, 0)),
                (obsticleObj_Big, new Vector3(0, 0, 0)),
                (obsticleObj, new Vector3(-1, 0, 0))
            },
            new List<(GameObject, Vector3)>
            {
                (obsticleObj, new Vector3(1, 0, 0)),
                (obsticleObj, new Vector3(0, 0, 0)),
                (obsticleObj_Upper, new Vector3(-1, 2.5f, 0))
            },
            // Добавьте другие конфигурации здесь...
        };

        // Генерация случайной конфигурации
        int randomIndex = Random.Range(0, _obstacleConfigurations.Count);
        SpawnObstacles(randomIndex);
    }
    private void SpawnObstacles(int configurationIndex)
    {
        if (configurationIndex < 0 || configurationIndex >= _obstacleConfigurations.Count) return;

        foreach (var (prefab, offset) in _obstacleConfigurations[configurationIndex])
        {
            Instantiate(prefab, transform.position + offset, prefab.transform.rotation);
        }
    }
}
