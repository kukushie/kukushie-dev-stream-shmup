using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class V3
{
    public static Vector3 Add(Vector3 v1, Vector2 v2)
    {
        return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z);
    }
}
