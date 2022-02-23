using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public Animator slimeAnimator;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("boing");
        slimeAnimator.SetTrigger("OnBounce");
    }
}
