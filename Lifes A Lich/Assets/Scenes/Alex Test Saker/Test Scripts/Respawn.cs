using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;

    private GameObject player;

    private void OnTriggerEnter(Collider collider)
    {
        Entity3 collidingEntity;
        if(collider.gameObject.TryGetComponent<Entity3>(out collidingEntity))
        {
            collidingEntity.body.velocity = Vector3.zero;
            collidingEntity.transform.position = respawnPoint.position;

            /**
            player = collision.gameObject;
            player.transform.position = respawnPoint.position;
            **/
        }
    }
}
