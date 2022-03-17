using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public DialogueManager dManager;

    public GameObject PauseMenuUI;


    private void OnValidate()
    {
        if (dManager == null) Debug.LogWarning("PauseMenu: Dialogue Manager reference is missing");
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Exit"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

            Cursor.visible = false;

        }

    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        if (dManager != null) dManager.GameIsPaused = false;
        Cursor.visible = false;

    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        if (dManager != null) dManager.GameIsPaused = true;
        Cursor.visible = false;

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu....");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}


