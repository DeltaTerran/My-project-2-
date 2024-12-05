using UnityEngine;



public class ObstacleFactory : IObstacleFactory
{
    private GameObject _bigObstaclePrefab;
    private GameObject _defaultObstaclePrefab;

    public ObstacleFactory(GameObject bigObstacle, GameObject defaultObsticle)
    {
        _bigObstaclePrefab = bigObstacle;
        _defaultObstaclePrefab = defaultObsticle;
    }
    public void CreateObstacles(Vector3 basePosition)
    {
        Object.Instantiate(_bigObstaclePrefab, basePosition + new Vector3(1, 0, 0), Quaternion.identity);
        Object.Instantiate(_bigObstaclePrefab, basePosition, Quaternion.identity);
        Object.Instantiate(_defaultObstaclePrefab, basePosition + new Vector3(-1, 0, 0), Quaternion.identity);
    }
}
