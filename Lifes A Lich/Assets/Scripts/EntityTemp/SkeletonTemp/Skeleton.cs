using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Entity3
{
    [Range(0f, 100f)] public float jumpForce = 20f;

    public CapsuleCollider feetCollider;

    [HideInInspector] public SkeletonState state;

    public SkeletonIdleState idleState = new SkeletonIdleState();
    public SkeletonWalkState walkState = new SkeletonWalkState();
    public SkeletonJumpState jumpState = new SkeletonJumpState();
    public SkeletonFallState fallState = new SkeletonFallState();
    public SkeletonActionState actionState = new SkeletonActionState();
    public SkeletonCollapsedState collapsedState = new SkeletonCollapsedState();
    public SkeletonRebuildState rebuildState = new SkeletonRebuildState();


    public void Awake()
    {
        idleState.OnValidate(this);
        walkState.OnValidate(this);
        jumpState.OnValidate(this);
        fallState.OnValidate(this);
        actionState.OnValidate(this);
        collapsedState.OnValidate(this);
        rebuildState.OnValidate(this);
    }

    public void OnValidate()
    {
        idleState.OnValidate(this);
        walkState.OnValidate(this);
        jumpState.OnValidate(this);
        fallState.OnValidate(this);
        actionState.OnValidate(this);
        collapsedState.OnValidate(this);
        rebuildState.OnValidate(this);
    }
    protected override void Start()
    {
        base.Start();
        EnterState(collapsedState);
    }

    protected override void Update()
    {
        base.Update();
        if (player) state.PlayerUpdate();
        else state.EntityUpdate();

        if (state == idleState) Debug.Log("IdleState");
        if (state == jumpState) Debug.Log("JumpState");
        if (state == walkState) Debug.Log("WalkState");
        if (state == fallState) Debug.Log("FallState");
        if (state == actionState) Debug.Log("ActionState");
        if (state == collapsedState) Debug.Log("ConfusedState");

        animator.SetFloat("Speed", new Vector3(body.velocity.x, 0, body.velocity.z).magnitude);
    }

    public void EnterState(SkeletonState newState)
    {
        state = newState;
        state.EnterState();
    }

    public bool IsGrounded()
    {
        return Physics.CheckSphere(feetCollider.bounds.center - new Vector3(0, 0.025f * transform.localScale.y, 0), (feetCollider.radius * transform.localScale.y) + 0.015f * transform.localScale.y, layerMask, QueryTriggerInteraction.Ignore);
    }

    protected override void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, possessRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feetCollider.bounds.center - new Vector3(0, 0.025f * transform.localScale.y, 0), (feetCollider.radius * transform.localScale.y) + 0.015f * transform.localScale.y);
        Gizmos.color = Color.white;
    }

    public override void TakeOver(GameObject host)
    {
        base.TakeOver(host);
        //Lägg till kod här Markus :)
    }

    public override void Exit()
    {
        base.Exit();
        //Lägg till kod här Markus :)
    }
}
