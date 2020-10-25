using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static Color SetAlpha(Color color, float a)
    {
        return new Color(color.r, color.g, color.b, a);
    }
}
