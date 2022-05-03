using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // text variable
    public TextMeshProUGUI waveText;
    public int waveNumber;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateWave(int waveToAdd)
    {
        waveText.text = "Wave : " + waveToAdd;
    }
}
