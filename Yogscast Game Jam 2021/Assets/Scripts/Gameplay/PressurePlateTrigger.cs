using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateTrigger : MonoBehaviour
{
    [SerializeField] private GameObject target;

    void OnTriggerStay(Collider other)
    {
        target.GetComponent<Collider>().isTrigger = true;

        if (other.CompareTag("Movable Object"))
        {
            other.attachedRigidbody.isKinematic = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        target.GetComponent<Collider>().isTrigger = false;
    }
}
