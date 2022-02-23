using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

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
        OnFadeComplete();
    }


    public void OnFadeComplete()
    {
        SceneManager.LoadScene("MainTwo");

    }
}
