using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeMusicSetter : MonoBehaviour
{
    private SoundManager soundManager;
    [SerializeField] AudioClip themeMusic;

    private void Awake()
    {
        soundManager = SoundManager.instance;
    }

    void Start()
    {
        soundManager.musicSource.clip = themeMusic;
        soundManager.musicSource.Play();
    }
}
