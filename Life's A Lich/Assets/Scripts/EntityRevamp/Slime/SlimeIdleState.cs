using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIdleState : EntityIdleState
{
    private Slime2 entity;

    public virtual void OnValidate(Slime2 entity)
    {
        this.entity = entity;
    }
    public override void PlayerUpdate()
    {

        if (!entity.skip) base.PlayerUpdate();

        else
        {


            if ((Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) || Mathf.Abs(entity.body.velocity.y) > 0.01f)
            {
                entity.chargeTimer = 0f;
            }
            else
            {
                entity.chargeTimer += Time.deltaTime;
                if (entity.chargeTimer > entity.skipChargeTime)
                {
                    entity.body.velocity = new Vector3(entity.body.velocity.x, entity.skipForce, entity.body.velocity.z);
                    entity.chargeTimer = 0f;
                }
            }

            if (Mathf.Abs(entity.body.velocity.y) > 0.01f)
            {
                Vector3 forward = new Vector3(entity.cameraMain.transform.forward.x, 0, entity.cameraMain.transform.forward.z).normalized;
                Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");
                Vector3 dir = (forward * vertical + right * horizontal).normalized;
                entity.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
                entity.body.velocity = dir * entity.moveSpeed + new Vector3(0, entity.body.velocity.y, 0);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Action();
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Possess();
            }
        }
    }
}
