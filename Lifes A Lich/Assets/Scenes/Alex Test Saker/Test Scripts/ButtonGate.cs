using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonGate : MonoBehaviour
{
    public List<GameObject> characters;
    private soundfxmanager sfxmanager;
    public GameObject gate;
    public float speedUp = 3f;
    public float speedDown = 4f;
    public bool buttonPushed;
    private bool doorSoundPlayed;
    private float minHeight;
    public float maxHeight;

    private void Start()
    {
        List<Entity3> entities = new List<Entity3>(FindObjectsOfType<Entity3>());
        foreach (Entity3 entity in entities)
        {
            characters.Add(entity.gameObject);
        }

        sfxmanager = FindObjectOfType<soundfxmanager>();
        if(sfxmanager == null)
        {
            Debug.LogWarning("Warning, scene is missing an SFX Manager");
        }

        minHeight = gate.transform.position.y;
    }
    void Update()
    {
        if (buttonPushed && gate.transform.position.y < minHeight + maxHeight)
        {
            moveUp();
            if (doorSoundPlayed)
            {
                sfxmanager.interactableAudio.DoorEvent(gameObject);
                doorSoundPlayed = false;
            }
            
        }
        else if(buttonPushed == false && gate.transform.position.y > minHeight)
        {
            moveDown();
        }
    }

    private void moveUp()
    {
        gate.transform.Translate(Vector3.up * speedUp * Time.deltaTime);
        doorSoundPlayed = true;
    }

    private void moveDown()
    {
        gate.transform.Translate(Vector3.down * speedDown * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (characters.Contains(other.gameObject))
        {
            buttonPushed = true;
            sfxmanager.interactableAudio.ButtonEvent(gameObject);
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
