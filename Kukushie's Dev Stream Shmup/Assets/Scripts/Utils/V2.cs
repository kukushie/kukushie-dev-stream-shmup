using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class V2
{
    public static Vector2 FromMagnitudeAngle(float magnitude, float angle)
    {
        return new Vector2(magnitude * Mathf.Cos(angle), magnitude * Mathf.Sin(angle));
    }

    public static Vector2 FromV3(Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }

    public static float Angle(Vector2 v)
    {
        return Mathf.Atan2(v.y, v.x);
    }

    public static float AngleTo(Vector2 from, Vector2 to)
    {
        return Mathf.Atan2(to.y - from.y, to.x - from.x);
    }
}
