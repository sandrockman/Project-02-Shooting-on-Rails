using UnityEngine;
using System.Collections;

public class FacingEngine : MonoBehaviour {

	public FacingWaypoint[] waypoints;
	public CameraMovement cameraMovementScript;

	// Use this for initialization
	void Start () {

		waypoints = new FacingWaypoint[1];
		waypoints [0] = new FacingWaypointForcedLocation ();
		FacingWaypointForcedLocation locationScript = (FacingWaypointForcedLocation)waypoints [0];
		locationScript.lookTarget = new Vector3 (10f, 10f, 10f);
		locationScript.myType = FacingTypes.FORCED_LOCATION;
		locationScript.stareTime = 2f;
		locationScript.timeToTarget = 5f;

		StartCoroutine (StartEngine ());
	}

	IEnumerator StartEngine()
	{
		foreach(FacingWaypoint wp in waypoints)
		{
			Debug.Log ("Entering the first waypoint");
			switch(wp.myType)
			{
				case FacingTypes.FORCED_LOCATION:
					Debug.Log ("Getting into forced location!");
					cameraMovementScript.enabled = false;
					FacingWaypointForcedLocation forcedLocationWaypoint = (FacingWaypointForcedLocation)wp;
					StartCoroutine(ForcedLookLocation(forcedLocationWaypoint.lookTarget, forcedLocationWaypoint.timeToTarget));
					yield return new WaitForSeconds(forcedLocationWaypoint.timeToTarget);
					Debug.Log ("Done looking, time to stare!");
					yield return new WaitForSeconds(forcedLocationWaypoint.stareTime);
					cameraMovementScript.enabled = true;
					Debug.Log ("Ending the forced location!");
					break;
				case FacingTypes.FREE_MOVEMENT:
					FacingWaypointFreeMovement freeMovementWaypoint = (FacingWaypointFreeMovement)wp;
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
		//Change to be working with the CAMERAS rotation instead of the characters
		float elapsedTime = 0f;
		Quaternion startingRot = transform.rotation;
		Quaternion targetRotation = Quaternion.LookRotation (lookTarget - transform.position, Vector3.up);

		while(elapsedTime < time)
		{
			transform.rotation = Quaternion.Slerp (startingRot, targetRotation, (elapsedTime/time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
	}
}
