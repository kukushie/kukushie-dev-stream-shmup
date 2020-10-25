using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public EnemyBullet bulletPrefab;
    public float initialAngleDeg;
    public float initialBulletSpeed;

    private float currentAngle;
    private float currentBulletSpeed;

    void Start()
    {
        this.currentAngle = initialAngleDeg * Mathf.Deg2Rad;
        this.currentBulletSpeed = this.initialBulletSpeed;
    }

    public void SetAngle(float newAngle)
    {
        this.currentAngle = newAngle;
    }

    public void TurnToAngleDeg(float targetAngleDeg, float maxTurnDeg)
    {
        this.currentAngle = Mathf.MoveTowardsAngle(this.currentAngle * Mathf.Rad2Deg, targetAngleDeg, maxTurnDeg) * Mathf.Deg2Rad;
    }

    public void SetSpeed(float newSpeed)
    {
        this.currentBulletSpeed = newSpeed;
    }

    public void Fire()
    {
        EnemyBullet newBullet = Instantiate<EnemyBullet>(this.bulletPrefab);
        newBullet.transform.position = this.transform.position;
        newBullet.angle = this.currentAngle;
        newBullet.speed = this.currentBulletSpeed;
    }
}
