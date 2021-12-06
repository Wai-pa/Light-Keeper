using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNavController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed;

    private int currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWaypoint();
        Move();
    }

    private void UpdateWaypoint()
    {
        var distanceToWaypoint = Vector3.Distance(waypoints[currentWaypoint].position, transform.position);
        var nextWaypointThreshold = 0.1f * speed;

        if (distanceToWaypoint > nextWaypointThreshold)
        {
            return;
        }

        currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
    }

    private void Move()
    {
        var movementDirection = (waypoints[currentWaypoint].position - transform.position).normalized;

        transform.position += movementDirection * speed * Time.deltaTime;
    }
}
