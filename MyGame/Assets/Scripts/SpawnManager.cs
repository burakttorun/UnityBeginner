using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesPrefab;
    public GameObject powerUpPrefab;

    private float xSpawnRange = 11.0f;
    private float rangeY = 0.51f;
    private float zEnemySpawn = 10.0f;
    private float zPowerUpRange = 5.0f;

    private float powerUpSpawnTime = 5.0f;
    private float enemySpawnTime = 1.0f;
    private float startDelay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawn", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerUp", startDelay, powerUpSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void EnemySpawn()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, 4);
        Vector3 spawnPos = new Vector3(randomX, rangeY, zEnemySpawn);
        Instantiate(enemiesPrefab[randomIndex], spawnPos, enemiesPrefab[randomIndex].transform.rotation);
    }

    void SpawnPowerUp()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zPowerUpRange, zPowerUpRange);

        Vector3 spawnPos = new Vector3(randomX, rangeY, randomZ);
        Instantiate(powerUpPrefab, spawnPos, powerUpPrefab.transform.rotation);
    }
}
