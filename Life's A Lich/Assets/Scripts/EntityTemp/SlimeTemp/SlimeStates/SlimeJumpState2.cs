using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeJumpState2 : SlimeState2
{
    SphereCollider entityCollider;
    private float leastTimeSpent = 0.05f;
    private float timer = 0f;
    public override void EnterState()
    {
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
        return Physics.Raycast(entity.transform.position, Vector3.down, entityCollider.radius + 0.01f);
    }
}
