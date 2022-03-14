using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Musicmanager : MonoBehaviour
{
    //public StudioEventEmitter emitter;
    public MusicObject mObject;
    // Start is called before the first frame update
    void Start()
    {
        //emitter.Play();
        mObject.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
