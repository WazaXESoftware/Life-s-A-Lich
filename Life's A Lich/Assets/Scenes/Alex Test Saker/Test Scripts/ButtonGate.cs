using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonGate : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject gate;
    public float speed = 3f;
    public bool buttonPushed;
    public float minHeight;
    public float maxHeight;

    private void Start()
    {
        
    }
    void Update()
    {
        if (buttonPushed && gate.transform.position.y < maxHeight )
        {
            moveUp();
        }
        else if(buttonPushed == false && gate.transform.position.y > minHeight)
        {
            moveDown();
        }
    }

    private void moveUp()
    {
        gate.transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void moveDown()
    {
        gate.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (characters.Contains(other.gameObject))
        {
            buttonPushed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (characters.Contains(other.gameObject))
        {
            buttonPushed = false;
        }
    }
}
