using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private PressurePlateTrigger[] pressurePadsRequired = null;
    private Collider thisCollider;

    private void Start()
    {
        thisCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        OpenDoor();
    }

    void OpenDoor()
    {
        for (int i = 0; i < pressurePadsRequired.Length; i++)
        {
            if (!pressurePadsRequired[i].isPressurePadPressed())
            {
                thisCollider.isTrigger = false;
                return;
            }
        }

        thisCollider.isTrigger = true;
    }
}
