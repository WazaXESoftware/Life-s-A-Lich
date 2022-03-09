using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

  float step = 0.01f;

  var cameraPosition = Camera.main.gameObject.transform.position;
  cameraPosition.x += step;
  Camera.main.gameObject.transform.position = cameraPosition;

    }
}
