using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeActionState2 : SlimeState2
{
    [Range(0.1f, 5f)] public float actionTime = 1f;
    private float actionTimer = 0;

    public override void EnterState()
    {
        base.EnterState();
        actionTimer = 0;
    }

    public override void PlayerUpdate()
    {
        if (actionTimer > actionTime)
        {
            ExitState(entity.idleState);
        }
        actionTimer += Time.deltaTime;
    }
}
