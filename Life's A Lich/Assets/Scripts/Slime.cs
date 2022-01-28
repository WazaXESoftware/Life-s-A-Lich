using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Entity
{
    [Header("Slime skipping")]
    public bool skip;
    [Range(0.1f, 2f)]public float skipChargeTime = 1f;
    [Range(1f, 6f)]public float skipForce = 3f;
    public float chargeTimer = 0f;

    protected override void PlayerUpdate()
    {
        
        if (playerLastFrame)
        {

            if (!skip) base.PlayerUpdate();

            else
            {
                

                if ((Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) || Mathf.Abs(body.velocity.y) > 0.01f)
                {
                    chargeTimer = 0f;
                }
                else
                {
                    chargeTimer += Time.deltaTime;
                    if (chargeTimer > skipChargeTime)
                    {
                        body.velocity = new Vector3(body.velocity.x, skipForce, body.velocity.z);
                        chargeTimer = 0f;
                    }
                }

                if (Mathf.Abs(body.velocity.y) > 0.01f)
                {
                    forward = new Vector3(cameraMain.transform.forward.x, 0, cameraMain.transform.forward.z).normalized;
                    right = Vector3.Cross(Vector3.up, forward).normalized;

                    float horizontal = Input.GetAxisRaw("Horizontal");
                    float vertical = Input.GetAxisRaw("Vertical");
                    Vector3 dir = (forward * vertical + right * horizontal).normalized;
                    transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
                    body.velocity = dir * moveSpeed + new Vector3(0, body.velocity.y, 0);
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

        playerLastFrame = player;
    }
}
