using UnityEngine;
using System.Collections;

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
    LookChain
}

public enum EffectType
{
    Shake,
    Splatter,
    FadeInOut
}

public static class ScriptShooterNavEnums{

}
