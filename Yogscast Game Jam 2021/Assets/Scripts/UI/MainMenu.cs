using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance = null;
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;
    [SerializeField] private GameObject camera;
    GameManager manager;

    void Awake()
    {
        camera.GetComponent<AudioListener>().enabled = false;
        manager = GameManager.instance;
        Time.timeScale = 0f;

        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        
    }

    public void OnStart()
    {
        mainMenuPanel.SetActive(false);
        camera.GetComponent<AudioListener>().enabled = true;
        Time.timeScale = 1f;
    }

    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void OnCredits()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
}
