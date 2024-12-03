using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab; // Префаб препятствия
    [SerializeField] private int poolSize = 10;         // Размер пула
    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        // Инициализация пула
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obstacle = Instantiate(obstaclePrefab);
            obstacle.SetActive(false);
            pool.Enqueue(obstacle);
        }
    }

    public GameObject GetObstacle()
    {
        if (pool.Count > 0)
        {
            GameObject obstacle = pool.Dequeue();
            obstacle.SetActive(true);
            return obstacle;
        }
        else
        {
            // Создаем дополнительные объекты, если пул пуст
            GameObject obstacle = Instantiate(obstaclePrefab);
            return obstacle;
        }
    }

    public void ReturnObstacle(GameObject obstacle)
    {
        obstacle.SetActive(false);
        pool.Enqueue(obstacle);
    }
}
