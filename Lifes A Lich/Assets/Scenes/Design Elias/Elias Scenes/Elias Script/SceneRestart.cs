using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class SceneRestart : MonoBehaviour
{
    public StudioEventEmitter slutMusik;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
      SceneManager.LoadScene(4);
        slutMusik.SetParameter("Parameter 1", 1);
        slutMusik.Stop();
    }
}
