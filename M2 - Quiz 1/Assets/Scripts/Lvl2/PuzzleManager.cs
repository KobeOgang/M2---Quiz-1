using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] GameObject Chest;
    [SerializeField] GameObject Key;
    [SerializeField] GameObject Green;
    [SerializeField] GameObject Red;
    [SerializeField] GameObject Yellow;

    [SerializeField] GameObject wrongSequenceText;

    private List<int> correctSequence = new List<int> {1,2,3};
    private List<int> playerSequence = new List<int>{ };

    private void Start()
    {
        Key.SetActive(false);
        Chest.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (playerSequence.Count == 3)
        {
            CheckSequence();
        }

    }
    public void AddNumber(int newNumber)
    {
        playerSequence.Add(newNumber);
        Debug.Log("Added Number: " + newNumber);
    }

    private void CheckSequence()
    {
        bool isCorrect = true;

        for (int i = 0; i < correctSequence.Count; i++)
        {
            if (playerSequence[i] != correctSequence[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            Debug.Log("Sequence is CORRECT!");
            Destroy(Chest);
            Destroy(Red);
            Destroy(Yellow);
            Destroy(Green);
            Key.SetActive(true);
        }
        else
        {
            Debug.Log("Sequence is WRONG!");
            StartCoroutine(ShowWrongSequenceMessage());
        }
        playerSequence.Clear();
    }

    private IEnumerator ShowWrongSequenceMessage()
    {
        wrongSequenceText.SetActive(true);
        yield return new WaitForSeconds(2f);
        wrongSequenceText.SetActive(false);
    }

}
