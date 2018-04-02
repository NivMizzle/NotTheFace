﻿// Author(s): Paul Calande
// Component for making a Rigidbody jump based on whether it is grounded or not.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBasedJump2D : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The Rigidbody to apply the jump force to.")]
    Rigidbody2D rb;
    [SerializeField]
    [Tooltip("Reference to the GroundChecker to use.")]
    GroundChecker2D groundChecker;

    // Makes sure the Rigidbody can't jump repeatedly within consecutive frames.
    // This prevents the jump force from getting too large.
    // This is necessary because the GroundChecker may still detect a ground
    // contact even if the Rigidbody is already in the air.
    int jumpCooldown = 0;

    // Try to jump with the given velocity.
    // Returns true if the jump successfully executed and false if it did not.
    public bool TryJump(float jumpVelocity)
    {
        if (groundChecker.IsOnGround() && jumpCooldown == 0)
        {
            StartJumpCooldown();
            Vector2 velocity = rb.velocity;
            velocity.y += jumpVelocity;
            rb.velocity = velocity;
            return true;
        }
        return false;
    }

    private void StartJumpCooldown()
    {
        jumpCooldown = 2;
    }

    private void FixedUpdate()
    {
        if (jumpCooldown != 0)
        {
            --jumpCooldown;
        }
    }
}