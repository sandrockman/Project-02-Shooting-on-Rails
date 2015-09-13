using UnityEngine;
using System.Collections;

public class FacingClass : MonoBehaviour {

	public float Xstart = 0;
	public float Ystart = 0;
	public float Zstart = 0;

	public float XEnd = 0;
	public float YEnd = 0;
	public float ZEnd = 0;

	Quaternion newRotation;


	public float timeFacing = 2f;


	// Use this for initialization
	void Start () {
		newRotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
