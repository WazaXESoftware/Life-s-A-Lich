using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonRebuildState : SkeletonState
{
    public float rebuildTime = 1.7f;
    private float timer = 0f;
    public override void EnterState()
    {
        timer = 0f;
        entity.animator.SetBool("Rebuilding", true);
    }

    public override void ExitState(SkeletonState newState)
    {
        base.ExitState(newState);
        entity.animator.SetBool("Rebuilding", false);
    }

    public override void PlayerUpdate()
    {
        if (timer > rebuildTime)
        {
            ExitState(entity.idleState);
            return;
        }
        timer += Time.deltaTime;
    }
}
