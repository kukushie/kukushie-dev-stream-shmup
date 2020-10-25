using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public int damage;
    public float speed;
    public float angle;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float magnitude = this.speed * Time.deltaTime;
        Vector2 movement = V2.FromMagnitudeAngle(magnitude, this.angle);
        this.rb.MovePosition(V2.FromV3(this.transform.position) + movement);
    }

    public void HandleCollisionWithEnemy(Enemy enemy)
    {
        Explode();
    }

    private void Explode()
    {
        // Disable colliders so we can't participate in any more collisions.
        foreach (Collider2D c2d in GetComponentsInChildren<Collider2D>())
        {
            c2d.enabled = false;
        }

        // Temporary: just destroy game object.
        // In future: show exploding animation and play sound.
        Destroy(this.gameObject);
    }
}
