using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;

    public DialogueBoxController playerDialogueBox;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDialogueTrigger(DialogueEvent dialogueEvent)
    {
        switch (dialogueEvent)
        {
            case DialogueEvent.IShouldGetUpThere:
                playerDialogueBox.SetText("Hmmm, I should get up on that platform...", 5);
                break;
            case DialogueEvent.WowIGotUpHere:
                playerDialogueBox.SetText("Wow, I am on this platform now!", 4);
                break;
            case DialogueEvent.IShouldGetANewLightBulb:
                playerDialogueBox.SetText("Sigh... I guess I should replace that", 5);
                break;
        }
    }
}
