using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private GameObject objectToMove;
    [SerializeField] private GameObject holder;
    [SerializeField] private Transform holderTransform;
    public bool objectIsGrounded;

    void Start()
    {
        objectToMove.GetComponent<Rigidbody>().useGravity = true;
    }

    public void PickUp()
    {
        objectToMove.GetComponent<Rigidbody>().useGravity = false;
        objectToMove.GetComponent<Rigidbody>().isKinematic = true;
        objectToMove.transform.position = holderTransform.transform.position;
        objectToMove.transform.rotation = holderTransform.transform.rotation;
        objectToMove.transform.parent = holder.transform.parent;
        objectIsGrounded = false;
    }

    public void DropDown()
    {
        objectToMove.GetComponent<Rigidbody>().useGravity = true;
        objectToMove.GetComponent<Rigidbody>().isKinematic = false;
        objectToMove.transform.parent = null;
        objectToMove.transform.position = holderTransform.transform.position;
        objectIsGrounded = true;
    }
}
