using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public static CreditsMenu instance = null;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject creditsPanel;
    GameManager manager;

    void Awake()
    {
        manager = GameManager.instance;

        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    public void OnBack()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
