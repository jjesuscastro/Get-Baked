using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreUI;
    private int score = 0;

    public void AddScore(int _value)
    {
        score += _value;
        if (scoreUI != null)
        {
            scoreUI.text = score.ToString();
            LeanTween.scale(scoreUI.gameObject, Vector3.one * 2, 0.5f).setEasePunch();
        }
    }

    public int GetScore() => score;
}
