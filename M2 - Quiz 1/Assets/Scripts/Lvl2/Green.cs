using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    public PuzzleManager manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
            AudioManager.instance.PlaySwitched();
            Debug.Log("Hello");
            manager.AddNumber(1);

        }
    }
}
