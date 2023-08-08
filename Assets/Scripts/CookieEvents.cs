using UnityEngine;

public class CookieEvents : MonoBehaviour
{
    [SerializeField] FoodSpawner foodSpawner;
    [SerializeField] ScoreHandler scoreHandler;
    [SerializeField] LifeHandler lifeHandler;
    [SerializeField] GameOver gameOver;

    private AudioController audioController;

    private void Awake()
    {
        audioController = AudioController.instance;
    }

    void Start()
    {
        audioController?.PlayGameMusic();
        foodSpawner.onFoodSpawned += AddFoodListener;
        lifeHandler.onGameOver += OnGameOver;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    void AddFoodListener(Food _food)
    {
        _food.onFoodEaten += OnFoodEaten;
        _food.onFoodFell += OnFoodFell;
    }

    void OnFoodEaten(int _value)
    {
        audioController?.Munch();
        scoreHandler.AddScore(_value);
    }

    void OnFoodFell()
    {
        audioController?.LoseLife();
        lifeHandler.LoseLife();
    }

    void OnGameOver()
    {
        gameOver.ShowGameOver(scoreHandler.GetScore());
    }
}
