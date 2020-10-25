using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftingAI : MonoBehaviour
{
    public float maxRadiusFromCenter;
    public float driftInterval;
    public float stayAtTargetDuration;

    private EnemyMovement movement;
    private Vector2 currentTarget = Vector2.zero;

    private float nextDriftTime = 0;
    private float stopMovingTime = 0;

    // 0 means we're at our starting position. 1 means we're at our target.
    private float progressToTarget;
    private Vector2 vectorFromStartToTarget;

    // Start is called before the first frame update
    void Start()
    {
        this.movement = GetComponentInParent<EnemyMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.nextDriftTime <= Time.time)
        {
            this.PickNewTarget();
        }
        else if (this.stopMovingTime > Time.time)
        {
            // Compute how far we should move towards the target in this frame.
            float movementDuration = this.driftInterval - this.stayAtTargetDuration;
            float t = (movementDuration - (this.stopMovingTime - Time.time)) / movementDuration;
            float previousProgress = this.progressToTarget;
            this.progressToTarget = Mathf.SmoothStep(0f, 1f, t);
            Vector2 displacement = vectorFromStartToTarget * (this.progressToTarget - previousProgress);
            
            this.movement.Move(displacement);
        }
    }

    private void PickNewTarget()
    {
        float magnitude = Random.value * this.maxRadiusFromCenter;
        float angle = Random.value * Mathf.PI * 2f;
        Vector2 nextTarget = V2.FromMagnitudeAngle(magnitude, angle);
        this.vectorFromStartToTarget = nextTarget - this.currentTarget;
        this.currentTarget = nextTarget;
        this.progressToTarget = 0;
        this.stopMovingTime = Time.time + this.driftInterval - this.stayAtTargetDuration;
        this.nextDriftTime = Time.time + this.driftInterval;
    }
}
