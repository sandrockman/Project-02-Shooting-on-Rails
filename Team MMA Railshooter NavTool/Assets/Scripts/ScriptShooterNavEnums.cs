using UnityEngine;
using System.Collections;

/// <summary>
/// @Author Marshall Mason
/// </summary>
public enum WaypointType
{
    Movement,
    Facing,
    Effect
}

//@Mike
public enum MovementTypes
{
    WAIT,
    MOVE,
    BEZIER
};

public enum FacingType
{
    LookAndReturn,
    LookChain,
    Wait
}

public enum EffectType
{
    Shake,
    Splatter,
    FadeInOut,
    Wait
}

public static class ScriptShooterNavEnums{

}
