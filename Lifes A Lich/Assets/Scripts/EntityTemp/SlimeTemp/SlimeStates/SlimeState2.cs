using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeState2
{
    [HideInInspector]public Slime3 entity;

    public virtual void OnValidate(Slime3 entity)
    {
        this.entity = entity;
    }

    public virtual void EnterState() { }

    public virtual void ExitState(SlimeState2 newState)
    {
        entity.EnterState(newState);
    }

    public virtual void PlayerUpdate() { }

    public virtual void EntityUpdate() { }

    public virtual void Update() { }

    public virtual void Controls() { }

    public virtual void Action() { }

    public virtual void Possess() { }
}
