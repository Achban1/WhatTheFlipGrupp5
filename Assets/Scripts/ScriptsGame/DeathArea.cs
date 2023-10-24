using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            // Identify which player was killed
            int killedPlayerNumber = collision.CompareTag("Player1") ? 1 : 2;

            // Increment the score of the other player
            ScoreManager.Instance.IncrementScore(killedPlayerNumber == 1 ? 2 : 1);

            // Reload the scene after a small delay
            StartCoroutine(ReloadScene());
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds (adjust as needed)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }
}
