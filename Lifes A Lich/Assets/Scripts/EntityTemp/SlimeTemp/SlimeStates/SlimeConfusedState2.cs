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
        entity.animator.SetBool("IsIdle", true);
        confusedTimer = 0;
        entity.inPossessable = true;
    }

    public override void ExitState(SlimeState2 newState)
    {
        entity.animator.SetBool("IsIdle", false);
        entity.EnterState(newState);
        entity.inPossessable = false;
    }

    public override void PlayerUpdate()
    {
        ExitState(entity.possessionState);
    }

    public override void EntityUpdate()
    {
        if (confusedTimer > confusedTime)
        {
            entity.inPossessable = false;
        }
        confusedTimer += Time.deltaTime;
    }
}
