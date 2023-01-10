using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    List<WaveConfig> _waveConfigs;
    int _startingWave = 0;
    bool _canSpawn = false;

    public int _enemysLeft;

    // 1. Define a delegate
    // 2 Define an event based on that delegate
    // Rise yhe event
    //1
    public delegate void AllEnemysDiedEventHandler(object source, EventArgs args);
    //2
    public event AllEnemysDiedEventHandler AllEnemiesDied;

    void Start()
    {
        StartGame();
        foreach(WaveConfig waveConfig in _waveConfigs)
        {
            _enemysLeft += waveConfig.GetNumberOfEnemies();
        }
    }
    void StartGame()
    {
        _canSpawn = true;
        print("Spawn started");
        StartCoroutine(SpawnWaves());
    }
    public void OnEnemyDied()
    {
        _enemysLeft--;
        if (_enemysLeft <= 0)
        {
            if (AllEnemiesDied != null)
            {
                AllEnemiesDied(this, EventArgs.Empty);
            }
        }
    }
    #region For test only
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
   
    void StopSpawn()
    {
        _canSpawn= false;
        print("All waves stoped");
        StopAllCoroutines();
        #endregion
    }
    #region Spawn Enemys
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
        for (int enemyCount = 0; enemyCount < wave.GetNumberOfEnemies(); enemyCount++)
        {
            SpawnEnemys(wave);
            yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
        }
    }

    private void SpawnEnemys(WaveConfig wave)
    {
        var NewEnemy = Instantiate(wave.GetEnemyPrefab(),
             wave.GetWayPoints()[0].transform.position,
             Quaternion.identity);
        NewEnemy.GetComponent<EnemyMovement>().SetUpWaveConfig(wave);
    }
    #endregion

   
    
}
