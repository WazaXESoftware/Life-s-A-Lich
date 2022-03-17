using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    
    Animator m_Animator;
    
    bool myAnim;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            myAnim = true;
        }
        else
        {
            myAnim = false;
        }
    }
}
