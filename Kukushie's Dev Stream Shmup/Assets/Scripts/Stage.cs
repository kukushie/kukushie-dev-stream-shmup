using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton class representing a stage where gameplay happens.
public class Stage : MonoBehaviour
{
    public static Stage instance = null;

    // Returns true if an object at a position with a radius is completely out of bounds (i.e. off-screen).
    // Assumes (0, 0) is the lower-left corner of the visible area.
    public static bool IsObjectOutOfBounds(Vector3 position, float radius)
    {
        return (position.y < -radius) || (position.x < -radius) || (position.y > instance.height + radius) || (position.x > instance.width + radius);
    }

    // Stage dimensions.
    public readonly float width = 1280;
    public readonly float height = 720;

    void Awake()
    {
        Stage.instance = this;
        Application.targetFrameRate = 60;
    }
}
