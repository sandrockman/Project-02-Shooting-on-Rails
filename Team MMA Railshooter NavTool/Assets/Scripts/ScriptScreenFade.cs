using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptScreenFade : MonoBehaviour {


    public bool fadeIn = false;

    public float fadeSpeed = 1.5f;

    GameObject blackImage;

    

    void Awake()
    {
        if(GameObject.Find("Canvas/Image") != false)
        {
            blackImage = GameObject.Find("Canvas/Image");
        }
        else
        {
            Debug.Log("No Canvas Added. Please add Canvas prefab from the Prefab Folder.");
        }
    }

    //rename to activate
    void Update()
    {
        if (fadeIn)
        {
            StartCoroutine("FadeIn");
            fadeIn = false;
        }
    }

    IEnumerator FadeIn()
    {
        while(blackImage.GetComponent<Image>().color.a <= 1)
        {
            blackImage.GetComponent<Image>().color = Color.Lerp(blackImage.GetComponent<Image>().color, Color.clear, fadeSpeed);
            yield return null;
        }
    }
}
