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

    private GameManager gameManager;

    void Start()
    {
        // starts the wave at the start of the game
        SpawnWave(waveNumber); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // function that determines the amount of enemies that spawn that wave
    void SpawnWave(int enemiesToSpawn)
    {
        // if 'i' is less than 'enemiesToSpawn', add 1 to 'i'
        // for each 'i' spawn an enemy
        // since 'enemiesToSpawn' is equal to the wave number
        // the amount of enemies spawned is equal to the wave number 
        for (int i = 0; i  < enemiesToSpawn; i++)
        {
            SpawnEnemy();
        }
    }

    void Update()
    {
        // keeps track of all the enemies 
        enemyCount = FindObjectsOfType<Enemy>().Length; 
        // if there are no enemies left
        if (enemyCount == 0)
        {
           // increase the wave number by one
           waveNumber++;
           // updates the wave counter to display the wave number
           gameManager.UpdateWave(waveNumber);
           // refers the 'SpawnWave' function with 'enemiesToSpawn' to be equal to the wave number;
           SpawnWave(waveNumber);
        }
    }

    // spawns the enemy at a random location
    void SpawnEnemy()
    {
        // the spawn position of the enemy is randomised inside of the boundaries
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1, Random.Range(-spawnRangeZ, spawnRangeZ));
        // the 'enemyIndex' is a random number between 0 and the lengh of the enemy prefabs
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        // spawns a enemy from the enemy prefabs using the 'enemyIndex'
        // and spawns them at 'spawnPos' which was the randomised position created earlier
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
