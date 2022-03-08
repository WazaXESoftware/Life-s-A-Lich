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

        [EventRef]
        public string doorEvent;

        [EventRef]
        public string platforminEvent;

        [EventRef]
        public string platformoutEvent;

        public void ButtonEvent(GameObject audioObject)
        {
            RuntimeManager.PlayOneShotAttached(buttonEvent, audioObject);
        }
        public void DoorEvent(GameObject audioObject)
        {
            RuntimeManager.PlayOneShotAttached(doorEvent, audioObject);
        }
        public void PlatforminEvent(GameObject audioObject)
        {
            RuntimeManager.PlayOneShotAttached(platforminEvent, audioObject);
        }
        public void PlatformoutEvent(GameObject audioObject)
        {
            RuntimeManager.PlayOneShotAttached(platformoutEvent, audioObject);
        }
    }


    [Serializable]
    public class CharacterAudio
    {
        [EventRef]
        public string slimeStretch;

        [EventRef]
        public string slimeJump;

        [EventRef]
        public string slimeTransfer;

        [EventRef]
        public string skeletonTransfer;

        [EventRef]
        public string skeletonJump;

        [EventRef]
        public string skeletonImpact;


        public void SlimeStretch(GameObject audioObject)
        {
            RuntimeManager.PlayOneShotAttached(slimeStretch, audioObject);
        }
        public void SlimeTransfer(GameObject audioObject)
        {
            RuntimeManager.PlayOneShotAttached(slimeTransfer, audioObject);
        }
        public void SkeletonTransfer(GameObject audioObject)
        {
            RuntimeManager.PlayOneShotAttached(skeletonTransfer, audioObject);
        }
        public void SlimeJump(GameObject audioObject)
        {
            RuntimeManager.PlayOneShotAttached(skeletonTransfer, audioObject);
        }
        public void SkeletonJump(GameObject audioObject)
        {
            RuntimeManager.PlayOneShotAttached(skeletonJump, audioObject);
        }
        public void SkeletonImpact(GameObject audioObject)
        {
            RuntimeManager.PlayOneShotAttached(skeletonImpact, audioObject);
        }
    }


    public InteractableAudio interactableAudio;
    public CharacterAudio characterAudio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
