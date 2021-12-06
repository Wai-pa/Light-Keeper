using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private SoundManager soundManager;
    [SerializeField] private Slider slider;

    void Start()
    {
        soundManager = SoundManager.instance;
        slider.value = 0.5f;
        soundManager.ChangeMasterVolume(slider.value);
        slider.onValueChanged.AddListener(val => soundManager.ChangeMasterVolume(val));
    }
}
