using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // text variables
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI gameOverText;
    public int waveNumber;

    void Update()
    {
        // if the player cannot be found
        if (GameObject.Find("PlayerShield") == null)
        {
            // display the 'game over' text
            gameOverText.text = "GAME OVER";
        }
    }
    // wave text function
    public void UpdateWave(int waveToAdd)
    {
        // updates the text with the correct wave number at the end
        waveText.text = "Wave : " + waveToAdd;
    }
}
