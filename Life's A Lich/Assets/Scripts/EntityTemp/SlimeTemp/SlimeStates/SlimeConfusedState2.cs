using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeConfusedState2 : SlimeState2
{
    [Range(0.1f, 5f)] public float confusedTime = 1f;
    private float confusedTimer = 0;

    public override void EnterState()
    {
        //entity.animator.SetTrigger("Confused");
        confusedTimer = 0;
    }

    public override void ExitState(SlimeState2 newState)
    {
        entity.EnterState(entity.idleState);
    }

    public override void PlayerUpdate()
    {
        Debug.LogWarning("Warning: EntityConfusedState running while entity is player.");
    }

    public override void EntityUpdate()
    {
        if (confusedTimer > confusedTime)
        {
            ExitState(entity.idleState);
        }
        confusedTimer += Time.deltaTime;
    }
}
