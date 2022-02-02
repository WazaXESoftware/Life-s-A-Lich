using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityState
{
    [HideInInspector] public Entity2 entity;

    public virtual void OnValidate(Entity2 entity)
    {
        this.entity = entity;
    }
    /**
    public virtual void Start(Entity2 entity) 
    {
        this.entity = entity;
    }
    **/
    public virtual void EnterState() { }

    public virtual void ExitState(EntityState newState) 
    {
        entity.EnterState(newState);
    }

    public virtual void PlayerUpdate() { }

    public virtual void EntityUpdate() { }

    public virtual void Update() { }

    public virtual void Action() { }

    public virtual void Possess() { }
}
