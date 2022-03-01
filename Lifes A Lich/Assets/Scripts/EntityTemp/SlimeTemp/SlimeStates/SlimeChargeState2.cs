using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeChargeState2 : SlimeState2
{
    [Range(0.3f, 3f)] public float skipMaxChargeTime = 2f;
    [Range(0f, 3f)] public float leastChargeForSkip = 0.1f;
    float timer = 0f;
    public override void EnterState()
    {
        entity.animator.SetTrigger("Charging");
        timer = 0f;
    }

    public override void ExitState(SlimeState2 newState)
    {
        base.ExitState(newState);
        //entity.animator.SetBool("Charging", false);
    }

    public override void PlayerUpdate()
    {
        if (entity.frozen)
        {
            ExitState(entity.idleState);
            return;
        }

        entity.body.AddForce(new Vector3(-entity.body.velocity.x * 0.97f * Time.deltaTime, 0, -entity.body.velocity.z * 0.97f * Time.deltaTime), ForceMode.VelocityChange);
        if (Input.GetKey(KeyCode.Space) == false || Input.GetKey("joystick button 0") == false)
        {
            if (timer < leastChargeForSkip)
            {
                ExitState(entity.idleState);
                return;
            }
            else
            {
                float trueTime = Mathf.Clamp(timer, 0f, skipMaxChargeTime);
                Vector3 forward = new Vector3(entity.cameraMain.transform.forward.x, 0, entity.cameraMain.transform.forward.z).normalized;
                Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");
                Vector3 dir = (forward * vertical + right * horizontal).normalized;
                if (dir.magnitude != 0) entity.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);

                entity.body.velocity = (trueTime / skipMaxChargeTime) * dir * entity.skipForceX + new Vector3(0, (trueTime / skipMaxChargeTime) * entity.skipForceY, 0);
                ExitState(entity.jumpState);
                return;
            }
        }
        timer += Time.deltaTime;
    }

    public override void EntityUpdate()
    {
        ExitState(entity.idleState);
        return;
    }
}
