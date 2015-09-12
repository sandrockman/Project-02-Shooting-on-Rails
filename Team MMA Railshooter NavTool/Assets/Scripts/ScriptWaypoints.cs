using UnityEngine;
using System.Collections;

/// <summary>
/// @Author Marshall Mason
/// </summary>
[System.Serializable]
public class ScriptWaypoints : MonoBehaviour
{
    public WaypointType waypointType;

    public MovementType movementType;
    public float waitTime;
    public float moveTime;
    public ScriptWaypoints nextPoint;

    public FacingType facingType;
    public Transform[] targets;
    public float[] facingTimes;
    public float[] holdTimes;
    
    public EffectTypes effectType;
    public float fadeInTime;
    public float fadeOutTime;
    public float effectDuration;

    public virtual void GetWaypointInfo()
    {
        Debug.Log("Something is wrong here. Check overrides for GetWaypointInfo()");
    }
}
