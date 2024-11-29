using UnityEngine;

public class ObstacleReturner : MonoBehaviour
{
    [SerializeField] private ObstaclePool obstaclePool; // ������ �� ��� ��������
    [SerializeField] private Transform player;         // ������ �� ������
    [SerializeField] private float returnDistance = 20f; // ��������� ��� �������� ��������

    private void Update()
    {
        // ���� ������ ������� ������ �� �������, ���������� ��� � ���
        if (transform.position.z < player.position.z - returnDistance)
        {
            obstaclePool.ReturnObstacle(gameObject);
        }
    }
}
