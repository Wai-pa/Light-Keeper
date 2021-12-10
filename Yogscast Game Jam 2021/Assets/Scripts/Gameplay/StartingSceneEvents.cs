using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSceneEvents : MonoBehaviour
{
    public float breakLightBuldDelay = 2;
    public float noticeLightBuldDelay = 3;
    public float doorOpenDelay = 2;

    public GameObject inputManager;
    public GameObject roomLight;
    public GameObject doorLight;
    public LightbulbController lightbulbController;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnFadeInComplete()
    {
        StartCoroutine(BreakLightBulb());
    }

    private IEnumerator BreakLightBulb()
    {
        yield return new WaitForSeconds(breakLightBuldDelay);

        inputManager.SetActive(true);
        roomLight.SetActive(false);

        lightbulbController.Break();

        yield return new WaitForSeconds(noticeLightBuldDelay);

        DialogueManager.instance.OnDialogueTrigger(DialogueEvent.IShouldGetANewLightBulb);

        yield return new WaitForSeconds(doorOpenDelay);

        doorLight.SetActive(true);
    }
}
