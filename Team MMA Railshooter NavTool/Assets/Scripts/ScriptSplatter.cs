using UnityEngine;
using System.Collections;

public class ScriptSplatter : MonoBehaviour {

    [Tooltip("Total time the splatter will be on screen")]
    [Range(0,10)]
    public float effectTime = 1.0f;

    public Texture splatImage;

    Rect splatRect;
    Color color;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Splat();
        }
    }

    public void Splat()
    {
        splatRect = new Rect(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 60, 60);
        StartCoroutine("SplatFade");
    }

    void OnGUI()
    {
        GUI.color = color;
        GUI.DrawTexture(splatRect, splatImage, ScaleMode.StretchToFill);
    }


    IEnumerator SplatFade()
    {
        float elapsedTime = 0.0f;

        while(elapsedTime < effectTime)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1,0, elapsedTime/effectTime);
            Debug.Log(color.a);

            yield return null;
        }
    }
}
