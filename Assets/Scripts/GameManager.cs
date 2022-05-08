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

    void Start()
    {
        
    }

    void Update()
    {
        if (GameObject.Find("PlayerShield") == null)
        {
            gameOverText.text = "GAME OVER";
        }
    }

    public void UpdateWave(int waveToAdd)
    {
        waveText.text = "Wave : " + waveToAdd;
    }
}
