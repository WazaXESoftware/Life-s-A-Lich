using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFloor : MonoBehaviour

{
    // Start is called before the first frame update

        private GameObject player;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
}
