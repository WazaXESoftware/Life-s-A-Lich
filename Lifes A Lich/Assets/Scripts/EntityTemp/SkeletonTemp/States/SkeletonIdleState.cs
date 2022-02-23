using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkeletonIdleState : SkeletonState
{

    public override void EnterState()
    {
        entity.animator.SetBool("Idle", true);
    }

    public override void ExitState(SkeletonState newState)
    {
        base.ExitState(newState);
        entity.animator.SetBool("Idle", false);
    }

    public override void PlayerUpdate()
    {
        entity.Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExitState(entity.jumpState);
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Action();
            return;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Possess();
            return;
        }

        if (!entity.IsGrounded())
        {
            ExitState(entity.fallState);
            return;
        }
        else if (new Vector3(entity.body.velocity.x, 0, entity.body.velocity.z).magnitude > 0.01f)
        {
            ExitState(entity.walkState);
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
        else if (new Vector3(entity.body.velocity.x, 0, entity.body.velocity.z).magnitude > 0.01f)
        {
            ExitState(entity.walkState);
            return;
        }
    }

    public override void Possess()
    {
        ExitState(entity.collapsedState);
        entity.Exit();
    }

    public override void Action()
    {
        ExitState(entity.actionState);
    }

}
