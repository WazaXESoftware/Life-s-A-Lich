using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    public Animator anim;


    void Update()
    {
        anim.SetFloat("Move", Input.GetAxisRaw("Vertical"));
        anim.SetFloat("Sider", Input.GetAxisRaw("Horizontal"));
    }
}
