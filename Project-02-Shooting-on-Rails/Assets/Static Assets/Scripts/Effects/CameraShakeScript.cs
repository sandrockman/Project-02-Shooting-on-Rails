using UnityEngine;
using System.Collections;

public class CameraShakeScript : MonoBehaviour 
{
    [Tooltip("Amount of time the camera shakes for.")]
    public float shakeTime = 0.2f;
    [Tooltip("How hard the camera shakes.")]
    public float shakeIntensity = 2f;

    Rect buttonPos = new Rect(Screen.width / 2, Screen.height / 2 - 50, 100, 30);

    void OnGUI()
    {
        // 
        if (GUI.Button(buttonPos, "Shake screen"))
            StartCoroutine("CameraShake");
            
    }

    /**
     * @authors Darrick Hilburn,
     *          Insomnix (http://unitytipsandtricks.blogspot.com/2013/05/camera-shake.html)
     * 
     * CameraShake makes the main camera shake.
     * 
     * @post: changes the camera position by shaking it back and forth relative to 
     *           the camera's position.
     */
    IEnumerator CameraShake()
    {
        float elapsed = 0.0f;
        // Store position camera started at
        Vector3 camStartPos = Camera.main.transform.position; 

        while (elapsed < shakeTime)
        {
            elapsed += Time.deltaTime;

            float timePercent = elapsed / shakeTime;
            // Create a shake resistance based on the fraction of elapsed to total time.
            float shakeResistance = Mathf.Clamp(timePercent, 0.0f, 0.25f);

            // Generate random x,y, and z values to shake the camera by.
            float x = Random.value * 2 - 1;
            float y = Random.value * 2 - 1;
            float z = Random.value * 2 - 1;
            x *= shakeIntensity * shakeResistance + shakeIntensity;
            y *= shakeIntensity * shakeResistance + shakeIntensity;
            z *= shakeIntensity * shakeResistance + shakeIntensity;

            /**
             * Randomly shake the camera about relative to the current camera position.
             * Shaking is based on boolean logic by adding/subtracting to the current position.
             * 8 possible moves available
             */
            switch ((int)System.Math.Ceiling((decimal)(Random.value * 8)))
            {
                case (1): // 0 0 0, add all to current position
                    Camera.main.transform.position += new Vector3(x, y, z);
                    break;
                case (2): // 0 0 1, add x,y; subtract z
                    Camera.main.transform.position += new Vector3(x, y, -z);
                    break;
                case (3): // 0 1 0, add x,z; subtract y
                    Camera.main.transform.position += new Vector3(x, -y, z);
                    break;
                case (4): // 0 1 1, add x; subtract y,z
                    Camera.main.transform.position += new Vector3(x, -y, -z);
                    break;
                case (5): // 1 0 0, add y,z; subtract x
                    Camera.main.transform.position += new Vector3(-x, y, z);
                    break;
                case (6): // 1 0 1, add y; subtract x,z
                    Camera.main.transform.position += new Vector3(-x, y, -z);
                    break;
                case (7): // 1 1 0, add z; subtract x,y
                    Camera.main.transform.position += new Vector3(-x, -y, z);
                    break;
                case (8): // 1 1 1, subtract all from current position
                    Camera.main.transform.position += new Vector3(-x, -y, -z);
                    break;
                default: // ? ? ?, called for impossible moves; does nothing.
                    break;
            }
            yield return null;
        }
        // Return camera to initial position
        Camera.main.transform.position = camStartPos;
    }		
}
