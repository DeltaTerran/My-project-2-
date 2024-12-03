using UnityEngine;

public class ObstacleReturner : MonoBehaviour
{
    [SerializeField] private ObstaclePool obstaclePool; // Ссылка на пул объектов
    [SerializeField] private Transform player;         // Ссылка на игрока
    [SerializeField] private float returnDistance = 20f; // Дистанция для возврата объектов

    private void Update()
    {
        // Если объект слишком далеко за игроком, возвращаем его в пул
        if (transform.position.z < player.position.z - returnDistance)
        {
            obstaclePool.ReturnObstacle(gameObject);
        }
    }
}
