using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleTwo : MonoBehaviour
{
    [SerializeField] private GameObject Green;
    [SerializeField] private GameObject Red;
    [SerializeField] private GameObject Yellow;

    private List<string> correctSequence = new List<string> { "Green", "Red", "Yellow" };
    private List<string> playerSequence = new List<string>();

    private Collider2D greenCollider;

    private void Update()
    {
        if (Green != null && Green.GetComponent<Collider2D>().isTrigger )
        {
            Debug.Log("Hello");
        }
    }


    private void RestartLevel()
    {
        Debug.Log("Incorrect sequence. Restarting level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}