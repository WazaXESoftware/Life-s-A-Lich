using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBarrel : MonoBehaviour
{
    public Transform respawnPointBarrel;

    private GameObject barrel;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Barrel")
        {
            barrel = collision.gameObject;
            barrel.transform.position = respawnPointBarrel.position;
            barrel.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
