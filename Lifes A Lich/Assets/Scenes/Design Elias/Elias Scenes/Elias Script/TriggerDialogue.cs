using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
public int deaths = 0;
public GameObject trigger;
    // Start is called before the first frame update
 private void OnTriggerEnter(Collider collider)
    {
        Entity3 collidingEntity;
        if(collider.gameObject.TryGetComponent<Entity3>(out collidingEntity))
        {
            deaths += 1;
        }

        if(deaths == 3){
            trigger.SetActive(true);
        }
    }
}
