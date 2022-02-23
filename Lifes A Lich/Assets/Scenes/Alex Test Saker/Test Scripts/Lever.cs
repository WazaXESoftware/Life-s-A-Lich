using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractableObject
{
    public GameObject door;
    public float speedUp = 3f;
    public float speedDown = 4f;
    private float minHeight;
    public float maxHeight;
    public bool leverPulled;
    void Start()
    {
        minHeight = door.transform.position.y;
    }

    public override void Interact()
    {
        leverPulled = !leverPulled;
    }
    void Update()
    {
        if(leverPulled && door.transform.position.y < minHeight + maxHeight)
        {
            moveUp();
        }
        else if (leverPulled == false && door.transform.position.y > minHeight)
        {
            moveDown();
        }
    }

    private void moveUp()
    {
        door.transform.Translate(Vector3.up * speedUp * Time.deltaTime);
    }

    private void moveDown()
    {
        door.transform.Translate(Vector3.down * speedDown * Time.deltaTime);
    }
}
