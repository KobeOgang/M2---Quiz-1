using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject winPanel; 
    public KeyPickup keyPickup;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && keyPickup.IsKeyCollected())
        {
            AudioManager.instance.StopFootsteps();
            winPanel.SetActive(true); 
            Time.timeScale = 0f; 
        }
    }
}
