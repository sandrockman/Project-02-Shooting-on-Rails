using UnityEngine;
using System.Collections;

public class FacingWaypointForcedLocation : FacingWaypoint {
    //information to store for a waypoint to rotate looking at a fixed location

    //new location to look at
	public Vector3 lookTarget;
    //time to rotate to target
	public float timeToTarget;
    //time locked on target
	public float stareTime;

}
