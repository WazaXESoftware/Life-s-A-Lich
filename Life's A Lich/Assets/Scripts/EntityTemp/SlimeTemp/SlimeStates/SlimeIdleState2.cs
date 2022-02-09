using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeIdleState2 : SlimeState2
{
    SphereCollider entityCollider;
    bool oneFrame = false;
    public override void EnterState()
    {
        base.EnterState();
        entity.chargeTimer = 0f;
        entityCollider = entity.GetComponent<SphereCollider>();
        oneFrame = false;
        entity.animator.SetBool("IsIdle", true);
    }

    public override void ExitState(SlimeState2 newState)
    {
        base.ExitState(newState);
        entity.animator.SetBool("IsIdle", false);
    }

    public override void PlayerUpdate()
    {
        
        entity.body.velocity = new Vector3(0, entity.body.velocity.y, 0);

        if (!Input.GetKey(KeyCode.Space))
        {
            if (entity.chargeTimer > 0)
            {
                entity.animator.SetTrigger("OnRelease");
                if (entity.chargeTimer > entity.leastChargeForSkip)
                {
                    float trueTime = Mathf.Clamp(entity.chargeTimer, 0f, entity.skipMaxChargeTime);
                    Vector3 forward = new Vector3(entity.cameraMain.transform.forward.x, 0, entity.cameraMain.transform.forward.z).normalized;
                    Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

                    float horizontal = Input.GetAxisRaw("Horizontal");
                    float vertical = Input.GetAxisRaw("Vertical");
                    Vector3 dir = (forward * vertical + right * horizontal).normalized;
                    if (dir.magnitude != 0) entity.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

                    entity.body.velocity = (trueTime / entity.skipMaxChargeTime) * dir * entity.skipForceX + new Vector3(0, (trueTime / entity.skipMaxChargeTime) * entity.skipForceY, 0);
                    ExitState(entity.jumpState);
                }
            }
            else
            {
                Vector3 forward = new Vector3(entity.cameraMain.transform.forward.x, 0, entity.cameraMain.transform.forward.z).normalized;
                Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;
                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");
                Vector3 dir = (forward * vertical + right * horizontal).normalized;
                if (dir.magnitude != 0) entity.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
                entity.body.velocity = dir * entity.moveSpeed + new Vector3(0, entity.body.velocity.y, 0);
            }

            entity.chargeTimer = 0f;
        }
        else
        {
            if (entity.chargeTimer == 0) entity.animator.SetTrigger("OnChargeUp");
            entity.chargeTimer += Time.deltaTime;
        }

        if (!IsGrounded()) ExitState(entity.jumpState);

        if (Input.GetButtonDown("Fire1"))
        {
            Action();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Possess();
        }

        oneFrame = true;
    }

    public override void Action()
    {
        //Perform Action
        ExitState(entity.actionState);
    }

    public override void Possess()
    {
        if (oneFrame)
        {
            entity.Exit();
            entity.EnterState(entity.confusedState);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(entityCollider.bounds.center, Vector3.down, (entity.transform.localScale.y + entityCollider.radius) + 0.01f);
    }
}
