using UnityEngine;
using System.Collections;

public class FacingWaypointFreeMovement : FacingWaypoint {
    //information to store for a waypoint to rotate any way the user wishes for a fixed time

    //horizonatal pan speed
    public float panSpeedH = 1;
    //vertical pan speed
	public float panSpeedV = 1;
    //time alloted to free movement waypoint
	public float freeTime = 1;
}
