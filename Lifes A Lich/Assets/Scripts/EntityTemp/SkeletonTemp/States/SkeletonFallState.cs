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
        entity.Movement();
        if (entity.IsGrounded())
        {
            ExitState(entity.idleState);
            return;
        }
    }

    public override void EntityUpdate()
    {
        if (entity.IsGrounded())
        {
            ExitState(entity.idleState);
            return;
        }
    }
}
