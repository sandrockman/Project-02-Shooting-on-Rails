using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// @Author Marshall Mason
/// </summary>
[CustomEditor(typeof(ScriptNavigation))]
public class ScriptNavigationEditor : Editor
{
    ScriptNavigation navScript;
    
    void Awake()
    {
        navScript = (ScriptNavigation)target;
    }

    public override void OnInspectorGUI()
    {
        
    }
}
