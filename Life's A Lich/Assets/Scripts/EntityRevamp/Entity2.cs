using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity2 : MonoBehaviour
{

    public Rigidbody body;

    [HideInInspector]public Camera cameraMain;
    protected Vector3 forward;
    protected Vector3 right;

    [Range(0f, 20f)] public float moveSpeed = 5f;
    [Range(0f, 10f)] public float possessRange = 2f;
    [Tooltip("The wisp that spawns when exiting a monster.")] public GameObject wisp;
    [Tooltip("The offset of which the wisp is spawned when exiting a monster.")] public Vector3 spawnOffset = new Vector3(0, 1, 0);
    public bool player = false;
    protected bool playerLastFrame = false;

    [HideInInspector]public EntityState state;

    public EntityIdleState idleState = new EntityIdleState();
    public EntityWalkState walkState = new EntityWalkState();
    public EntityActionState actionState = new EntityActionState();
    public EntityConfusedState confusedState = new EntityConfusedState();

    public virtual void OnValidate()
    {
        idleState.OnValidate(this);
        walkState.OnValidate(this);
        actionState.OnValidate(this);
        confusedState.OnValidate(this);
    }

    protected virtual void Start()
    {
        cameraMain = Camera.main;
        EnterState(idleState);
    }

    protected virtual void Update()
    {
        if (player) state.PlayerUpdate();
        else state.EntityUpdate();
        if (state == idleState) Debug.Log("IdleState");
        if (state == walkState) Debug.Log("WalkState");
        if (state == actionState) Debug.Log("ActionState");
        if (state == confusedState) Debug.Log("ConfusedState");
        //animator.SetFloat("Speed") = body.velocity.magnitude;
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, possessRange);
    }

    public void EnterState(EntityState newState)
    {
            state = newState;
            state.EnterState();
    }

    protected Entity FindClosestEntity()
    {
        Entity[] entities = FindObjectsOfType<Entity>();
        Entity closestEntity = null;
        foreach (Entity entity in entities)
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
