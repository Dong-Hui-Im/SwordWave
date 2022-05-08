using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // text variable
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI gameOverText;
    public int waveNumber;

    // destroy enemy variable
    public int enemiesOnScreen;

    void Update()
    {
        // if the player  cannot be located
        if (GameObject.Find("PlayerShield") == null)
        {
            // display the 'game over' text
            gameOverText.text = "GAME OVER";
            // refers to the 'DestroyAllEnemies' function
            DestroyAllEnemies();
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
        enemiesOnScreen = GameObject.FindGameObjectsWithTag("Enemy");
        // if 'i' is less than 'enemiesOnScreen', add 1 to 'i'
        // for each 'i' destroy an enemy
        // this continues until i is equal to 'enemiesOnScreen' 
        // by then all of the enemies should have been destroyed
        for (var i = 0 ; i < enemiesOnScreen.Length ; i++)
        {
            Destroy(enemiesOnScreen[i])
        }
    }
}
