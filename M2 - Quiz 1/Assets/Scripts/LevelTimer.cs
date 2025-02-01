using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float timeLimit = 60f; 
    public TMP_Text timerText; 
    public GameObject gameOverPanel; 

    private float currentTime; 
    private bool isGameOver = false; 

    private void Start()
    {
        currentTime = timeLimit; 
        UpdateTimerText(); 
    }

    private void Update()
    {
        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(0, currentTime); 
            UpdateTimerText();

            if (currentTime <= 0)
            {
                TriggerGameOver(); 
            }
        }
    }

    private void UpdateTimerText()
    {
        // Format the time as MM:SS and display it
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = $"Timer: {minutes:00}:{seconds:00}";
    }

    private void TriggerGameOver()
    {
        AudioManager.instance.StopFootsteps();
        isGameOver = true;
        Time.timeScale = 0f; 
        gameOverPanel.SetActive(true);
    }
}
