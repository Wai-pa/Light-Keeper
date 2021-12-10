using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxController : MonoBehaviour
{
    private TMP_Text[] textMeshes;

    private float displayUntilTime = float.MinValue;

    void Start()
    {
        textMeshes = GetComponentsInChildren<TMP_Text>(includeInactive: true);
    }

    void Update()
    {
        if (gameObject.activeSelf && displayUntilTime < Time.time)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetText(string text, float duration)
    {
        gameObject.SetActive(true);

        foreach(var textMesh in textMeshes)
        {
            textMesh.text = text;
        }

        displayUntilTime = Time.time + duration;
    }
}
