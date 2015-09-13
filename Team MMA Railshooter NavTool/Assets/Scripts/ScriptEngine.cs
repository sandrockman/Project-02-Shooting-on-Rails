using UnityEngine;
using System.Collections;

/*
 * @author Mike Dobson
 * */

public class ScriptEngine : MonoBehaviour {

	public ScriptMovements[] movements;

	// Use this for initialization
	void Start () 
	{
        //Starts the Engine Coroutine
        StartCoroutine(MovementEngine());
	}

	IEnumerator MovementEngine()
	{
		foreach(ScriptMovements move in movements)
		{
			Debug.Log(move.moveType);
			switch(move.moveType)
			{
				case MovementTypes.MOVE:
                    if (move.endWaypoint != null && move.movementTime > 0)
                    {
                        //Do the movement coroutine with the help of the movement script
                        StartCoroutine(movementMove(move.endWaypoint.transform.position, move.movementTime));

                        //Wait for the specified amount of time on the movement waypoint
                        yield return new WaitForSeconds(move.movementTime);
                    }
                    else
                    {
                        Debug.Log("Movement was skipped due to missing element");
                    }
					break;
				case MovementTypes.WAIT:
                    if (move.movementTime > 0)
                    {
                        //Does the wait
                        StartCoroutine(movementWait(move.movementTime));

                        //Waits for the specified amount of time
                        yield return new WaitForSeconds(move.movementTime);
                    }
                    else
                    {
                        Debug.Log("Wait was skipped due to missing element");
                    }
					break;
                case MovementTypes.BEZIER:
                    if (move.endWaypoint != null && move.curveWaypoint != null && move.movementTime > 0)
                    {
                        StartCoroutine(movementBezier(move.endWaypoint.transform.position, move.curveWaypoint.transform.position, move.movementTime));

                        //Waits for the specified amount of time to continue
                        yield return new WaitForSeconds(move.movementTime);
                    }
                    else
                    {
                        Debug.Log("Movement was skipped due to missing element");
                    }
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

    IEnumerator movementBezier(Vector3 target, Vector3 curve, float time)
    {
        //Get the current time
        float startTime = Time.time;
        //find the time for the end of the movement
        float endTime = startTime + time;

        //get the start of the curve
        Vector3 startCurve = transform.position;
        //elapsed time 
        float elapsedTime = 0f;

        //While time is lest than the end time
        while(Time.time < endTime )
        {
            
            //track the current elapsed time after each frame
            elapsedTime += Time.deltaTime;
            float curTime = elapsedTime / time;

            //move along the curve
            transform.position = GetPoint(startCurve, target, curve, curTime);
            yield return null;
        }

        //Snap the player to the target position at the end of the curve
        transform.position = target;
        
    }

    public Vector3 GetPoint(Vector3 start, Vector3 end, Vector3 curve, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * start + 2f * oneMinusT * t * curve + t * t * end;
    }

    void OnDrawGizmos()
    {
        Vector3 lineStarting = transform.position;
        foreach(ScriptMovements move in movements)
        {
            switch(move.moveType)
            {
                case MovementTypes.MOVE:
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(lineStarting, move.endWaypoint.transform.position);
                    lineStarting = move.endWaypoint.transform.position;
                    break;
                case MovementTypes.WAIT:
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawWireSphere(lineStarting, 1f);
                    break;
                case MovementTypes.BEZIER:
                    Gizmos.color = Color.green;
                    Vector3 bezierStart = lineStarting;
                    for(int i = 1; i <= 10; i++)
                    {
                        Vector3 lineEnd = GetPoint(bezierStart, move.endWaypoint.transform.position, move.curveWaypoint.transform.position, i / 10f);
                        Gizmos.DrawLine(lineStarting, lineEnd);
                        lineStarting = lineEnd;
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
