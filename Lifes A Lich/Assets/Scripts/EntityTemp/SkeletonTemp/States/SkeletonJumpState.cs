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
        entity.animator.SetTrigger("Jumping");
        entity.body.AddForce(entity.jumpForce * Vector3.up, ForceMode.VelocityChange);
        if (entity.sfxmanager != null) entity.sfxmanager.characterAudio.SkeletonJump(entity.gameObject);
    }

    public override void ExitState(SkeletonState newState)
    {
        timer = 0;
        base.ExitState(newState);
        entity.animator.SetTrigger("Jumping");
    }

    public override void PlayerUpdate()
    {
        Controls();
        entity.body.AddForce(new Vector3(-entity.body.velocity.x * entity.fakeFriction * Time.deltaTime, 0, -entity.body.velocity.z * entity.fakeFriction * Time.deltaTime), ForceMode.VelocityChange);

        if (entity.state != this) return;

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
        entity.body.AddForce(new Vector3(-entity.body.velocity.x * entity.fakeFriction * Time.deltaTime, 0, -entity.body.velocity.z * entity.fakeFriction * Time.deltaTime), ForceMode.VelocityChange);
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
