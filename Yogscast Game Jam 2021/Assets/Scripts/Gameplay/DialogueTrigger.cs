using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueEvent dialogueEvent;
    public GameObject[] obsoletedDialogueTriggers;

    private DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = DialogueManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        dialogueManager.OnDialogueTrigger(dialogueEvent);

        foreach(var trigger in obsoletedDialogueTriggers)
        {
            trigger.SetActive(false);
        }
    }
}