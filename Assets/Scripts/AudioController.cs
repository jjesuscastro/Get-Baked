using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    AudioSource gameMusic;
    [SerializeField]
    AudioSource gameOverMusic;
    [SerializeField]
    AudioSource munch;
    [SerializeField]
    AudioSource loseLife;

    #region Singleton
    public static AudioController instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple AudioControllers found");
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public void PlayGameMusic()
    {
        gameOverMusic.Stop();
        gameMusic.Play();
    }

    public void PlayGameOverMusic()
    {
        gameMusic.Stop();
        gameOverMusic.Play();
    }

    public void Munch()
    {
        munch.Play();
    }

    public void LoseLife()
    {
        loseLife?.Play();
    }
}