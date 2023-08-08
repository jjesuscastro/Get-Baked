using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverSequnce : MonoBehaviour
{
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject container;
    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private TMP_Text highScoreUI;

    private int score;
    private int highScore;
    private bool isHighScore = false;

    private void OnEnable()
    {
        Hide();

        LeanTween.alpha(background.GetComponent<RectTransform>(), .75f, 0.25f).setOnComplete(ShowGameOver);
    }

    public void SetScores(int _score, int _highScore)
    {
        score = _score;
        highScore = _highScore;
        isHighScore = _score > _highScore;
        highScoreUI.text = highScore.ToString();
    }

    private void ShowGameOver()
    {
        LeanTween.scale(gameOver.GetComponent<RectTransform>(), Vector3.one, 0.5f).setEaseInOutBounce().setOnComplete(() =>
        {
            LeanTween.moveY(gameOver.GetComponent<RectTransform>(), 500, 0.25f).setDelay(0.25f).setOnComplete(ShowContainer);
        });
    }

    private void ShowContainer()
    {
        LeanTween.scale(container, Vector3.one, 0.25f).setOnComplete(ShowScores);
    }

    private void ShowScores()
    {
        LeanTween.value(0, score, 1f).setOnUpdate((float value) =>
        {
            scoreUI.text = ((int)value).ToString();
        }).setOnComplete(() =>
        {
            LeanTween.scale(scoreUI.gameObject, Vector3.one * 1.25f, 0.5f).setEasePunch();

            if (isHighScore)
            {
                highScoreUI.text = score.ToString();
                LeanTween.scale(highScoreUI.gameObject, Vector3.one * 1.25f, 0.5f).setEasePunch();
            }
        });
    }

    private void Hide()
    {
        background.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        gameOver.transform.localPosition = Vector3.zero;
        gameOver.transform.localScale = Vector3.zero;
        container.transform.localScale = Vector3.zero;
    }
}
