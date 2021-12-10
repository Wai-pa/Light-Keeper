using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private AnimatorProxy[] animatorProxies;

    private WaypointNavController waypointNavController;

    public bool isAlert;
    public float flyingSpeed;

    private bool wasAlert;
    private bool xIsFlipped;

    // Start is called before the first frame update
    void Start()
    {
        waypointNavController = GetComponent<WaypointNavController>();
        animatorProxies = GetComponentsInChildren<AnimatorProxy>();

        SetAnimators();
        SetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (wasAlert != isAlert)
        {
            SetAnimators();
            SetSpeed();
        }

        SetDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        isAlert = true;
        SetAnimators();
        SetSpeed();
    }

    private void SetAnimators()
    {
        foreach (var animator in animatorProxies.Where(a => a != null))
        {
            animator.SetBool("bird_alert", isAlert);
        }
    }

    private void SetSpeed()
    {
        waypointNavController.speed = isAlert ? flyingSpeed : 0;

        wasAlert = isAlert;
    }

    private void SetDirection()
    {
        if (xIsFlipped != waypointNavController.movementDirection.x < 0)
        {
            xIsFlipped = !xIsFlipped;

            foreach (var animator in animatorProxies.Where(a => a != null))
            {
                animator.FlipX(xIsFlipped);
            }
        }
    }
}
