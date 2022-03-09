using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimePossessionState : SlimeState2
{
    public float animationTime = 1f;
    private float timer = 0f;

    public override void EnterState() 
    {
        entity.animator.SetTrigger("Possession");
        timer = 0f;
    }

    public override void ExitState(SlimeState2 newState)
    {
        entity.EnterState(newState);
    }

    public override void PlayerUpdate() 
    { 
        if (timer > animationTime)
        {
            ExitState(entity.idleState);
            return;
        }
        timer += Time.deltaTime;
    }

    public override void EntityUpdate() 
    {
        Debug.LogError("SlimePossessionState: Slime being possessed while not registered as player.");
        ExitState(entity.idleState);
    }
}
