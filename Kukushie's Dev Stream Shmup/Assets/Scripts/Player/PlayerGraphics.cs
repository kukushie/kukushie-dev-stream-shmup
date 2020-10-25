using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphics : MonoBehaviour
{
    public float invincibilityFlashMinAlpha;
    public float invincibilitySlowFlashInterval;
    public float invincibilityFastFlashInterval;

    public SpriteRenderer sr;

    private float invincibilityEndTime = 0;
    private float invincibilityHalfOverTime = 0;

    private bool isFlashingInvincible = false;

    private float defaultAlpha;

    void Start()
    {
        this.defaultAlpha = sr.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlashingInvincible)
        {
            if (this.invincibilityEndTime > Time.time)
            {
                float t;
                if (this.invincibilityHalfOverTime > Time.time)
                {
                    t = Mathf.Cos(2f * Mathf.PI * (this.invincibilityHalfOverTime - Time.time) / this.invincibilitySlowFlashInterval);
                }
                else
                {
                    t = Mathf.Cos(2f * Mathf.PI * (this.invincibilityEndTime - Time.time) / this.invincibilityFastFlashInterval);
                }
                float alpha = (this.defaultAlpha - this.invincibilityFlashMinAlpha) * t + this.invincibilityFlashMinAlpha;
                this.sr.color = Util.SetAlpha(this.sr.color, alpha);
            }
            else
            {
                // Stop flashing.
                this.sr.color = Util.SetAlpha(this.sr.color, this.defaultAlpha);
                this.isFlashingInvincible = false;
            }
        }
    }

    public void StartInvincibilityFlash(float duration)
    {
        this.invincibilityEndTime = Time.time + duration;
        this.invincibilityHalfOverTime = Time.time + duration * 0.5f;
        this.isFlashingInvincible = true;
    }
}
