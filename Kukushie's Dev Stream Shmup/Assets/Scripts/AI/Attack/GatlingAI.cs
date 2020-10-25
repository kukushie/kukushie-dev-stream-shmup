using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatlingAI : MonoBehaviour
{
    public EnemyGun gun;
    public int bulletsPerVolley;
    public float volleyInterval;
    public float cooldownAfterVolley;

    private int bulletsFiredInCurrentVolley = 0;
    private float nextFireTime = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (nextFireTime <= Time.time)
        {
            this.gun.Fire();
            this.bulletsFiredInCurrentVolley += 1;
            
            // Check if we fired the last bullet in this volley.
            if (this.bulletsFiredInCurrentVolley >= this.bulletsPerVolley)
            {
                // Cooldown until next volley.
                this.nextFireTime = Time.time + this.cooldownAfterVolley;
                this.bulletsFiredInCurrentVolley = 0;
            }
            else
            {
                // Cooldown until next bullet in current volley.
                this.nextFireTime = Time.time + this.volleyInterval;
            }
        }
    }
}
