using UnityEngine;
using System.Collections;
using UnityEditor;

/*
 * @author Mike Dobson
 * */

[CustomPropertyDrawer(typeof(ScriptMovements))]
public class WaypointEditorDrawer : PropertyDrawer 
{
    ScriptMovements waypointScript;
    float extraHeight = 40f;
    float displaySize = 20f;
    float numDisplays = 0f;
    //int shouldSolidMove = 0;
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.indentLevel++;
        EditorGUI.BeginProperty(position, label, property);
        SerializedProperty movementTypes = property.FindPropertyRelative("moveType");
        numDisplays = 0;
        
        //movmementType display block
        //EditorGUILayout.PropertyField(movementTypes);
        Rect movementTypesDisplay = new Rect(position.x, position.y + displaySize * numDisplays, position.width, 15f);
        EditorGUI.PropertyField(movementTypesDisplay, movementTypes);
        numDisplays += 1;
        
        //waypointTime display block
        SerializedProperty waypointTime = property.FindPropertyRelative("waypointTime");
        Rect waypointTimeDisplay = new Rect(position.x, position.y + displaySize , position.width, 15f);
        EditorGUI.PropertyField(waypointTimeDisplay, waypointTime);
        numDisplays += 1;

        //target display block
        SerializedProperty waypoint = property.FindPropertyRelative("waypoint");
        Rect targetDisplay = new Rect(position.x, position.y + displaySize * numDisplays, position.width, 15f);
        EditorGUI.PropertyField(targetDisplay, waypoint);


        EditorGUI.EndProperty();
        EditorGUI.indentLevel--;
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + (extraHeight );
    }


}
