using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelTrigger : MonoBehaviour
{
    public Animator levelFadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelFadeAnimator.SetTrigger("FadeOut");
        }
    }
}
