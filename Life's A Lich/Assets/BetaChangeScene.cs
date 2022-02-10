using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetaChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LoadNextScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("MainTutorial");
        }
    }
}
