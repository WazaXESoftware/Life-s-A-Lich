using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScrollUp : MonoBehaviour
{
    public GameObject virtualCamUp;
 public int check = 0;

void Update(){
  if(check == 1){
    float step = 0.002f;
              var cameraPosition = virtualCamUp.transform.position;
              cameraPosition.y += step;
              virtualCamUp.transform.position = cameraPosition;
  }

}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
          virtualCamUp.SetActive(true);
          StartCoroutine(Test());

          }
        }

        IEnumerator Test() {
        yield return new WaitForSeconds(3);
        check = 1;
      }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCamUp.SetActive(false);
            check = 0;
        }
    }

}
