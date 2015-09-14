using UnityEngine;
using System.Collections;

public class FacingEngine : MonoBehaviour {
    //waypoint array to be accessed by editor.
	public FacingWaypoint[] waypoints = new FacingWaypoint[1];

	
    public CameraMovement cameraMovementScript;

    // Use this for initialization
    void Start () {
        //automatically adding and populating one element to test with
        //*
		//waypoints = new FacingWaypoint[1];
		waypoints [0] = new FacingWaypointForcedLocation ();
		FacingWaypointForcedLocation locationScript = (FacingWaypointForcedLocation)waypoints [0];
		locationScript.lookTarget = new Vector3 (10f, 10f, 10f);
		locationScript.myType = FacingTypes.FORCED_LOCATION;
		locationScript.stareTime = 2f;
		locationScript.timeToTarget = 5f;
        //*/
        //run the coroutine to read through the waypoint list
		StartCoroutine (StartEngine ());
	}

    //Coroutine to run through each waypoint
	IEnumerator StartEngine()
	{ 
		foreach(FacingWaypoint wp in waypoints)
		{
			Debug.Log ("Entering the first waypoint");
			switch(wp.myType)
			{
				case FacingTypes.FORCED_LOCATION:
					Debug.Log ("Getting into forced location!");
                    //disable free camera movement
					cameraMovementScript.enabled = false;
                    //save waypoint type
					FacingWaypointForcedLocation forcedLocationWaypoint = (FacingWaypointForcedLocation)wp;
                    //call another coroutine that handles moving the locked camera to a fixed point
					StartCoroutine(ForcedLookLocation(forcedLocationWaypoint.lookTarget, forcedLocationWaypoint.timeToTarget));
                    //wait the amount of time for the camera to move
					yield return new WaitForSeconds(forcedLocationWaypoint.timeToTarget);
					Debug.Log ("Done looking, time to stare!");
                    //hold camera angle for a variable amount of time
					yield return new WaitForSeconds(forcedLocationWaypoint.stareTime);
                    //enable free camera movement again
					cameraMovementScript.enabled = true;
					Debug.Log ("Ending the forced location!");
					break;
				case FacingTypes.FREE_MOVEMENT:
                    //save waypoint type
					FacingWaypointFreeMovement freeMovementWaypoint = (FacingWaypointFreeMovement)wp;
                    //hold on free movement type of control for a variable amount of time
                    yield return new WaitForSeconds(freeMovementWaypoint.freeTime);
					break;
				default:
					Debug.Log ("Inappropriate moving type!");
					break;
			}
		}
	}

	IEnumerator ForcedLookLocation(Vector3 lookTarget, float time)
	{
		Debug.Log ("Entering the Coroutine to look");
		//Change to be working with the CAMERAS rotation instead of the character.
		float elapsedTime = 0f;
        //hold current rotation
		Quaternion startingRot = transform.rotation;
        //hold the location to turn the camera
		Quaternion targetRotation = Quaternion.LookRotation (lookTarget - transform.position, Vector3.up);

		while(elapsedTime < time)
		{
            //adjust the camera a certain time
			transform.rotation = Quaternion.Slerp (startingRot, targetRotation, (elapsedTime/time));
            //track the amount of time
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}
}
