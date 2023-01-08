using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Wave config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] float spawwnRandomFactor;
    [SerializeField] int numberOfEnemies = 10;
    [SerializeField] float moveSpedd = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new();
        foreach (Transform child in pathPrefab.transform)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawwnRandomFactor; }
    public float GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetMoveSpeed() { return moveSpedd; }
}
