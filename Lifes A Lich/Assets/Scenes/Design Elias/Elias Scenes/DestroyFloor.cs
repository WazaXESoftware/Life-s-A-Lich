using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFloor : MonoBehaviour

{
    // Start is called before the first frame update

        private GameObject player;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
}
