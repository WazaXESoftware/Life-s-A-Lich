using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject dialogueBox;

    public static bool GameIsPaused = false;

    public Queue<string> names;
    public Queue<string> sentences;

    //private EventHandler eventHandler;
    void Start()
    {
        //eventHandler = FindObjectOfType<EventHandler>();
        names = new Queue<string>();
        sentences = new Queue<string>();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        //eventHandler.onFreeze();

        dialogueBox.SetActive(true);

        //nameText.text = dialogue.names;

        names.Clear();
        sentences.Clear();

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string name = names.Dequeue();
        nameText.text = name;

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        //eventHandler.onUnFreeze();
    }
}
