using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform GetWaypoints(int waypointsIndex)
    {
        return transform.GetChild(waypointsIndex);
    }


    public int GetWaypointIndex(int currentWaypointIndex)
    {
        int nextWaypointIndex = currentWaypointIndex + 1;

        if (nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }
        return nextWaypointIndex;
    }
     
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
