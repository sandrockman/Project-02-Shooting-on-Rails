using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(FacingWaypoint))]
public class FacingWaypointEditor : PropertyDrawer {

    FacingWaypoint thisPoint;

    float extraHeight = 50F;
    //*
    //modify the element's information for changing a waypoint
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //new rectangle for use showing information
        Rect objectDisplay = new Rect(position.x, position.y, position.width, 15f);
        //start the new property show
        EditorGUI.BeginProperty(position, label, property);
        //enum to show type of waypoint
        SerializedProperty wpType = property.FindPropertyRelative("myType");
        //placeholders for fixed location serialized variables
        SerializedProperty fixLocationTarget;
        SerializedProperty timeToTargetFix;
        SerializedProperty stareTimeFix;
        //placeholders for free movement serialized variables
        SerializedProperty panSpeedH;
        SerializedProperty panSpeedV;
        SerializedProperty freeTime;

        switch((FacingTypes)wpType.enumValueIndex)
        {
            case FacingTypes.FORCED_LOCATION:
                //assign forced location variables
                fixLocationTarget = property.FindPropertyRelative("lookTarget");
                timeToTargetFix = property.FindPropertyRelative("timeToTarget");
                stareTimeFix = property.FindPropertyRelative("stareTime");
                //show forced location variables
                EditorGUI.PropertyField(objectDisplay, fixLocationTarget, GUIContent.none);
                EditorGUI.PropertyField(objectDisplay, timeToTargetFix, GUIContent.none);
                EditorGUI.PropertyField(objectDisplay, stareTimeFix, GUIContent.none);
                break;
            case FacingTypes.FREE_MOVEMENT:
                //assign free movement variables
                panSpeedH = property.FindPropertyRelative("panSpeedH");
                panSpeedV = property.FindPropertyRelative("panSpeedV");
                freeTime = property.FindPropertyRelative("freeTime");
                //show free movement variables
                EditorGUI.PropertyField(objectDisplay, panSpeedH, GUIContent.none);
                EditorGUI.PropertyField(objectDisplay, panSpeedV, GUIContent.none);
                EditorGUI.PropertyField(objectDisplay, freeTime, GUIContent.none);
                break;
            default:
                Debug.Log("Invalid waypoint type!");
			break;
        }

        //show the enum with the new rect found earlier
        EditorGUI.PropertyField(objectDisplay, wpType, GUIContent.none);
        //end current property
        EditorGUI.EndProperty();
    }
    //*/
    //modify the height of the rect in the previous function
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        //return new height
        return base.GetPropertyHeight(property, label) + extraHeight;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
