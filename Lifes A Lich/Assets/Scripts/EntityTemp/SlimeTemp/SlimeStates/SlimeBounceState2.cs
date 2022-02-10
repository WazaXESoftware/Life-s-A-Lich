using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlimeBounceState2 : SlimeState2
{
    [Range(0.1f, 5f)] public float bounceTime = 1f;
    private float bounceTimer = 0;

    public override void EnterState()
    {
        //animator.SetTrigger("Bounce");
        bounceTimer = 0;
    }

    public override void Update()
    {
        if (bounceTimer > bounceTime) ExitState(entity.idleState);
    }
}
