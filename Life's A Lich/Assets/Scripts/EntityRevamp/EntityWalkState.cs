using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityWalkState : EntityState
{
    private Entity2 entity;

    public override void EnterState() 
    {

    }

    public override void ExitState(EntityState newState) 
    {
        entity.EnterState(newState);
    }

    public override void PlayerUpdate() 
    {
        Debug.Log("jadu");
        Vector3 forward = new Vector3(entity.cameraMain.transform.forward.x, 0, entity.cameraMain.transform.forward.z).normalized;
        Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = (forward * vertical + right * horizontal).normalized;
        if (dir.magnitude != 0) entity.transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
        entity.body.velocity = dir * entity.moveSpeed + new Vector3(0, entity.body.velocity.y, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            Action();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Possess();
        }

        
        if (entity.body.velocity.magnitude < 0.01f) ExitState(entity.idleState);
    }

    public override void EntityUpdate() { }

    public override void Update() { }

    public override void Action() 
    {
        //perform action
        ExitState(entity.actionState);
    }

    public override void Possess() { }
}
