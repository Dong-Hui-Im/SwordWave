using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //enemy spawn variables
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 44;
    private float spawnRangeZ = 14;

    //wave spawn variables
    public int waveNumber;

    public float enemyCount;

    void Start()
    {
        SpawnWave(waveNumber);
    }

    void SpawnWave(int enemiesToSpawn)
    {
        for (int i = 0; i  < enemiesToSpawn; i++)
        {
            SpawnEnemy();
        }
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnWave(waveNumber);
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, Random.Range(-spawnRangeZ, spawnRangeZ));

        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }

}
