using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP;

    private int currentHP;

    void Start()
    {
        this.currentHP = this.maxHP;
    }

    void OnCollisionEnter2D(Collision2D collision2d)
    {
        PlayerShot playerShot = collision2d.rigidbody.GetComponent<PlayerShot>();
        if (playerShot)
        {
            playerShot.HandleCollisionWithEnemy(this);
            this.SustainDamage(playerShot.damage);
        }
    }

    private void SustainDamage(int damage)
    {
        this.currentHP -= damage;
        if (this.currentHP <= 0)
        {
            this.Explode();
        }
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
