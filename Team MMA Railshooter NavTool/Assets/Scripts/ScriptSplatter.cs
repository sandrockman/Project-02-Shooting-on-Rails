using UnityEngine;
using System.Collections;

public class ScriptSplatter : MonoBehaviour {

    [Tooltip("Total time the splatter will be on screen")]
    [Range(0,10)]
    public float effectTime;

    public GameObject image;

}
