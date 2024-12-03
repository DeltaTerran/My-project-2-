using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class ObstaclePool_Spawner : MonoBehaviour
{


    [SerializeField] private ObstaclePool obstaclePool; // Ссылка на пул объектов
    [SerializeField] private Transform player;         // Ссылка на игрока
    [SerializeField] private float spawnDistance = 50f; // Дистанция до спавна объектов
    [SerializeField] private float spawnInterval = 10f; // Интервал между препятствиями

    private float nextSpawnZ = 0f; // Координата Z для следующего объекта

    private void Update()
    {
        if (player.position.z + spawnDistance > nextSpawnZ)
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = obstaclePool.GetObstacle();

        // Устанавливаем позицию объекта
        Vector3 spawnPosition = new Vector3(
            Random.Range(-2, 3), // Случайная позиция по X (например, три дорожки)
            0,
            nextSpawnZ
        );

        obstacle.transform.position = spawnPosition;

        // Обновляем позицию следующего спавна
        nextSpawnZ += spawnInterval;
    }
}
