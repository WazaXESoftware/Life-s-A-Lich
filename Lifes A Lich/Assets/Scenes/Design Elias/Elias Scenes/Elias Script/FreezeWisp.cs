using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeWisp : MonoBehaviour
{

    public GameObject wisp;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
      wisp.GetComponent<Rigidbody>().constraints =
      RigidbodyConstraints.FreezePositionX |
      RigidbodyConstraints.FreezePositionZ |
      RigidbodyConstraints.FreezePositionY;

    }
}
