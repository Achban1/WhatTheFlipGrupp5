using UnityEngine;
using TMPro; // If you're using TextMeshPro for the score display

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int player1Score = 0;
    public int player2Score = 0;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void IncrementScore(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Score++;
            if (player1ScoreText) player1ScoreText.text = "Player 1: " + player1Score.ToString();
        }
        else if (playerNumber == 2)
        {
            player2Score++;
            if (player2ScoreText) player2ScoreText.text = "Player 2: " + player2Score.ToString();
        }
    }

    // Call this method to reset scores (e.g., starting a new game)
    public void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;

        if (player1ScoreText) player1ScoreText.text = player1Score.ToString();
        if (player2ScoreText) player2ScoreText.text = player2Score.ToString();
    }
}
