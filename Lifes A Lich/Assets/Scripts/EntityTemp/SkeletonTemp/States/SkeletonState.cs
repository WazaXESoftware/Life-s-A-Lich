using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkeletonState
{
    [HideInInspector] public Skeleton entity;

    public virtual void OnValidate(Skeleton entity)
    {
        this.entity = entity;
    }

    public virtual void EnterState() { }

    public virtual void ExitState(SkeletonState newState)
    {
        entity.EnterState(newState);
    }

    public virtual void PlayerUpdate() { }

    public virtual void EntityUpdate() { }

    public virtual void Update() { }

    public virtual void Action() { }

    public virtual void Possess() { }
}