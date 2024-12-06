using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ObstacleConfiguration", menuName = "Scriptable Objects/ObstacleConfiguration")]
public class ObstacleConfiguration : ScriptableObject
{
    public List<GameObject> prefabs;
    public List<Vector3> offsets;

}
