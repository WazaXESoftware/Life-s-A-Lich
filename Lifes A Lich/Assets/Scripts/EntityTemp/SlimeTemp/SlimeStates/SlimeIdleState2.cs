using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeIdleState2 : SlimeState2
{
    SphereCollider entityCollider;
    bool oneFrame = false;
    public override void EnterState()
    {
        base.EnterState();
        //entity.chargeTimer = 0f;
        //entityCollider = entity.GetComponent<SphereCollider>();
        oneFrame = false;
        entity.animator.SetBool("IsIdle", true);
    }

    public override void ExitState(SlimeState2 newState)
    {
        base.ExitState(newState);
        entity.animator.SetBool("IsIdle", false);
    }

    public override void PlayerUpdate()
    {
        Controls();

        if (!entity.IsGrounded()) ExitState(entity.jumpState);

        oneFrame = true;
    }

    public override void Controls()
    {
        if (entity.frozen) return;

        if (Input.GetKey(KeyCode.Space) == false && Input.GetKey("joystick button 0") == false)
        {
            entity.Movement();
        }
        else
        {
            ExitState(entity.chargeState);
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

    public override void Action()
    {
        //Perform Action
        ExitState(entity.actionState);
    }

    public override void Possess()
    {
        if (oneFrame)
        {
            ExitState(entity.confusedState);
            entity.Exit();
        }
    }
}
