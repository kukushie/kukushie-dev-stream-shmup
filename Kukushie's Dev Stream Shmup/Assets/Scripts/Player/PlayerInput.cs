using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player movement.
// In the future, this class will be able to accept inputs from a replay file.
public class PlayerInput
{
    private PlayerInputFrame currentInputs;

    // Called once per Update. Updates the inputs for the next frame, e.g. from the player or from a replay file.
    public void UpdateInputsForNextFrame()
    {
        // Get the current inputs.
        float horizontalAxis = Input.GetAxis("Horizontal");
        this.currentInputs.left = (horizontalAxis < 0);
        this.currentInputs.right = (horizontalAxis > 0);
        float verticalAxis = Input.GetAxis("Vertical");
        this.currentInputs.down = (verticalAxis < 0);
        this.currentInputs.up = (verticalAxis > 0);
        this.currentInputs.fire = Input.GetButton("Fire1");
    }

    // Returns the angle (in radians) of the current direction being pressed.
    // 0 means along the positive x-axis (i.e. to the right).
    // Returns a value between -PI and +PI.
    public float GetMovementDirection()
    {
        if (this.currentInputs.right)
        {
            if (this.currentInputs.up)
            {
                return Mathf.PI / 4f;
            }
            if (this.currentInputs.down)
            {
                return -Mathf.PI / 4f;
            }
            return 0f;
        }
        if (this.currentInputs.left)
        {
            if (this.currentInputs.up)
            {
                return 3f * Mathf.PI / 4f;
            }
            if (this.currentInputs.down)
            {
                return -3f * Mathf.PI / 4f;
            }
            return Mathf.PI;
        }
        if (this.currentInputs.up)
        {
            return Mathf.PI / 2f;
        }
        if (this.currentInputs.down)
        {
            return -Mathf.PI / 2f;
        }
        return 0f;
    }

    // Returns true if any direction is pressed.
    public bool IsMoving()
    {
        return this.currentInputs.up || this.currentInputs.down || this.currentInputs.left || this.currentInputs.right;
    }

    public bool IsFiring()
    {
        return this.currentInputs.fire;
    }
}
