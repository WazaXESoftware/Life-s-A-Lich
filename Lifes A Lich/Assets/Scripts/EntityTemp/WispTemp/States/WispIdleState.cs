using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WispIdleState : WispState
{
    public override void PlayerUpdate() 
    {
        Controls();
    }

    public override void Controls()
    {
        if (entity.frozen) return;

        entity.Movement();

        if (Input.GetButtonDown("Fire1"))
        {
            Action();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Possess();
        }
    }

    public override void Possess()
    {
        Entity3 target = entity.FindClosestEntity();
        if (target != null)
        {
            target.TakeOver(entity.host);
        }
    }
}
