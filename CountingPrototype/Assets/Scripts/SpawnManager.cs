using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject opponentPlayerPrefab;
    public GameObject opponentCaptainPrefab;

    private float spawnRangeX = 30;
    private float spawnZMin = 17; // set min spawn Z
    private float spawnZMax = 27; // set max spawn Z

    public int enemyCount;
    public int waveCount = 1;


    private void Start()
    {
        SpawnEnemyWave(waveCount);
    }
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("OpponentTeamPlayer").Length;

        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveCount);
        }

    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < waveCount; i++)
        {
            Instantiate(opponentPlayerPrefab, GenerateSpawnPosition(), opponentPlayerPrefab.transform.rotation);
            if (i % 3 == 0)
            {
                Instantiate(opponentCaptainPrefab, GenerateSpawnPosition(), opponentCaptainPrefab.transform.rotation);
            }
        }

        waveCount++;


    }
}
