using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerX : MonoBehaviour
{
    public Animator animator;




    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("ButtonX");
        }

    }
}
