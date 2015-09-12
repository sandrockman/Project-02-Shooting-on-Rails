using UnityEngine;
using System.Collections;

/*
 * @author Mike Dobson
 * */

[System.Serializable]
public class ScriptWaypoint{

    [Tooltip("The amount of time that the player will take to complete this waypoint")]
    public float waypointTime;

    [Tooltip("The type of movement that this waypoint will use")]
    public MovementTypes moveType;

    [Tooltip("The target for this movement")]
    public GameObject waypoint;

    public Vector3 target;

}
