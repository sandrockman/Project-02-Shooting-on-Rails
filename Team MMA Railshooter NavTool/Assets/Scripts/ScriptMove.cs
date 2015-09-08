using UnityEngine;
using System.Collections;

public class ScriptMove : ScriptWaypoint {

    public GameObject target;
    Transform lastPoint;

	// Use this for initialization
	void Start () {
        lastPoint = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = Vector3.Lerp(lastPoint.position, target.transform.position, waypointTime * Time.deltaTime);
	}
}
