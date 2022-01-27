using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : Entity
{
    protected override void PlayerUpdate()
    {
        if (playerLastFrame)
        {
            forward = new Vector3(cameraMain.transform.forward.x, 0, cameraMain.transform.forward.z).normalized;
            right = Vector3.Cross(Vector3.up, forward).normalized;

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 dir = (forward * vertical + right * horizontal).normalized;
            if (dir.magnitude > 0) transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
            body.velocity = dir * moveSpeed;

            if (Input.GetButtonDown("Fire1"))
            {
                Action();
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Possess();
            }
        }
        playerLastFrame = player;

        if (!player) Destroy(this.gameObject);
    }

    protected override void Possess()
    {
        Entity target = FindClosestEntity();
        if (target != null)
        {
            bool swap = player;
            player = target.player;
            target.player = swap;
        }
    }

    protected override void Exit()
    {

    }
}
