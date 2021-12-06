using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChildFollower : MonoBehaviour
{
    private List<Transform> children;

    // Start is called before the first frame update
    void Start()
    {
        children = new List<Transform>(transform.childCount);

        for (var i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        var activeChild = children.Find(c => c.gameObject.activeSelf);
        if (activeChild == null)
        {
            return;
        }

        transform.position = activeChild.position;
        activeChild.localPosition = Vector3.zero;
    }
}
