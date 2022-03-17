using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DoorClose : MonoBehaviour
{
    public StudioEventEmitter slutMusik;
  public GameObject door;
  private float minHeight;
    // Start is called before the first frame update
[SerializeField] Lever lever;
void Start()
{
    minHeight = door.transform.position.y;
}


    private void OnTriggerEnter(Collider other){
      if (other.CompareTag("Player") && door.transform.position.y > minHeight){
        lever.leverPulled = false;
            slutMusik.Play();
      }
    }

}
