using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public Animator doorAnimator;
    private bool keyCollected = false;
  

    public bool IsKeyCollected()
    {
        return keyCollected; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !keyCollected)
        {
            keyCollected = true;
            AudioManager.instance.PlayKeyCollected();
            AudioManager.instance.PlayDoorOpen();
            doorAnimator.SetTrigger("OpenDoor");
            gameObject.SetActive(false);
        }
    }
}
