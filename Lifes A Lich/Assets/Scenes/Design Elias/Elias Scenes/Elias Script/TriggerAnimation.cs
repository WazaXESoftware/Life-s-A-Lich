using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
 [SerializeField] private Animator animationController;

 private void OnTriggerEnter(Collider other){
   if (other.CompareTag("Player")){
     animationController.SetBool("playerIn", true);
     Debug.Log("Entered Trigger");
   }
 }

 private void OnTriggerExit(Collider other){
   if (other.CompareTag("Player")){

   }
 }
}
