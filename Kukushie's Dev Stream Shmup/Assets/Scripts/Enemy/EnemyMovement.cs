using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 currentMovement;
    private bool moved = false;

    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.moved)
        {
            // Move this enemy.
            Vector2 newPosition = V2.FromV3(this.transform.position) + this.currentMovement;
            this.rb.MovePosition(newPosition);

            // Reset variables for next frame.
            this.currentMovement = Vector2.zero;
            this.moved = false;
        }
    }

    public void Move(Vector2 v)
    {
        this.currentMovement += v;
        this.moved = true;
    }
}
