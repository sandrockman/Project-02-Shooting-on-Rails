using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(FacingEngine))]
public class FacingEngineEditor : Editor {

    FacingEngine engineScript;

    void Awake()
    {
        //locate the used FacingEngine script
        engineScript = (FacingEngine)target;
    }

    public override void OnInspectorGUI()
    {
        //shows the variables being used
        DrawDefaultInspector();
        //add a space
        EditorGUILayout.Space();
        //update the inspector to show changes to inspector information
        serializedObject.Update();
        //find and hold the waypoint array for use next
        SerializedProperty engine = serializedObject.FindProperty("waypoints");
        //show the property
        EditorGUILayout.PropertyField(engine);
        //while array is expanded for view
        if(engine.isExpanded)
        {
            //show array size to be edited
            EditorGUILayout.PropertyField(engine.FindPropertyRelative("Array.size"));
            //move over information one level
            EditorGUI.indentLevel++;
            //for each element in array
            for(int i = 0; i < engine.arraySize; i++)
            {
                //show the element.
                EditorGUILayout.PropertyField(engine.GetArrayElementAtIndex(i));
            }
            //end indent
            EditorGUI.indentLevel--;
        }
        //apply changes and show to user.
        serializedObject.ApplyModifiedProperties();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
