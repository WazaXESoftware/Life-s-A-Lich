using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MusicObject", order = 1)]
public class MusicObject : ScriptableObject
{
    public StudioEventEmitter emitter;

    public void Play()
    {
        emitter.Play();
    }

    public void Stop()
    {
        emitter.Stop();
    }
}
