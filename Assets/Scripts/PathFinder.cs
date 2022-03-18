using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints(); // get a list of waypoints from the SO
        transform.position = waypoints[waypointIndex].position; // start the enemy at the first waypoint
        // Debug.Log("amount: " + waveConfig.GetWaypoints().Count);
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {  
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta); // moving
            if(transform.position == targetPosition)
            {
                // Debug.Log("11111");
                // Debug.Log("transform: " + transform.position);
                // Debug.Log("target: " + targetPosition);
                // Debug.Log("waypoint: " + waypoints[waypointIndex]);
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
