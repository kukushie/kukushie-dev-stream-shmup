using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton object for the player.
public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player Get()
    {
        return instance;
    }

    public int maxHP;
    public float invincibilityDurationOnHit;
    public PlayerGraphics graphics;
    public ParticleSystem explosionPrefab;
    public AudioSource explosionSoundPrefab;

    private int currentHP;

    private float invincibilityEndTime = 0;

    void Awake()
    {
        Player.instance = this;
    }

    void Start()
    {
        this.currentHP = this.maxHP;
    }

    void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (this.invincibilityEndTime <= Time.time)
        {
            EnemyBullet enemyBullet = collision2d.rigidbody.GetComponent<EnemyBullet>();
            if (enemyBullet)
            {
                enemyBullet.HandleCollisionWithPlayer(this);
            }
            this.SustainDamage(1);
        }
    }

    private void SustainDamage(int damage)
    {
        this.currentHP -= damage;
        if (this.currentHP <= 0)
        {
            this.Explode();
        }
        else
        {
            this.invincibilityEndTime = Time.time + this.invincibilityDurationOnHit;
            this.graphics.StartInvincibilityFlash(this.invincibilityDurationOnHit);
        }
    }

    private void Explode()
    {
        // Disable colliders so we can't participate in any more collisions.
        foreach (Collider2D c2d in GetComponentsInChildren<Collider2D>())
        {
            c2d.enabled = false;
        }

        Instantiate(this.explosionPrefab, this.transform.position, Quaternion.identity);
        Instantiate(this.explosionSoundPrefab, this.transform.position, Quaternion.identity);

        // Temporary: just destroy game object.
        // In future: show exploding animation and play sound.
        Destroy(this.gameObject);
    }
}
