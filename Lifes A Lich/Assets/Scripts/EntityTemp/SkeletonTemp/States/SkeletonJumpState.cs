using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkeletonJumpState : SkeletonState
{
    public float animationTime = 1f;
    public float minTimeSpent = 0.15f;
    public float timer = 0;

    public override void EnterState()
    {
        timer = 0;
        entity.animator.SetBool("Jumping", true);
        entity.body.AddForce(entity.jumpForce * Vector3.up, ForceMode.VelocityChange);
    }

    public override void ExitState(SkeletonState newState)
    {
        timer = 0;
        base.ExitState(newState);
        entity.animator.SetBool("Jumping", false);
    }

    public override void PlayerUpdate()
    {
        Controls();
        if (timer > minTimeSpent && entity.IsGrounded())
        {
            ExitState(entity.idleState);
            return;
        }
        if (timer > animationTime)
        {
            ExitState(entity.fallState);
            return;
        }
        timer += Time.deltaTime;
    }

    public override void EntityUpdate()
    {
        if (timer > minTimeSpent && entity.IsGrounded())
        {
            ExitState(entity.idleState);
            return;
        }
        if (timer > animationTime)
        {
            ExitState(entity.fallState);
            return;
        }
        timer += Time.deltaTime;
    }

    public override void Controls()
    {
        if (entity.frozen) return;

        entity.Movement();
    }
}
