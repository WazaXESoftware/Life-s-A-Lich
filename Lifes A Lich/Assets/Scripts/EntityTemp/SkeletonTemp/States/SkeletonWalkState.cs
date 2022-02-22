using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkeletonWalkState : SkeletonState
{
    public override void EnterState()
    {
        entity.animator.SetBool("Walking", true);
    }


    public override void ExitState(SkeletonState newState)
    {
        base.ExitState(newState);
        entity.animator.SetBool("Walking", false);
    }

    public override void PlayerUpdate()
    {
        entity.Movement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitState(entity.jumpState);
            return;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Possess();
        }

        if (!entity.IsGrounded())
        {
            ExitState(entity.fallState);
            return;
        }
        else if (new Vector3(entity.body.velocity.x, 0, entity.body.velocity.z).magnitude <= 0.01f)
        {
            ExitState(entity.idleState);
            return;
        }
    }

    public override void EntityUpdate()
    {
        if (!entity.IsGrounded())
        {
            ExitState(entity.fallState);
            return;
        }
        else if (new Vector3(entity.body.velocity.x, 0, entity.body.velocity.z).magnitude <= 0.01f)
        {
            ExitState(entity.idleState);
            return;
        }
    }

    public override void Possess()
    {
        ExitState(entity.collapsedState);
        entity.Exit();
    }
}
