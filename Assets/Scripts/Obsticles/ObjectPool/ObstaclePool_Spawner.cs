using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

public class ObstaclePool_Spawner : MonoBehaviour
{


    [SerializeField] private ObstaclePool obstaclePool; // ������ �� ��� ��������
    [SerializeField] private Transform player;         // ������ �� ������
    [SerializeField] private float spawnDistance = 50f; // ��������� �� ������ ��������
    [SerializeField] private float spawnInterval = 10f; // �������� ����� �������������

    private float nextSpawnZ = 0f; // ���������� Z ��� ���������� �������

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

        // ������������� ������� �������
        Vector3 spawnPosition = new Vector3(
            Random.Range(-2, 3), // ��������� ������� �� X (��������, ��� �������)
            0,
            nextSpawnZ
        );

        obstacle.transform.position = spawnPosition;

        // ��������� ������� ���������� ������
        nextSpawnZ += spawnInterval;
    }
}
