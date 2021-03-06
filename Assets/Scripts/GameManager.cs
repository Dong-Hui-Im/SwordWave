using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // text variable
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI gameOverText;
    public int waveNumber;
    public Button restartButton;

    // destroy enemy variable
    public int enemiesOnScreen;

    void Update()
    {
        // if the player  cannot be located
        if (GameObject.Find("Player") == null)
        {
            // deactivates the spawner so that no more enemies spawn
            GameObject spawner = GameObject.Find("SpawnManager");
            spawner.SetActive(false);
            // refers to the 'DestroyAllEnemies' function
            DestroyAllEnemies();
            // display the 'game over' text
            gameOverText.text = "GAME OVER";
            gameOverText.gameObject.SetActive(true);
            // display the 'restart' button
            restartButton.gameObject.SetActive(true);  
        }
    }
    // function that updates the wave counter
    public void UpdateWave(int waveToAdd)
    {
        // updates the wave counter with the correct wave
        waveText.text = "Wave : " + waveToAdd;
    }

    public void DestroyAllEnemies()
    {
        // 'enemiesOnScreen' is equal to all the game objects with the tag 'Enemy' on screen
        GameObject[] enemiesOnScreen = GameObject.FindGameObjectsWithTag("Enemy");
        // if 'i' is less than 'enemiesOnScreen', add 1 to 'i'
        // for each 'i' destroy an enemy
        // this continues until i is equal to 'enemiesOnScreen' 
        // by then all of the enemies should have been destroyed
        foreach (var gameEnemy in enemiesOnScreen)
        {
            Destroy(gameEnemy);
        }
    }
    // restart game function
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
