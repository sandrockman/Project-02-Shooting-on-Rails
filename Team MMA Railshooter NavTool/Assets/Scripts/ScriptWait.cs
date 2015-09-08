using UnityEngine;
using System.Collections;

public class ScriptWait : ScriptWaypoint {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        waypointTime -= Time.deltaTime;

        if(waypointTime <= 0.0f)
        {
            //next movement
        }
	}
}
