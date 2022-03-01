using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity3 : MonoBehaviour
{
    public Rigidbody body;
    public Animator animator;
    public LayerMask layerMask;

    private EventHandler eventHandler;
    [HideInInspector] public Camera cameraMain;
    protected Vector3 forward;
    protected Vector3 right;

    public bool frozen = false;
    [Range(0f, 50f)] public float moveSpeed = 5f;
    [Range(0f, 20f)] public float velocityCap = 10f;
    [Range(0f, 10f)] public float possessRange = 2f;
    [Tooltip("The wisp that spawns when exiting a monster.")] public GameObject host = null;
    [Tooltip("The offset of which the wisp is spawned when exiting a monster.")] public Vector3 spawnOffset = new Vector3(0, 1, 0);
    public bool player = false;
    [HideInInspector] public bool inPossessable = false;

    protected virtual void Start()
    {
        cameraMain = Camera.main;
        eventHandler = FindObjectOfType<EventHandler>();
        if (eventHandler == null) Debug.LogWarning("Entity3: Scene is missing an EventHandler.");
        else
        {
            eventHandler.onFreeze += Freeze;
            eventHandler.onUnFreeze += UnFreeze;
        }
    }

    protected virtual void Update()
    {
        if (player) gameObject.layer = 13;
        else gameObject.layer = 0;
        if (player && host == null) Debug.LogError("Entity: Error, player is true while the entity is missing a host.");
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, possessRange);
    }

    public void Freeze()
    {

    }

    public void UnFreeze()
    {

    }

    public Entity3 FindClosestEntity()
    {
        Entity3[] entities = FindObjectsOfType<Entity3>();
        Entity3 closestEntity = null;
        foreach (Entity3 entity in entities)
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

    public InteractableObject FindClosestInteractableObject()
    {
        InteractableObject[] objects = FindObjectsOfType<InteractableObject>();
        InteractableObject closestObject = null;
        foreach(InteractableObject object_ in objects)
        {
            float distanceToObject = (object_.transform.position - transform.position).magnitude;
            float distanceToClosestObject = 0f;
            if (closestObject != null) distanceToClosestObject = (closestObject.transform.position - transform.position).magnitude;
            if (distanceToObject < possessRange && 
               (closestObject == null || distanceToObject < distanceToClosestObject))
            {
                closestObject = object_;
            }
        }
        return closestObject;
    }

    public virtual void TakeOver(GameObject host)
    {
        if (!inPossessable)
        {
            player = true;
            gameObject.tag = "Player";
            gameObject.layer = 13;
            this.host = host;
            host.SetActive(false);
            host.transform.position = transform.position;
            host.transform.parent = transform;
        }
    }

    public virtual void Exit()
    {
        host.transform.parent = null;
        host.transform.position = transform.position + spawnOffset;
        host.SetActive(true);
        host.GetComponent<Entity3>().player = true;
        host = null;
        player = false;
        gameObject.tag = "Untagged";
        gameObject.layer = 0;
    }

    public virtual void Movement()
    {

        Vector3 forward = new Vector3(cameraMain.transform.forward.x, 0, cameraMain.transform.forward.z).normalized;
        Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = (forward * vertical + right * horizontal).normalized;
        if (new Vector3(body.velocity.x, 0, body.velocity.z).magnitude > 0.01f) transform.rotation = Quaternion.LookRotation(new Vector3(body.velocity.x, 0, body.velocity.z), Vector3.up);
        body.AddForce(dir * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
        Vector3 xzVector = new Vector3(body.velocity.x, 0, body.velocity.z);
        if (xzVector.magnitude > velocityCap)
        {
            Debug.Log("Braking...");
            float brakeForce = xzVector.magnitude - velocityCap;
            Vector3 velocityDir = xzVector.normalized;
            body.AddForce(-velocityDir * brakeForce, ForceMode.VelocityChange);
        }
    }

    public virtual void Respawn(Vector3 position)
    {
        transform.position = position;
        body.velocity = Vector3.zero;
    }

    /**
    public virtual void OnCollisionStay(Collision collision)
    {
        bool isGrounded = false;
        ContactPoint[] otherHit = collision.contacts;
        foreach (ContactPoint cpoint in otherHit)
        {
            if (cpoint.otherCollider == feet)
            {
                isGrounded = true;
            }
        }

        this.isGrounded = isGrounded;
    }
    **/
}
