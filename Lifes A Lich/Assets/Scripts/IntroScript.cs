using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public Animator sceneAnimator;
    public Animator fadeAnimator;
    [SerializeField] public GameObject[] scenes;
    public int sceneIndex = 1;

    [Range(0f, 1f)] public float fadeOutTime = 0.3f;
    [Range(0f, 1f)] public float fadeInTime = 0.3f;

    void Start()
    {
        sceneIndex = 1;
        DisplayScene(sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene()
    {
        StartCoroutine(Transition());
        
    }

    public void DisplayScene(int index)
    {
        sceneIndex = index;
        scenes[index - 1].SetActive(true);
        sceneAnimator.SetTrigger("Scene" + index);
        //IntroMusicManager.Play(index);
        //IntroSoundFXManager.Play(index);
    }

    public void HideScene(int index)
    {
        scenes[index - 1].SetActive(false);
    }

    void ExitIntro()
    {
        SceneManager.LoadScene("MainTutorial");
    }

    IEnumerator Transition()
    {
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(fadeInTime);
        HideScene(sceneIndex);
        sceneIndex++;
        if (sceneIndex > scenes.Length)
        {
            ExitIntro();
        }
        else
        {
            DisplayScene(sceneIndex);
        }
        fadeAnimator.SetTrigger("FadeIn");
    }
}
