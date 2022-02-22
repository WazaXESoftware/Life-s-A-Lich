using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seesaw : MonoBehaviour
{
    private Quaternion originalRotationValue;
    public float rotationSpeed = 1f;
    public bool rotating;

    void Start()
    {
        originalRotationValue = transform.rotation;
    }

    private void Update()
    {
        if (rotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, originalRotationValue, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject)
        {
            rotating = true;
        }
    }
}
