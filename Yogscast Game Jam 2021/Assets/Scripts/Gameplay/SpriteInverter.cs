using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInverter : MonoBehaviour
{
    public enum DefaultSpriteType
    {
        Darkness,
        Light,
    }

    public DefaultSpriteType defaultSpriteType;
    public GameObject darknessSpriteRendererPrefab;
    public GameObject lightSpriteRendererPrefab;
    public Material invertColoursMaterial;

    private void Awake()
    {
        var parentSpriteRenderer = GetComponent<SpriteRenderer>();
        var sprite = parentSpriteRenderer.sprite;
        Destroy(parentSpriteRenderer);

        RuntimeAnimatorController animatorController = null;
        if (TryGetComponent(out Animator parentAnimator))
        {
            animatorController = parentAnimator.runtimeAnimatorController;
            Destroy(parentAnimator);
        }

        var darknessSpriteGameObject = GameObject.Instantiate(darknessSpriteRendererPrefab, transform);
        var lightSpriteGameObject = GameObject.Instantiate(lightSpriteRendererPrefab, transform);

        var darknessSpriteRenderer = darknessSpriteGameObject.GetComponent<SpriteRenderer>();
        var lightSpriteRenderer = lightSpriteGameObject.GetComponent<SpriteRenderer>();

        darknessSpriteRenderer.sprite = sprite;
        lightSpriteRenderer.sprite = sprite;

        if (defaultSpriteType == DefaultSpriteType.Darkness)
        {
            lightSpriteRenderer.material = invertColoursMaterial;
        }
        else
        {
            darknessSpriteRenderer.material = invertColoursMaterial;
        }

        var darknessAnimator = darknessSpriteGameObject.GetComponent<Animator>();
        var lightAnimator = lightSpriteGameObject.GetComponent<Animator>();
        if (animatorController == null)
        {
            Destroy(darknessAnimator);
            Destroy(lightAnimator);
        }
        else
        {
            darknessAnimator.runtimeAnimatorController = animatorController;
            lightAnimator.runtimeAnimatorController = animatorController;
        }
    }
}
