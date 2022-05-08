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

    void Update()
    {
        // if the player  cannot be located
        if (GameObject.Find("PlayerShield") == null)
        {
            // display the 'game over' text
            gameOverText.text = "GAME OVER";
        }
    }
    // function that updates the wave counter
    public void UpdateWave(int waveToAdd)
    {
        // updates the wave counter with the correct wave
        waveText.text = "Wave : " + waveToAdd;
    }
}
