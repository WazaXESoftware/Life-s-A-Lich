using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFallState : SkeletonState
{
    public override void EnterState()
    {
        entity.animator.SetBool("Falling", true);
    }

    public override void ExitState(SkeletonState newState)
    {
        base.ExitState(newState);
        entity.animator.SetBool("Falling", false);
    }

    public override void PlayerUpdate()
    {
        Controls();
        entity.body.AddForce(new Vector3(-entity.body.velocity.x * entity.fakeFriction * Time.deltaTime, 0, -entity.body.velocity.z * entity.fakeFriction * Time.deltaTime), ForceMode.VelocityChange);
        if (entity.state != this) return;

        if (entity.IsGrounded())
        {
            ExitState(entity.idleState);
            return;
        }
    }

    public override void EntityUpdate()
    {
        entity.body.AddForce(new Vector3(-entity.body.velocity.x * entity.fakeFriction * Time.deltaTime, 0, -entity.body.velocity.z * entity.fakeFriction * Time.deltaTime), ForceMode.VelocityChange);
        if (entity.IsGrounded())
        {
            ExitState(entity.idleState);
            return;
        }
    }

    public override void Controls()
    {
        if (entity.frozen) return;

        entity.Movement();
    }
}
