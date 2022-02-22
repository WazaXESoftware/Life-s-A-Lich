using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkeletonCollapsedState : SkeletonState
{
    public float confusedTime = 1f;
    private float timer = 0f;

    public override void EnterState()
    {
        entity.inPossessable = true;
        entity.body.AddForce(new Vector3(-entity.body.velocity.x, 0, -entity.body.velocity.z), ForceMode.VelocityChange);
        entity.animator.SetBool("Dying", true);
    }

    public override void ExitState(SkeletonState newState)
    {
        base.ExitState(newState);
        entity.animator.SetBool("Dying", false);
    }

    public override void PlayerUpdate()
    {
        ExitState(entity.rebuildState);
    }

    public override void EntityUpdate()
    {
        if (timer > confusedTime)
        {
            entity.inPossessable = false;
        }
        timer += Time.deltaTime;
    }
}
