using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBox : MonoBehaviour {

public GameObject Player;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player )
        {
            Player.transform.parent = transform;
        }
  }

  private void OnTriggerExit(Collider other)
  {
      if (other.gameObject == Player)
      {
          Player.transform.parent = null;
        }
  }
}
