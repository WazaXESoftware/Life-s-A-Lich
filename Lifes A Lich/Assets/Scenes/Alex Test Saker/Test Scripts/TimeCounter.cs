using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public float timer = 0f;
    public bool timerStopped = false;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (!timerStopped)
        {
            timer += Time.deltaTime;
        }
    }
}
