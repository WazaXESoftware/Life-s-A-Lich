using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody body;

    protected Camera cameraMain;
    protected Vector3 forward;
    protected Vector3 right;

    [Range(0f, 20f)] public float moveSpeed = 5f;
    [Range(0f, 10f)] public float possessRange = 2f;
    [Tooltip("The wisp that spawns when exiting a monster.")]public GameObject wisp;
    [Tooltip("The offset of which the wisp is spawned when exiting a monster.")] public Vector3 spawnOffset = new Vector3(0,1,0);
    public bool player = false;
    protected bool playerLastFrame = false;



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
        if (playerLastFrame)
        {
            forward = new Vector3(cameraMain.transform.forward.x, 0, cameraMain.transform.forward.z).normalized;
            right = Vector3.Cross(Vector3.up, forward).normalized;

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            body.velocity = (forward * vertical + right * horizontal).normalized * moveSpeed + new Vector3(0, body.velocity.y, 0);

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
    }

    protected virtual void EntityUpdate()
    {
        body.velocity = new Vector3(0, body.velocity.y, 0);
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
        if (target != null)
        {
            bool swap = player;
            player = target.player;
            target.player = swap;
        }
        else
        {
            Exit();
        }
    }

    protected virtual void Exit()
    {
        Instantiate(wisp, transform.position + spawnOffset, Quaternion.identity);
        player = false;
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
            float distanceToEntity = (entity.transform.position - transform.position).magnitude;
            float distanceToClosestEntity = 0f;
            if (closestEntity != null) distanceToClosestEntity = (closestEntity.transform.position - transform.position).magnitude;
            if (entity != this &&
                distanceToEntity < possessRange &&
                (closestEntity == null || distanceToEntity < distanceToClosestEntity))
            {
                closestEntity = entity;
            }
        }
        return closestEntity;
    }
}
