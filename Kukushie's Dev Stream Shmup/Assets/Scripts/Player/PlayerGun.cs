using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public PlayerShot shotPrefab;
    public float shotAngleDeg;
    public float cooldown;

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
        PlayerShot shot = Instantiate<PlayerShot>(this.shotPrefab);
        shot.transform.position = this.transform.position;
        shot.angle = this.shotAngleDeg * Mathf.Deg2Rad;
        this.cooldownEndTime = Time.time + this.cooldown;
    }
}
