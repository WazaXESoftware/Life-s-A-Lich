using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime3 : Entity3
{
    //[Header("Slime skipping")]
    //public bool skip = true;
    //[Range(0.3f, 3f)] public float skipMaxChargeTime = 2f;
    //[Range(0f, 3f)] public float leastChargeForSkip = 0.1f;
    [Range(1f, 20f)] public float skipForceY = 6f;
    [Range(1f, 10f)] public float chargeAmplifier = 3f;
    [Range(0.1f, 20f)] public float skipForceX = 10f;
    //public float chargeTimer = 0f;

    private SlimeState2 state;

    [Header("States")]
    public SlimeIdleState2 idleState = new SlimeIdleState2();
    public SlimeChargeState2 chargeState = new SlimeChargeState2();
    public SlimeJumpState2 jumpState = new SlimeJumpState2();
    public SlimeActionState2 actionState = new SlimeActionState2();
    public SlimeConfusedState2 confusedState = new SlimeConfusedState2();

    public void Awake()
    {
        idleState.OnValidate(this);
        chargeState.OnValidate(this);
        jumpState.OnValidate(this);
        actionState.OnValidate(this);
        confusedState.OnValidate(this);
    }

    public void OnValidate()
    {
        idleState.OnValidate(this);
        chargeState.OnValidate(this);
        jumpState.OnValidate(this);
        actionState.OnValidate(this);
        confusedState.OnValidate(this);
    }

    protected override void Start()
    {
        base.Start();
        EnterState(idleState);
    }

    public void EnterState(SlimeState2 newState)
    {
        state = newState;
        state.EnterState();
    }

    protected override void Update()
    {
        if (player)
        {
            gameObject.layer = 12;
            state.PlayerUpdate();
        }
        else
        {
            gameObject.layer = 10;
            state.EntityUpdate();
        }
        if (player && host == null) Debug.LogError("Entity: Error, player is true while the entity is missing a host.");
        state.Update();

        if (state == idleState) Debug.Log("IdleState");
        if (state == chargeState) Debug.Log("ChargeState");
        if (state == jumpState) Debug.Log("JumpState");
        if (state == actionState) Debug.Log("ActionState");
        if (state == confusedState) Debug.Log("ConfusedState");
        animator.SetFloat("Speed", new Vector3(body.velocity.x, 0, body.velocity.z).magnitude);
    }

    public override void TakeOver(GameObject host)
    {
        if (!inPossessable)
        {
            player = true;
            gameObject.tag = "Player";
            gameObject.layer = 12;
            this.host = host;
            host.SetActive(false);
            host.transform.position = transform.position;
            host.transform.parent = transform;
        }
    }

    public override void Exit()
    {
        host.transform.parent = null;
        host.transform.position = transform.position + spawnOffset;
        host.SetActive(true);
        host.GetComponent<Entity3>().player = true;
        host = null;
        player = false;
        gameObject.tag = "Untagged";
        gameObject.layer = 10;
    }

    public override void Respawn(Vector3 position)
    {
        base.Respawn(position);
    }

    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        SphereCollider collider = GetComponent<SphereCollider>();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collider.bounds.center - new Vector3(0, 0.25f, 0), collider.radius * transform.localScale.y - 0.1f);
        Gizmos.color = Color.white;
    }

    public bool IsGrounded()
    {
        //return entity.IsGrounded;
        SphereCollider entityCollider = GetComponent<SphereCollider>();
        return Physics.CheckSphere(entityCollider.bounds.center - new Vector3(0, 0.25f, 0), (entityCollider.radius * transform.localScale.y) - 0.1f, layerMask, QueryTriggerInteraction.Ignore);
    }
}
