using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FMOD.Studio;
using FMODUnity;

public class soundfxmanager : MonoBehaviour
{
    [Serializable]
    public class InteractableAudio
    {
        [EventRef]
        public string buttonEvent;



        public void ButtonEvent(GameObject audioObject)
        {
            RuntimeManager.PlayOneShotAttached(buttonEvent, audioObject);
        }
    }

    public InteractableAudio interactableAudio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
