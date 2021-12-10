using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightbulbController : MonoBehaviour
{
    public AudioClip humLoop;
    public AudioClip crack;

    public GameObject fixedSprite;
    public GameObject brokenSprite;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Break()
    {
        audioSource.Stop();
        audioSource.loop = false;
        audioSource.PlayOneShot(crack);

        fixedSprite.SetActive(false);
        brokenSprite.SetActive(true);
    }
}
