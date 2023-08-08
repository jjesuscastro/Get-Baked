using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    const string MUSIC_VOLUME = "MUSIC_VOLUME";
    const string SFX_VOLUME = "SFX_VOLUME";

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider sfxVolumeSlider;

    float musicVolume;
    float sfxVolume;

    private void Awake()
    {
        SetVolume();
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    private void Start()
    {
        //! Unity Bug: AudioMixer.SetFloat doesn't work in Awake
        SetVolume();
    }

    private void SetVolume()
    {
        musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME, 1);
        sfxVolume = PlayerPrefs.GetFloat(SFX_VOLUME, 1);

        musicVolumeSlider.value = musicVolume;
        sfxVolumeSlider.value = sfxVolume;

        SetMusicVolume(musicVolume);
        SetSFXVolume(sfxVolume);
    }

    private void SetMusicVolume(float _volume)
    {
        audioMixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(_volume) * 20);
        PlayerPrefs.SetFloat(MUSIC_VOLUME, _volume);
    }

    private void SetSFXVolume(float _volume)
    {
        audioMixer.SetFloat(SFX_VOLUME, Mathf.Log10(_volume) * 20);
        PlayerPrefs.SetFloat(SFX_VOLUME, _volume);
    }
}
