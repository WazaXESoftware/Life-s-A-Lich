using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
      SceneManager.LoadScene(4);
    }
}
