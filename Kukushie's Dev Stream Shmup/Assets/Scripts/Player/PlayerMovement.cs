using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const string BLEND_PARAM_HORIZONTAL_VELOCITY = "Horizontal Velocity";

    public float speed = 10f;
    public float width;
    public float height;
    public PlayerGun gun;
    public Animator bodyAnimator;

    private PlayerInput input;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        this.input = new PlayerInput();
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.input.UpdateInputsForNextFrame();
    }

    void FixedUpdate()
    {
        // Do movement.
        if (this.input.IsMoving())
        {
            float magnitude = this.speed * Time.deltaTime;
            float angle = this.input.GetMovementDirection();
            Vector2 movement = V2.FromMagnitudeAngle(magnitude, angle);
            Vector2 newPosition = V2.FromV3(this.transform.position) + movement;

            // Prevent player from moving beyond the edges of the screen.
            float halfWidth = this.width * 0.5f;
            float halfHeight = this.height * 0.5f;
            newPosition.x = Mathf.Clamp(newPosition.x, halfWidth, Stage.instance.width - halfWidth);
            newPosition.y = Mathf.Clamp(newPosition.y, halfHeight, Stage.instance.height - halfHeight);

            this.rb.MovePosition(newPosition);
            this.bodyAnimator.SetFloat(BLEND_PARAM_HORIZONTAL_VELOCITY, movement.x);
        } else {
            this.bodyAnimator.SetFloat(BLEND_PARAM_HORIZONTAL_VELOCITY, 0f);
        }

        // Do firing.
        if (this.input.IsFiring())
        {
            this.gun.Fire();
        }
    }
}
