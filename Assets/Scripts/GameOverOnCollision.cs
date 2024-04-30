// Chat GPT Helped Write this Script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Include this for scene management

public class GameOverOnCollision : MonoBehaviour
{
    public GameObject playerObject;
    public float detectionDistance = 1.0f;

    void Update()
    {
        if (playerObject == null)
        {
            Debug.Log("Player object is not assigned.");
            return;
        }

        float currentDistance = Vector3.Distance(transform.position, playerObject.transform.position);
        Debug.Log("Current distance to player: " + currentDistance); // Logs current distance each frame

        if (currentDistance <= detectionDistance)
        {
            Debug.Log("Player has touched the black hole!");
            EndGame();
        }
    }

    private void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}