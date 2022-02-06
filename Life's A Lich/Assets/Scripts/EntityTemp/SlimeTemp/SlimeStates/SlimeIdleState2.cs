using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeIdleState2 : SlimeState2
{
    public override void PlayerUpdate()
    {

        entity.body.velocity = new Vector3(0, entity.body.velocity.y, 0);

        if (!Input.GetKey(KeyCode.Space))
        {
            if (entity.chargeTimer > entity.leastChargeForSkip)
            {
                float trueTime = Mathf.Clamp(entity.chargeTimer, 0f, entity.skipMaxChargeTime);
                Vector3 forward = new Vector3(entity.cameraMain.transform.forward.x, 0, entity.cameraMain.transform.forward.z).normalized;
                Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");
                Vector3 dir = (forward * vertical + right * horizontal).normalized;
                entity.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

                entity.body.velocity = dir * entity.moveSpeed + new Vector3(0, (trueTime/entity.skipMaxChargeTime)*entity.skipForce, 0);
            }
            entity.chargeTimer = 0f;
        }
        else
        {
            entity.chargeTimer += Time.deltaTime;
        }

        if (Mathf.Abs(entity.body.velocity.y) > 0.01f) ExitState(entity.jumpState);

        if (Input.GetButtonDown("Fire1"))
        {
            Action();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Possess();
        }
    }

    public override void Action()
    {
        //Perform Action
        ExitState(entity.actionState);
    }

    public override void Possess()
    {
        Entity3 target = entity.FindClosestEntity();
        if (target != null)
        {
            target.TakeOver();
            entity.player = false;
            entity.EnterState(entity.confusedState);
        }
        else
        {
            entity.Exit();
            entity.EnterState(entity.confusedState);
        }
    }
}
