using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeJumpState2 : SlimeState2
{
    SphereCollider entityCollider;
    private float leastTimeSpent = 0.25f;
    private float timer = 0f;
    public override void EnterState()
    {
        entity.animator.SetTrigger("OnJump");
        entityCollider = entity.GetComponent<SphereCollider>();
        timer = 0f;
    }
    public override void PlayerUpdate()
    {
        timer += Time.deltaTime;
        if (IsGrounded() && timer > leastTimeSpent)
        {
            ExitState(entity.idleState);
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(entityCollider.bounds.center - new Vector3(0, Physics.defaultContactOffset, 0), entityCollider.radius, entity.layerMask, QueryTriggerInteraction.UseGlobal);
    }
}
