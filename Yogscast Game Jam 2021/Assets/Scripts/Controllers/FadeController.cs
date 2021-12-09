using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    public StartingSceneEvents startingSceneEvents;

    public void OnFadeInComplete()
    {
        startingSceneEvents?.OnFadeInComplete();
    }

    public void OnFadeOutComplete()
    {
        SceneManager.LoadScene("_Level Design_");
    }
}
