using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime2 : Entity2
{
    [Header("Slime skipping")]
    public bool skip;
    [Range(0.1f, 2f)] public float skipChargeTime = 1f;
    [Range(1f, 6f)] public float skipForce = 3f;
    public float chargeTimer = 0f;

    
}
