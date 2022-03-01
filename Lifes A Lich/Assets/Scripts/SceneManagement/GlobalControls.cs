using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalControls : MonoBehaviour
{
    /**
    private List<Entity3> entities = new List<Entity3>();

    private void Start()
    {
        entities = new List<Entity3>(FindObjectsOfType<Entity3>());
    }
    
    **/
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Insert))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    /**
    public void Freeze()
    {
        foreach (Entity3 entity in entities)
        {
            entity.frozen = true;
        }
    }

    public void UnFreeze()
    {
        foreach (Entity3 entity in entities)
        {
            entity.frozen = false;
        }
    }
    **/
}
