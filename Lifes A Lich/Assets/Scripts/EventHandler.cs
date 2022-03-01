using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public event Action OnFreeze;
    public event Action OnUnFreeze;
}
