using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody body;

    Camera cameraMain;
    Vector3 forward;
    Vector3 right;

    [Range(0f, 20f)] public float moveSpeed = 5f;
    [Range(0f, 10f)] public float possessRange = 2f;
    public bool player = false;



    protected virtual void Start()
    {
        cameraMain = Camera.main;
    }

    protected virtual void Update()
    {
        if (player) PlayerUpdate();
        else EntityUpdate();
    }

    protected virtual void PlayerUpdate()
    {
        forward = new Vector3(cameraMain.transform.forward.x, 0, cameraMain.transform.forward.z).normalized;
        right = Vector3.Cross(Vector3.up, forward).normalized;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        body.velocity = (forward * vertical + right * horizontal).normalized * moveSpeed;

        if (Input.GetButtonDown("Fire1"))
        {
            Action();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Possess();
        }
    }

    protected virtual void EntityUpdate()
    {
        
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, possessRange);
    }

    protected virtual void Action()
    {

    }

    protected virtual void Possess()
    {
        Entity target = FindClosestEntity();
        Debug.Log(target.gameObject.name);
        if (target != null)
        {
            bool swap = player;
            player = target.player;
            target.player = swap;
        }
    }


    protected virtual void Jump()
    {

    }

    protected Entity FindClosestEntity()
    {
        Entity[] entities = FindObjectsOfType<Entity>();
        Entity closestEntity = null;
        foreach(Entity entity in entities)
        {
            if (entity != this && 
               (closestEntity == null || (closestEntity.transform.position - transform.position).magnitude > (entity.transform.position - transform.position).magnitude))
            {
                closestEntity = entity;
            }
        }
        return closestEntity;
    }
}
