using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WispState
{
    [HideInInspector] public Wisp3 entity;

    public virtual void OnValidate(Wisp3 entity)
    {
        this.entity = entity;
    }

    public virtual void EnterState() { }

    public virtual void ExitState(WispState newState)
    {
        entity.EnterState(newState);
    }

    public virtual void PlayerUpdate() { }

    public virtual void EntityUpdate() { }

    public virtual void Update() { }

    public virtual void Action() { }

    public virtual void Possess() { }
}
