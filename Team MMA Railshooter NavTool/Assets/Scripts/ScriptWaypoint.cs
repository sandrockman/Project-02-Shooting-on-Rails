using UnityEngine;
using System.Collections;

public enum MovementTypes
{
	WAIT,
	MOVE
};

[System.Serializable]
public class ScriptWaypoint{

    public float waypointTime;

    public MovementTypes moveType;

    public GameObject waypoint;

    public Vector3 target;

}
