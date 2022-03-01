using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class EventHandler : MonoBehaviour
{
    public UnityAction onFreeze = delegate { };
    public UnityAction onUnFreeze = delegate { };
}
