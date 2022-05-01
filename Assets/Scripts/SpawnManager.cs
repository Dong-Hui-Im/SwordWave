using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //enemy spawn variables
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 44;
    private float spawnRangeZ = 14;
    public float enemyCount;

    //wave spawn variables
    public int waveNumber;

    void Start()
    {
        SpawnWave(waveNumber); // starts the wave at the start of the game
    }
    // increases the amount of enemies spawned by 1 every wave
    void SpawnWave(int enemiesToSpawn)
    {
        for (int i = 0; i  < enemiesToSpawn; i++)
        {
            SpawnEnemy();
        }
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // keeps track of all the enemies 
        // if there are no enemies left, increase the wave number by 1 and start a new wave
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnWave(waveNumber);
        }
    }

    // spawns the enemy at a random location
    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, Random.Range(-spawnRangeZ, spawnRangeZ));

        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }

}
