using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ScriptEngine))]
public class EngineEditor :  Editor
{
	
	ScriptEngine engineScript;

	void Awake()
	{
		//engineScript = (ScriptEngine)engineScript;
	}

	public override void OnInspectorGUI()
	{
		//required things for arrays
		serializedObject.Update ();

		//-------------------------------
		//Place your custom editor stuffs
		//serializedObject.waypoints
		SerializedProperty waypointsArray = serializedObject.FindProperty ("waypoints");

        EditorGUILayout.PropertyField(waypointsArray);

        
        if (waypointsArray.isExpanded)
        {
            //EditorGUILayout.PropertyField(waypointsArray.arraySize)
            EditorGUILayout.PropertyField(waypointsArray.FindPropertyRelative("Array.size"));
            EditorGUI.indentLevel++;
            for (int i = 0; i < waypointsArray.arraySize; i++)
            {
                EditorGUILayout.PropertyField(waypointsArray.GetArrayElementAtIndex(i));
            }
            EditorGUI.indentLevel--;
        }
        //--------------------------------


        //required things for arrays
        serializedObject.ApplyModifiedProperties();
	}
}
