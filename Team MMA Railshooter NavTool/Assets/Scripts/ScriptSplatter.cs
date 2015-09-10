using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptSplatter : MonoBehaviour {

    [Tooltip("Enables Splat")]
    public bool activateSplat = false;

    [Tooltip("Total time the splatter will be on screen")]
    [Range(0,10)]
    public float effectTime = 1.0f;

    [Tooltip("Percent of effect time spent fading in.")]
    [Range(0,0.5f)]
    public float fadeInTime = 0.1f;

    [Tooltip("Percent of effect time spent fading out.")]
    [Range(0, 0.5f)]
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
    int padding = 800;
    float smoothness = 0.02f;

    void Start()
    {
        splatRenderer = splatImage.GetComponent<SpriteRenderer>();
        
        if (activateSplat)
        {
            splatRect = new Rect(Random.Range(0, Screen.width - padding), Random.Range(0, Screen.height - padding), Screen.width / 16 * imageScale, Screen.height / 9 * imageScale);
            StartCoroutine("SplatFadeIn");
            activateSplat = false;
        }

    }

    //void FadeIn()
    //{
    //    splatColor = Color.Lerp(Color.clear, splatColor, 1.5f * Time.deltaTime);
    //}

    //Draws the splat
    void OnGUI()
    {
        GUI.color = splatColor;
        GUI.DrawTexture(splatRect, splatRenderer.sprite.texture, ScaleMode.StretchToFill);
    }

    IEnumerator SplatStay()
    {
        float timePassed = 0.0f;
        

        while (timePassed <= effectTime)
        {
            timePassed += 1 * Time.deltaTime;

            if(timePassed < (effectTime - fadeOutTime))
            {
                StartCoroutine("SplatFadeOut");
            }
            yield return null;
        }
    }

    //Fades the splat
    IEnumerator SplatFadeIn()
    {
        float progress = 0;

        float increment = smoothness / fadeInTime;

        while(progress < 1)
        {
            splatColor = Color.Lerp(Color.clear, splatRenderer.color, progress);
            progress += increment;
            Debug.Log(splatColor.a + "<" + progress +">");
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
            Debug.Log(splatColor.a + "<" + progress + ">");
            yield return null;
        }
    }
}
