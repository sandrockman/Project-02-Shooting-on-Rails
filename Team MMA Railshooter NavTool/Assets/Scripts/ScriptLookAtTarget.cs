using UnityEngine;
using System.Collections;

/// <summary>
/// Author:Andrew Seba
/// Description: Controls the transform to look at a specified target and renturn
/// </summary>
public class ScriptLookAtTarget : MonoBehaviour {

    [Tooltip("How fast the camera will rotate to the target.")]
    public float rotateSpeed = 0.5f;

    [Tooltip("Place the target object for the camera to look at.")]
    public GameObject target;

    [Tooltip("How long you will lock on target.")]
    public float lockTime = 3.0f;

    Quaternion startRotation;
    
    public void Activate()
    {
        startRotation = transform.rotation;
        Debug.Log(startRotation);
        StartCoroutine("LookAtTarget");
    }

    IEnumerator LookAtTarget()
    {
        float timeElapsed = 0.0f;
        while (timeElapsed < lockTime)
        {
            timeElapsed += Time.deltaTime;
            Quaternion neededRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime * rotateSpeed);
            yield return null;
        }
        StartCoroutine("ReturnLook");
    }

    IEnumerator ReturnLook()
    {
        StopCoroutine("LookAtTarget");
        //Debug.Log("Entered Return");
        //Debug.Log(startRotation);
        //Debug.Log(transform.rotation);
        while (transform.forward != Vector3.forward)
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, startRotation, rotateSpeed);

            yield return null;
        }
        //Debug.Log("Exited Return! congrats!!");
    }
}
