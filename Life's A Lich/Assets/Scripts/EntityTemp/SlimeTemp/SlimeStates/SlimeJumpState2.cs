using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeJumpState2 : SlimeState2
{
    public override void PlayerUpdate()
    {
        if (Mathf.Abs(entity.body.velocity.y) <= 0.01f)
        {
            ExitState(entity.idleState);
        }
    }
}
