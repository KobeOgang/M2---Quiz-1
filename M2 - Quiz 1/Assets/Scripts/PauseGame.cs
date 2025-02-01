using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; // Assign your pause panel in the Inspector
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }  
            else
            {
                Pause();
            }
                
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;  // Freezes the game
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;  // Resumes the game
        pausePanel.SetActive(false);
    }
}
