using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersMenu : MonoBehaviour
{
    public static ControllersMenu instance = null;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject controllersPanel;
    GameManager manager;

    void Awake()
    {
        manager = GameManager.instance;

        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    public void OnBack()
    {
        controllersPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
