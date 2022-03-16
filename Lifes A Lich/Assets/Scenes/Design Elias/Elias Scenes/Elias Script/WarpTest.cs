using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpTest : InteractableObject
{
    public GameObject slime;
    [SerializeField] private Animator slimeSummonAnimator;
    public bool slimeSummoned;
    void Start()
    {

    }

    public override void Interact()
    {
        slimeSummoned = true;
    }
    void Update()
    {
        if(slimeSummoned == true)
        {
        slimeSummonAnimator.SetBool("summon", true);
        }

    }

}
