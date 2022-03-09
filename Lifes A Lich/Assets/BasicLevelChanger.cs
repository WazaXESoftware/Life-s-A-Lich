using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class BasicLevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    public StudioEventEmitter emitter;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            FadeToLevel(+1);
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
        emitter.SetParameter("Start game", 1);

    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene("IntroScene");

    }
}
