using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;

    public AudioClip lifeLight;
    public AudioClip lightbulb;
    public AudioClip windAmbience;
    public AudioClip windAndBirdsAmbience;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }

    public void SetBackgroundMusic(BackgroundMusic backgroundMusic)
    {
        if (backgroundMusic == BackgroundMusic.None)
        {
            musicSource.Stop();
            return;
        }

        var clipToPlay = backgroundMusic switch
        {
            BackgroundMusic.LifeLight => lifeLight,
            BackgroundMusic.Lightbulb => lightbulb,
            BackgroundMusic.WindAmbience => windAmbience,
            BackgroundMusic.WindAndBirdsAmbiance => windAndBirdsAmbience,
        };
        musicSource.clip = clipToPlay;
        musicSource.Play();
    }

    public void ChangeMasterVolume( float value)
    {
        AudioListener.volume = value;
    }
}
