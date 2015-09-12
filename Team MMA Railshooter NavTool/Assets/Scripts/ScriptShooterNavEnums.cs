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

public enum FacingTypes
{
    LOOKAT,
    LOOKCHAIN,
    WAIT
}

public enum EffectTypes
{
    SHAKE,
    SPLATTER,
    FADE,
    WAIT
}

public static class ScriptShooterNavEnums{

}
