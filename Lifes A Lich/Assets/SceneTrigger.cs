using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoade;
    public AudioSource signSound;
    public AudioSource signOffSound;
    private Animator anim;

    // Start is called before the first frame update
    

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("MainTwo");
    }

    
}
