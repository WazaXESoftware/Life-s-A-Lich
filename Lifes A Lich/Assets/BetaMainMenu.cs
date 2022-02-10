using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetaMainMenu : MonoBehaviour
{
    public Animator animator;



    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()

    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
