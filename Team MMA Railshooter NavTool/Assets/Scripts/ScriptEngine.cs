using UnityEngine;
using System.Collections;

public class ScriptEngine : MonoBehaviour {

	public ScriptWaypoint[] waypoints;

	// Use this for initialization
	void Start () 
	{

        //waypoints [0] = new ScriptWaypoint ();
        //waypoints [1] = new ScriptWaypoint();
        //waypoints [2] = new ScriptWaypoint();

        ////ScriptMove moveWaypoint = (ScriptMove)waypoints [0];
        //waypoints[0].moveType = MovementTypes.MOVE;
        //waypoints[0].waypointTime = 5f;
        //waypoints[0].target = new Vector3 (17f, 0f, 0f);
        ////waypoints[0] = moveWaypoint;

        ////ScriptWait waitWaypoint = (ScriptWait)waypoints[1];
        //waypoints[1].moveType = MovementTypes.WAIT;
        //waypoints[1].waypointTime = 2f;
        //waypoints[1].target = new Vector3(17f, 0f, 0f);
        ////waypoints[1] = waitWaypoint;

        ////ScriptMove moveWaypointNew = (ScriptMove)waypoints[2];
        //waypoints[2].moveType = MovementTypes.MOVE;
        //waypoints[2].waypointTime = 5f;
        //waypoints[2].target = new Vector3(0f, 0f, 0f);
        ////waypoints[2] = moveWaypointNew;

        StartCoroutine(MovementEngine());
	}

	IEnumerator MovementEngine()
	{
		foreach(ScriptWaypoint wp in waypoints)
		{
			Debug.Log(wp.moveType);
			switch(wp.moveType)
			{
				case MovementTypes.MOVE:
					//Grab the movement script off the waypoint
					//ScriptMove movementScript = (ScriptMove)wp;

                    wp.target = wp.waypoint.transform.position;

					//Do the movement coroutine with the help of the movement script
					StartCoroutine(movementMove (wp.target, wp.waypointTime));
					
					//Wait for the specified amount of time on the movement waypoint
					yield return new WaitForSeconds(wp.waypointTime);
					break;
				case MovementTypes.WAIT:
					//Grabs the wait script off the waypoint
					//ScriptWait waitScript = (ScriptWait)wp;
					
					//Does the wait
					StartCoroutine(movementWait(wp.waypointTime));
					
					//Waits for the specified amount of time
					yield return new WaitForSeconds(wp.waypointTime);
					break;
				default:
					Debug.Log ("Invalid movement type!");
					break;
					
			}
		}
	}

	IEnumerator movementMove(Vector3 target, float time)
	{
		//Tracking the elapsed time
		float elapsedTime = 0;

		//Store the starting position of the object
		Vector3 startPos = transform.position;

		//Continue while we are still below required time
		while(elapsedTime < time)
		{
			//start position, end position, time
			transform.position = Vector3.Lerp(startPos,
			                                  target,
			                                  (elapsedTime/time));
			elapsedTime += Time.deltaTime;

			//Wait to be called again by the game loop
			yield return null;
		}

		//Snap the player to target position at end of lerp
		transform.position = target;
	}

	IEnumerator movementWait(float time)
	{
		Debug.Log ("starting wait");
		yield return new WaitForSeconds (time);
		Debug.Log ("next waypoint");
	}
}
