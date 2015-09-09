using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Andrew Seba
/// Description: Tool to make the camera shake for a specified amount of time
///     and intensity.
/// </summary>
public class ScriptCameraShake : MonoBehaviour {

    [Tooltip("The strength of the shake.")]
    [Range(0,3)]
    public float magnitude = 1;

    [Tooltip("How long it will shake in seconds.")]
    [Range(0, 10)]
    public float shakeTime = 2.0f;

    float shake = 0f;

    Vector3 originalPosition = Vector3.zero;

    public bool testOn = false;

    void Update()
    {

        if(shake > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * magnitude;

            shake -= Time.deltaTime * 1;
        }
        else
        {
            shake = 0;
            transform.localPosition = originalPosition;
        }

        if (testOn && Input.GetButton("Jump"))
        {
            ApplyShake(shakeTime);
        }
    }

    /// <summary>
    /// Start's shaking for specified amount of time.
    /// </summary>
    /// <param name="pShakeLength"></param>
    public void ApplyShake(float pShakeLength)
    {
        shake = pShakeLength;
    }

    /// <summary>
    /// Start's shaking for specified amount of time and sets magnitude.
    /// </summary>
    /// <param name="pShakeLength"></param>
    /// <param name="pMagnitude"></param>
    public void ApplyShake(float pShakeLength, float pMagnitude)
    {
        shake = pShakeLength;
        magnitude = pMagnitude;
    }

}
