using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Author: Andew Seba
/// Desceiprion: Displays a designer specified sprite object on the screen
///     for a specified amount of time.
/// </summary>
public class ScriptSplatter : MonoBehaviour {

    [Tooltip("Enables Splat")]
    public bool enable = false;

    [Tooltip("Total time the splatter will be on screen")]
    [Range(0,10)]
    public float effectTime = 1.0f;

    [Tooltip("Time of effect time spent fading in.")]
    [Range(0, 3f)]
    public float fadeInTime = 0.1f;

    [Tooltip("Time of effect time spent fading out.")]
    [Range(0, 3f)]
    public float fadeOutTime = 0.1f;

    [Tooltip("Place your splat sprite or texture here.")]
    public GameObject splatImage;

    [Tooltip("Designed for 16:9 aspect ratio")]
    [Range(0,10)]
    public float imageScale = 4;


    SpriteRenderer splatRenderer;
    Rect splatRect;
    Color splatColor;
    float elapsedTime = 0.0f;
    float smoothness = 0.02f;

    public void Awake()
    {
        splatRenderer = splatImage.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        
        if (enable)
        {
            splatRect = new Rect(Random.Range(0, Screen.width /2), Random.Range(0, Screen.height /2), Screen.width / 16 * imageScale, Screen.height / 9 * imageScale);
            StartCoroutine("SplatFadeIn");
            enable = false;
        }

    }

    //Draws the splat
    void OnGUI()
    {
        GUI.color = splatColor;
        GUI.DrawTexture(splatRect, splatRenderer.sprite.texture, ScaleMode.StretchToFill);
    }

    IEnumerator SplatStay()
    {
        float timePassed = 0.0f;
        

        while (timePassed <= effectTime - fadeOutTime)
        {
            timePassed += 1 * Time.deltaTime;
            yield return null;
        }
        StartCoroutine("SplatFadeOut");
    }

    //Fades the splat
    IEnumerator SplatFadeIn()
    {
        float progress = 0;

        float increment = smoothness / fadeInTime;

        while(progress <= 1)
        {
            splatColor = Color.Lerp(Color.clear, splatRenderer.color, progress);
            progress += increment;
            yield return null;
        }

        StartCoroutine("SplatStay");
    }

    IEnumerator SplatFadeOut()
    {
        float progress = 0;

        float increment = smoothness / fadeOutTime;

        while (progress < 1)
        {
            splatColor = Color.Lerp(splatRenderer.color, Color.clear, progress);
            progress += increment;
            yield return null;
        }
        splatColor = Color.clear;
    }
}
