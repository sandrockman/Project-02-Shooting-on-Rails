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

public enum MovementType
{
    Wait,
    LookAndReturn,
    LookChain,
    StraightLine
}

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
