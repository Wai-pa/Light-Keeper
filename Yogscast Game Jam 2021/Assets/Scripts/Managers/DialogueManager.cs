using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;

    public DialogueBoxController playerDialogueBox;
    public DialogueBoxController coupleDialogueBox;
    public DialogueBoxController girlDialogueBox;

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
                StartCoroutine(IShouldGetANewLightBulb());
                break;
            case DialogueEvent.PeopleOnBench:
                StartCoroutine(PeopleOnBench());
                break;
            case DialogueEvent.Store:
                playerDialogueBox.SetText("Dammit, the stores shut!", 4);
                break;
            case DialogueEvent.OppositeDayGirl:
                StartCoroutine(OppositeDayGirl());
                break;
            case DialogueEvent.StuckUnderStairs:
                playerDialogueBox.SetText("Maybe I can get out if I let it crumble…", 4);
                break;
            case DialogueEvent.NeedToGetSeeds:
                playerDialogueBox.SetText("Maybe I can grow those seeds that bird had in this", 4);
                break;
            case DialogueEvent.PressurePlatesUnlockDoor:
                StartCoroutine(PressurePlatesUnlockDoor());
                break;
            case DialogueEvent.PeopleOnBenchAfterRessurection:
                StartCoroutine(PeopleOnBenchAfterRessurection());
                break;
        }
    }

    private IEnumerator IShouldGetANewLightBulb()
    {
        playerDialogueBox.SetText("...", 2);

        yield return new WaitForSeconds(2f);

        playerDialogueBox.SetText("*Sigh*", 2);

        yield return new WaitForSeconds(2f);

        playerDialogueBox.SetText("I guess I should replace that", 4);
    }

    private IEnumerator PeopleOnBench()
    {
        coupleDialogueBox.SetText("Hey, do you know what day it is?", 2);

        yield return new WaitForSeconds(2f);

        playerDialogueBox.SetText("Uhh, Tuesday I think?", 2);

        yield return new WaitForSeconds(2f);

        coupleDialogueBox.SetText("Oh… Okay, thanks", 2);

        yield return new WaitForSeconds(2f);

        playerDialogueBox.SetText("... The way you asked be that made me think today was something unusual", 2);

        yield return new WaitForSeconds(2);

        coupleDialogueBox.SetText("No, I don’t think so… Why would you think that?", 2);

        yield return new WaitForSeconds(2f);

        coupleDialogueBox.SetText("Just the way you asked it is all", 2);

        yield return new WaitForSeconds(2f);

        playerDialogueBox.SetText("Oh, Okay", 3);
    }

    private IEnumerator OppositeDayGirl()
    {
        girlDialogueBox.SetText("Hey, do you know what day it is?", 2);

        yield return new WaitForSeconds(2f);

        playerDialogueBox.SetText("Why is everyone asking that today??", 2);

        yield return new WaitForSeconds(2f);

        girlDialogueBox.SetText("It’s OPPOSITE DAY!", 4);
    }

    private IEnumerator PressurePlatesUnlockDoor()
    {
        playerDialogueBox.SetText("I need something to weigh down both pressure plates to get into my house", 2);

        yield return new WaitForSeconds(2f);

        playerDialogueBox.SetText("Why’d I let the locksmith talk me into this…", 3);
    }

    private IEnumerator PeopleOnBenchAfterRessurection()
    {
        coupleDialogueBox.SetText("Are you okay? You look a bit pale?", 2);

        yield return new WaitForSeconds(2f);

        coupleDialogueBox.SetText("I have a bit of a skull ache", 2);

        yield return new WaitForSeconds(2f);

        coupleDialogueBox.SetText("A what ache?", 2);

        yield return new WaitForSeconds(2f);

        coupleDialogueBox.SetText("A bit of a headache. Why, what did you think I said?", 2);

        yield return new WaitForSeconds(2f);

        coupleDialogueBox.SetText("Nothing, nevermind…", 2);
    }
}
