using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;


public class Menymusik : MonoBehaviour
{
    public StudioEventEmitter emitter;
    // Start is called before the first frame update
    void Start()
    {
        emitter.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

   
}
