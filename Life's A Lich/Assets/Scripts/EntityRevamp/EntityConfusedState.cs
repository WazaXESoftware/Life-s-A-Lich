using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityConfusedState : EntityState
{

    [Range (0.1f, 5f)]public float confusedTime = 1f;
    private float confusedTimer = 0;

    public override void EnterState() 
    {
        //entity.animator.SetBool("Confused") = true;
        confusedTimer = 0;
    }

    public override void ExitState(EntityState newState) 
    {
        //animator.SetBool("Confused") = true;
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

    public override void Update() { }

    public override void Action() { }

    public override void Possess() { }
}
