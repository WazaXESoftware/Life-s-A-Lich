using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityActionState : EntityState
{

    [Range(0.1f, 5f)] public float actionTime = 1f;
    private float actionTimer = 0;

    public override void EnterState() 
    {
        //entity.animator.SetTrigger("Action");
        actionTimer = 0;
    }

    public override void ExitState(EntityState newState) 
    {
        entity.EnterState(newState);
    }

    public override void PlayerUpdate() 
    {
        if (actionTimer > actionTime)
        {
            ExitState(entity.idleState);
        }
        actionTimer += Time.deltaTime;
    }

    public override void EntityUpdate() 
    {
        actionTimer += Time.deltaTime;
        Debug.LogWarning("EntityActionState: Entity Action activated while not controlled by player. Intended?");
    }

    public override void Update() { }

    public override void Action() { }

    public override void Possess() { }
}
