using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    void Start()
    {
        SpawnEnemy();
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    void SpawnEnemy()
    {
        for(int i = 0; i < currentWave.GetEnemyCount(); i++)
        Instantiate(currentWave.GetEnemyPrefab(i), 
                    currentWave.GetStartingWaypoint().position,
                    Quaternion.identity,
                    transform);
    }
}
