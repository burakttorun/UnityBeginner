using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Singleton design patter.
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            //create logic to create the instance
            if (_instance == null)
            {
                GameObject go = new GameObject("SpawnManager");
                go.AddComponent<SpawnManager>();
            }

            return _instance;
        }
    }
    private void Awake()
    {
        if(_instance !=null && _instance != this)
        {
            Destroy(gameObject); //ensures that there aren't multiple Singletons.
        }

        _instance = this;
    }


    public GameObject[] animalPrefabs;
    private float spawnRangeX = 15;
    private float spawnRangeZ = 25;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
