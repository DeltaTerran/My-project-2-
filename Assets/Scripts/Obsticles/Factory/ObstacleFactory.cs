using UnityEngine;



public class BigObstacleFactory : IObstacleFactory
{
    private GameObject _bigObstaclePrefab;
    private GameObject _defaultObstaclePrefab;

    public BigObstacleFactory(GameObject bigObstacle, GameObject defaultObstacle)
    {
        _bigObstaclePrefab = bigObstacle;
        _defaultObstaclePrefab = defaultObstacle;
    }

    public void CreateObstacles(Vector3 basePosition)
    {
        Object.Instantiate(_bigObstaclePrefab, basePosition + new Vector3(1, 0, 0), Quaternion.identity);
        Object.Instantiate(_bigObstaclePrefab, basePosition, Quaternion.identity);
        Object.Instantiate(_defaultObstaclePrefab, basePosition + new Vector3(-1, 0, 0), Quaternion.identity);
    }
}
public class UpperObstacleFactory : IObstacleFactory
{
    private GameObject _defaultObstaclePrefab;
    private GameObject _upperObstaclePrefab;

    public UpperObstacleFactory(GameObject defaultObstacle, GameObject upperObstacle)
    {
        _defaultObstaclePrefab = defaultObstacle;
        _upperObstaclePrefab = upperObstacle;
    }

    public void CreateObstacles(Vector3 basePosition)
    {
        Object.Instantiate(_defaultObstaclePrefab, basePosition + new Vector3(1, 0, 0), Quaternion.identity);
        Object.Instantiate(_defaultObstaclePrefab, basePosition, Quaternion.identity);
        Object.Instantiate(_upperObstaclePrefab, basePosition + new Vector3(-1, 2.5f, 0), Quaternion.identity);
    }
}
public class MixedObstacleFactory : IObstacleFactory
{
    private GameObject _defaultObstaclePrefab;
    private GameObject _bigObstaclePrefab;

    public MixedObstacleFactory(GameObject defaultObstacle, GameObject bigObstacle)
    {
        _defaultObstaclePrefab = defaultObstacle;
        _bigObstaclePrefab = bigObstacle;
    }

    public void CreateObstacles(Vector3 basePosition)
    {
        Object.Instantiate(_defaultObstaclePrefab, basePosition + new Vector3(1, 0, 0), Quaternion.identity);
        Object.Instantiate(_defaultObstaclePrefab, basePosition, Quaternion.identity);
        Object.Instantiate(_bigObstaclePrefab, basePosition + new Vector3(-1, 0, 0), Quaternion.identity);
    }
}
public class DoubleUpperObstacleFactory : IObstacleFactory
{
    private GameObject _defaultObstaclePrefab;
    private GameObject _upperObstaclePrefab;

    public DoubleUpperObstacleFactory(GameObject defaultObstacle, GameObject upperObstacle)
    {
        _defaultObstaclePrefab = defaultObstacle;
        _upperObstaclePrefab = upperObstacle;
    }

    public void CreateObstacles(Vector3 basePosition)
    {
        Object.Instantiate(_defaultObstaclePrefab, basePosition + new Vector3(1, 0, 0), Quaternion.identity);
        Object.Instantiate(_upperObstaclePrefab, basePosition + new Vector3(0, 2.5f, 0), Quaternion.identity);
        Object.Instantiate(_upperObstaclePrefab, basePosition + new Vector3(-1, 2.5f, 0), Quaternion.identity);
    }
}
