using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(ScriptMove))]
public class MovementEditorDrawer :  PropertyDrawer {

    ScriptMove moveScript;
    float extraHeight = 55f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //Required for all drawers
        EditorGUI.BeginProperty(position, label, property);

        //-------------------------------
        //Place your custom drawer stuffs here

        SerializedProperty moveTime = property.FindPropertyRelative("moveTime");

        EditorGUI.PropertyField(position, moveTime);


        //--------------------------------

        //Required for all drawers
        EditorGUI.EndProperty();
    }
}
