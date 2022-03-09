using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTriggered : MonoBehaviour
{
    // Start is called before the first frame update
[SerializeField] Lever lever;
[SerializeField] private Animator animationController;

    void Update()
    {
        if(lever.leverPulled == true){
          animationController.SetBool("Triggered", true);
        }
        else if (lever.leverPulled == false){
          animationController.SetBool("Triggered", false);
        }
    }
}
