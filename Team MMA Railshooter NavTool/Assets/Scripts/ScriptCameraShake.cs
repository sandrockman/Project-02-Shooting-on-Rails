using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Tool to make the camera shake for a specified amount of time
///     and intensity.
///     Call Activate to start the effect.
/// </summary>
public class ScriptCameraShake : MonoBehaviour {

    [Tooltip("The strength of the shake.")]
    [Range(0,3)]
    public float magnitude = 1;

    [Tooltip("How long it will shake in seconds.")]
    [Range(0, 10)]
    public float shakeTime = 2.0f;

    float shake = 0f;

    Vector3 originalPosition;

    public bool enable = false;


    //change to 'public void Activate()' when wanting to implement.
    public void Activate()
    {
        originalPosition = transform.position;
        shake = shakeTime;
        StartCoroutine("ShakeIt");
    }

    IEnumerator ShakeIt()
    {
        while (shake > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * magnitude;

            shake -= Time.deltaTime * 1;
            yield return null;
        }

        shake = 0;
        transform.localPosition = originalPosition;
    }

}
