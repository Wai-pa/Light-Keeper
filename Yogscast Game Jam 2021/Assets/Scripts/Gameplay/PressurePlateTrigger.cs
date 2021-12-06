using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    [SerializeField] private bool isPressed = false;

    void OnTriggerStay(Collider other)
    {
        isPressed = true;
    }

    void OnTriggerExit(Collider other)
    {
        isPressed = false;
    }

    public bool isPressurePadPressed()
    {
        return isPressed;
    }
}
