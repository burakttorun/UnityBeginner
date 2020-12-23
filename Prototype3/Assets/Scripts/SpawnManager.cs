﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    public GameObject[] obstaclePrefabs;
    private float startDelay = 1.0f;
    private float repeatRate = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        int randomObstacle = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomObstacle], spawnPos, obstaclePrefabs[randomObstacle].transform.rotation);
    }
}
