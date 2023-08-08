using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameOverSequnce gameOverSequnce;
    private int score;
    private int highScore;

    public void ShowGameOver(int _score)
    {
        AudioController.instance?.PlayGameOverMusic();
        score = _score;
        highScore = PlayerPrefs.GetInt("HIGH_SCORE", 0);
        gameOverSequnce.SetScores(score, highScore);

        if (_score > highScore)
        {
            highScore = _score;
            PlayerPrefs.SetInt("HIGH_SCORE", highScore);
        }

        gameObject.SetActive(true);
    }
}
