using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkeletonActionState : SkeletonState
{
    public float actionTime = 1f;
    private float timer = 0f;
    public override void EnterState()
    {
        entity.animator.SetBool("Action", true);
        //entity.animator.SetBool("Idle", true);
        InteractableObject iObject = entity.FindClosestInteractableObject();
        if (iObject != null) iObject.Interact();
        timer = 0f;
    }

    public override void ExitState(SkeletonState newState)
    {
        base.ExitState(newState);
        entity.animator.SetBool("Action", false);
        //entity.animator.SetBool("Idle", false);
    }

    public override void PlayerUpdate()
    {
        entity.body.AddForce(new Vector3(-entity.body.velocity.x * 10f * Time.deltaTime, 0, -entity.body.velocity.z * 10f * Time.deltaTime), ForceMode.VelocityChange);
        if (timer > actionTime)
        {
            ExitState(entity.idleState);
            return;
        }
        timer += Time.deltaTime;
    }

    public override void EntityUpdate()
    {
        entity.body.AddForce(new Vector3(-entity.body.velocity.x * 10f * Time.deltaTime, 0, -entity.body.velocity.z * 10f * Time.deltaTime), ForceMode.VelocityChange);
        if (timer > actionTime)
        {
            ExitState(entity.idleState);
            return;
        }
        timer += Time.deltaTime;
    }
}
