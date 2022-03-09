using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp3 : Entity3
{
    [Range(1f, 20f)]public float maximumFloatForce = 10f;
    [Range(0f, 10f)]public float desiredHeight = 3f;

    [Range(0f, 1f)] public float fakeFriction;
    public bool haltOnRelease = false;

    private SphereCollider bodyCollider;

    private WispState state;

    [Header("States")]
    public WispIdleState idleState;

    public void OnValidate()
    {
        idleState.OnValidate(this);
    }

    protected override void Start()
    {
        base.Start();
        EnterState(idleState);
        inPossessable = true;

        bodyCollider = gameObject.GetComponent<SphereCollider>();
        if (bodyCollider == null) Debug.LogError("Wisp is missing a SphereCollider.");
    }

    private void Update()
    {
        if (player) state.PlayerUpdate();
        else state.EntityUpdate();
    }

    public void EnterState(WispState newState)
    {
        state = newState;
        state.EnterState();
    }

    private void FixedUpdate()
    {
        RaycastHit raycastHit;
        Vector3 rayDirection = Vector3.down;
        float radius = bodyCollider.radius * transform.localScale.x;
        if (Physics.SphereCast(transform.position, radius, rayDirection, out raycastHit, desiredHeight, layerMask, QueryTriggerInteraction.Ignore))
        {
            Vector3 velocity = body.velocity;
            float rayDirectionVelocity = Vector3.Dot(rayDirection, velocity);
            float diff = raycastHit.distance - desiredHeight;
            float spring = (maximumFloatForce * diff) - (rayDirectionVelocity * maximumFloatForce);

            body.AddForce(rayDirection * spring);
        }
        if (frozen) body.AddForce(new Vector3(-body.velocity.x * 0.95f * Time.deltaTime, 0, -body.velocity.z * 0.95f * Time.deltaTime), ForceMode.VelocityChange);
    }

    public override void Movement()
    {
        Vector3 forward = new Vector3(cameraMain.transform.forward.x, 0, cameraMain.transform.forward.z).normalized;
        Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = (forward * vertical + right * horizontal).normalized;
        if (body.velocity.magnitude > 0.01f) transform.rotation = Quaternion.LookRotation(new Vector3(body.velocity.x, 0, body.velocity.z), Vector3.up);
        body.AddForce(dir * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
        if (body.velocity.magnitude > velocityCap)
        {
            Debug.Log("Braking...");
            float brakeForce = body.velocity.magnitude - velocityCap;
            Vector3 velocityDir = body.velocity.normalized;
            body.AddForce(-velocityDir * brakeForce, ForceMode.VelocityChange);
        }

        //Wisp Fake Friction
        body.AddForce(new Vector3(-body.velocity.x * fakeFriction * Time.deltaTime, 0, -body.velocity.z * fakeFriction * Time.deltaTime), ForceMode.VelocityChange);

        //If Wisp should halt on release
        if (haltOnRelease && Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            body.AddForce(new Vector3(-body.velocity.x * 0.95f * Time.deltaTime, 0, -body.velocity.z * 0.95f * Time.deltaTime), ForceMode.VelocityChange);
        }
    }

    public override void TakeOver(GameObject host)
    {

    }

    public override void Exit()
    {
        
    }

}
