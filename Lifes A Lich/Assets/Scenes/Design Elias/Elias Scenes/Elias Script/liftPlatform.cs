using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class liftPlatform : MonoBehaviour
{
    public List<GameObject> characters;
    public GameObject platform;
    public GameObject platform2;
    public float speedUp = 3f;
    public float speedDown = 4f;
    public bool onPlatform;
    public float minHeight;
    public float maxHeight;

    private void Start()
    {
        List<Entity3> entities = new List<Entity3>(FindObjectsOfType<Entity3>());
        foreach (Entity3 entity in entities)
        {
            characters.Add(entity.gameObject);
        }

    }

    void Update()
    {
        if (onPlatform && platform.transform.position.y >= minHeight)
        {
            moveDown();
            moveOtherUp();

        }
        else if (onPlatform == false && platform.transform.position.y <= maxHeight)
        {
            moveUp();
            moveOtherDown();
        }
    }

    private void moveUp()
    {
        platform.transform.Translate(Vector3.up * speedUp * Time.deltaTime);
    }

    private void moveDown()
    {
        platform.transform.Translate(Vector3.down * speedDown * Time.deltaTime);
    }

    private void moveOtherUp()
    {
        platform2.transform.Translate(Vector3.up * speedUp * Time.deltaTime);
    }

    private void moveOtherDown()
    {
        platform2.transform.Translate(Vector3.down * speedDown * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (characters.Contains(other.gameObject))
        {
            onPlatform = true;
            GetComponent<Collider>().transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (characters.Contains(other.gameObject))
        {
            onPlatform = false;
        }
    }
}
