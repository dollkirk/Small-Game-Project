using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{

    [SerializeField]
    private WayPoints wayPointPath;

    [SerializeField]
    private float speed;

    private int targetWaypointIndex;

    private Transform targetWaypoint;
    private Transform previousWaypoint;

    private float timeToWaypoint;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        float elapsedPercentage = elapsedTime / timeToWaypoint;

        //Creates a smooth stop when at end of waypoints either end
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);

        //Moves the platform to the next waypoint position
        transform.position = Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapsedPercentage);

        //Moves the platform to the next waypoint rotation
        transform.rotation = Quaternion.Lerp(previousWaypoint.rotation, targetWaypoint.rotation, elapsedPercentage);

        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        previousWaypoint = wayPointPath.GetWaypoints(targetWaypointIndex);
        targetWaypointIndex = wayPointPath.GetWaypointIndex(targetWaypointIndex);
        targetWaypoint = wayPointPath.GetWaypoints(targetWaypointIndex);

        elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }

    //This trigger is to assign whatever triggers the trigger to become a transform child of the transform of the platform
    //This therefore, moves the player object along with the platform
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    //This switches it off
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
