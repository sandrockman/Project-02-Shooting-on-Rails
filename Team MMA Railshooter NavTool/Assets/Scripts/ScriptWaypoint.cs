using UnityEngine;
using System.Collections;

public class ScriptWaypoint  {

    public enum movementTypes
    {
        WAIT,
        MOVE,
    };

    public int moveType;
    public float waypointTime;

    public static  int numWaypoints;
    public GameObject[] targetWaypoints = new GameObject[numWaypoints];

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
	    foreach(GameObject wp in targetWaypoints)
        {

        }
	}
}
