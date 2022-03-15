using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class SceneTrigger3 : MonoBehaviour
{
    public Animator animator;
    private int levelToLoade;
    
    public AudioSource signOffSound;
    private Animator anim;
    private int levelLoad;
    // Start is called before the first frame update


    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FadeLevel(+1);
            
        }

    }

    public void FadeLevel(int levelIndex)
    {
        levelLoad = levelIndex;
        animator.SetTrigger("Fadeee");
    }

    public void OnFadeDone()
    {
        SceneManager.LoadScene("MainEnding");
    }
}
