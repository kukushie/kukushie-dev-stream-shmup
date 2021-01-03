using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public PlayerShot shotPrefab;
    public float shotAngleDeg;
    public float cooldown;
    public AudioSource shotSound;

    private float cooldownEndTime = 0f;

    // Fires a shot if the cooldown from the previous shot has ended.
    public void Fire()
    {
        if (this.cooldownEndTime > Time.time)
        {
            // Cooldown ends in the future. Do nothing.
            return;
        }

        // Fire shot.
        PlayerShot shot = Instantiate<PlayerShot>(this.shotPrefab, this.transform.position, Quaternion.identity);
        shot.angle = this.shotAngleDeg * Mathf.Deg2Rad;
        this.cooldownEndTime = Time.time + this.cooldown;
    }
}
