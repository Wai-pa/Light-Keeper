using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueEvent dialogueEvent;
    public GameObject[] obsoletedDialogueTriggers;

    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = DialogueManager.instance;
    }

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