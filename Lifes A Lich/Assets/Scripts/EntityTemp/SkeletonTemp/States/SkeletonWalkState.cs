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
        Controls();

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

    public override void Controls()
    {
        if (entity.frozen) return;

        entity.Movement();

        if (Input.GetButtonDown("Jump"))
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
