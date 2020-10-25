using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys this game object when it goes out of bounds.
public class DestroyOutOfBounds : MonoBehaviour
{
    // The radius (size) of this object. It won't be destroyed until the entire object is out of bounds.
    public float radius;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if we're out of bounds.
        if (Stage.IsObjectOutOfBounds(this.transform.position, this.radius))
        {
            Destroy(this.gameObject);
        }
    }
}
