using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<WaveConfig> _waveConfigs;
    int _startingWave = 0;
    bool _canSpawn = true;

    void Start()
    {
        StartGame();
    }

    // Test purpouse
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StopSpawn();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartGame();
        }

    }
    void StartGame()
    {
        _canSpawn= true;
        print("Spawn started");
        StartCoroutine(SpawnWaves());
    }

    void StopSpawn()
    {
        _canSpawn= false;
        print("All waves stoped");
        StopAllCoroutines();
    }

    IEnumerator SpawnWaves()
    {
        for (int waveIndex = _startingWave; waveIndex < _waveConfigs.Count; waveIndex++)
        {
            var curentWave = _waveConfigs[waveIndex];
            yield return StartCoroutine(StartWave(curentWave));
        }
    }
    IEnumerator StartWave(WaveConfig wave)
    {
        for(int enemyCount = 0; enemyCount < wave.GetNumberOfEnemies(); enemyCount++) 
        {
            SpawnEnemys(wave);
            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }
    }

    private static void SpawnEnemys(WaveConfig wave)
    {
       var NewEnemy = Instantiate(wave.GetEnemyPrefab(),
            wave.GetWayPoints()[0].transform.position,
            Quaternion.identity);
        NewEnemy.GetComponent<EnemyMovement>().SetUpWaveConfig(wave);
    }
}
