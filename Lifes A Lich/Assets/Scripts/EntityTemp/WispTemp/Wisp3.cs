using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp3 : Entity3
{
    [Range(1f, 20f)]public float maximumFloatForce = 10f;

    [Range(0f, 10f)]public float desiredHeight = 3f;

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
        if (Physics.Raycast(transform.position, rayDirection, out raycastHit, desiredHeight))
        {
            Vector3 velocity = body.velocity;
            float rayDirectionVelocity = Vector3.Dot(rayDirection, velocity);
            float diff = raycastHit.distance - desiredHeight;
            float spring = (maximumFloatForce * diff) - (rayDirectionVelocity * maximumFloatForce);

            body.AddForce(rayDirection * spring);
        }

    }

    public override void TakeOver(GameObject host)
    {

    }

    public override void Exit()
    {
        
    }

}
