using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeJumpState2 : SlimeState2
{
    SphereCollider entityCollider;
    private float leastTimeSpent = 0.25f;
    private float timer = 0f;
    public override void EnterState()
    {
        entity.animator.SetBool("Jumping", true);
        entityCollider = entity.GetComponent<SphereCollider>();
        timer = 0f;
    }

    public override void ExitState(SlimeState2 newState)
    {
        base.ExitState(newState);
        entity.animator.SetBool("Jumping", false);
    }
    public override void PlayerUpdate()
    {
        timer += Time.deltaTime;
        if (entity.IsGrounded() && timer > leastTimeSpent)
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
