using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightworldReplacer : MonoBehaviour
{
    public float lightworldConversionDuration;
    public float darkworldConversionDuration;

    public float? timeToConvertToLightworld;
    public float? timeToConvertToDarkworld;

    public AudioClip changeToLightworldSound;
    public AudioClip changeToDarkworldSound;

    private bool showingLightworldObject;

    private new BoxCollider2D collider;

    private List<GameObject> lightworldObjects;
    private List<GameObject> darkworldObjects;
    private AudioSource audioSource;

    private const string lightEffectTag = "Light Effect";
    private const string lightworldObjectTag = "Lightworld Object";
    private const string darkworldObjectTag = "Darkworld Object";

    void Start()
    {
        timeToConvertToLightworld = null;
        timeToConvertToDarkworld = null;

        showingLightworldObject = false;

        collider = GetComponent<BoxCollider2D>();

        lightworldObjects = new List<GameObject>();
        darkworldObjects = new List<GameObject>();

        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.tag == lightworldObjectTag)
            {
                lightworldObjects.Add(child.gameObject);
            }
            else if (child.tag == darkworldObjectTag)
            {
                darkworldObjects.Add(child.gameObject);
            }
        }

        audioSource = GetComponent<AudioSource>();

        SetLightworld(false, playSound: false);
    }

    void Update()
    {
        var now = Time.time;

        if (timeToConvertToDarkworld.HasValue && timeToConvertToDarkworld.Value <= now)
        {
            SetLightworld(false);
            timeToConvertToDarkworld = null;
        }
        else if (timeToConvertToLightworld.HasValue && timeToConvertToLightworld.Value <= now)
        {
            SetLightworld(true);
            timeToConvertToLightworld = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != lightEffectTag)
        {
            return;
        }

        OnIllumination();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != lightEffectTag)
        {
            return;
        }

        OnIllumination();
    }

    private void OnIllumination()
    {
        if (!showingLightworldObject)
        {
            timeToConvertToLightworld = Time.time + lightworldConversionDuration;
        }
        else
        {
            timeToConvertToDarkworld = null;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != lightEffectTag)
        {
            return;
        }

        var lightBeamColliders = GameObject.FindGameObjectsWithTag(lightEffectTag)
            .Select(go => go.GetComponent<Collider2D>());

        if (!lightBeamColliders.Any(c => collider.IsTouching(c)))
        {
            if (showingLightworldObject)
            {
                timeToConvertToDarkworld = Time.time + darkworldConversionDuration;
            }
            else
            {
                timeToConvertToLightworld = null;
            }
        }        
    }

    private void SetLightworld(bool isLightworld, bool playSound = true)
    {
        foreach(var lightworldObject in lightworldObjects)
        {
            lightworldObject.SetActive(isLightworld);
        }
        foreach(var darkworldObject in darkworldObjects)
        {
            darkworldObject.SetActive(!isLightworld);
        }

        showingLightworldObject = isLightworld;

        if (playSound)
        {
            if (isLightworld)
            {
                audioSource.PlayOneShot(changeToLightworldSound);
            }
            else
            {
                audioSource.PlayOneShot(changeToDarkworldSound);
            }
        }
    }
}
