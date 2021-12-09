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
    public AudioClip lightbulbCrack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        SoundManager.instance.PlaySound(lightbulbCrack);
        SoundManager.instance.SetBackgroundMusic(BackgroundMusic.None);

        yield return new WaitForSeconds(noticeLightBuldDelay);

        DialogueManager.instance.OnDialogueTrigger(DialogueEvent.IShouldGetANewLightBulb);

        yield return new WaitForSeconds(doorOpenDelay);

        doorLight.SetActive(true);
    }
}
