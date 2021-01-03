using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayerAI : MonoBehaviour
{
    public EnemyGun gun;

    public float rateOfTurnDeg;

    // Update is called once per frame
    void FixedUpdate()
    {
        Player player = Player.Get();
        if (!player) {
            return;
        }
        Vector2 playerPosition = Player.Get().transform.position;
        Vector2 ourPosition = this.gun.transform.position;
        float angleToPlayerDeg = V2.AngleTo(ourPosition, playerPosition) * Mathf.Rad2Deg;
        float maxTurnDeg = rateOfTurnDeg * Time.deltaTime;
        this.gun.TurnToAngleDeg(angleToPlayerDeg, maxTurnDeg);
    }
}
