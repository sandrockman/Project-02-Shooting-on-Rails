using UnityEngine;
using System.Collections;

public class CameraFadeScript : MonoBehaviour 
{
    [Tooltip("Time it takes to fade the scene in and out.")]
    public float fadeSpeed = 1.5f;

    GUIStyle backgroundStyle = new GUIStyle();
    Texture2D fadeTexture;
    Color currentScreenColor;
    Color targetScreenColor;
    Color deltaColor;
    int fadeDepth = -1000;

    Rect buttonPos = new Rect(Screen.width / 2, Screen.height / 2, 100, 30);
    Rect texturePos = new Rect(-10, -10, Screen.width + 10, Screen.height + 10);

    // Initialize texture, background style and initial color
    void Awake()
    {
        fadeTexture = new Texture2D(1, 1);
        backgroundStyle.normal.background = fadeTexture;
        SetScreenColor(Color.clear);
    }

    void OnGUI()
    {
        if (currentScreenColor != targetScreenColor)
        {
            if (Mathf.Abs(currentScreenColor.a - targetScreenColor.a) < Mathf.Abs(deltaColor.a) * Time.deltaTime)
            {
                currentScreenColor = targetScreenColor;
                SetScreenColor(currentScreenColor);
                deltaColor = Color.clear;
            }
            else 
                SetScreenColor(currentScreenColor + deltaColor * Time.deltaTime);
        }
        // Draw texture when alpha value is greater than 0
        if (currentScreenColor.a > 0)
        {
            GUI.depth = fadeDepth;
            GUI.Label(texturePos, fadeTexture, backgroundStyle);
        }

        /// REMOVABLE
        // Button for testing fade
        if(GUI.Button(buttonPos, "Fade Screen"))
        {
            if (currentScreenColor.a == 0)
                {
                    StartFade(Color.black, fadeSpeed);

                }
                else
                {
                    StartFade(Color.clear, fadeSpeed);
                }
        }
    }

    /**
     * @author Kentyman (http://wiki.unity3d.com/index.php?title=FadeInOut#Another_Fade_Script_in_C.23)
     *         
     * SetScreenOverlayColor sets the color that the screen will fade to.
     * 
     * For this project, we will typically only work with clear and black, but
     * it is written to work for fading to any color.
     * 
     * @param newScreenColor: Color the screen will fade to.
     * @post: The currentScreenColor will be set to the newScreenColor
     */
    public void SetScreenColor(Color newScreenColor)
    {
        currentScreenColor = newScreenColor;
        fadeTexture.SetPixel(0, 0, currentScreenColor);
        fadeTexture.Apply();
    }

    /**
     * @author Kentyman (http://wiki.unity3d.com/index.php?title=FadeInOut#Another_Fade_Script_in_C.23)
     * 
     * StartFade actually fades the screen color.
     * 
     * @param newScreenColor: Color to fade the screen to
     * @param duration: how long the screen will fade for
     * 
     * @post: Screen will be faded to newScreenColor.
     */
    public void StartFade(Color newScreenColor, float duration)
    {
        if (duration <= 0) 
            SetScreenColor(newScreenColor);
        else
        {
            targetScreenColor = newScreenColor;
            deltaColor = (targetScreenColor - currentScreenColor) / duration;
        }
    }
}
