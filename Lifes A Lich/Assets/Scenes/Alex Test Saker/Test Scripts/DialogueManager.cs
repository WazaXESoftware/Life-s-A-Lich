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

    public GameObject mortImage;
    public GameObject slimeImage;
    public GameObject skeletonImage;

    public GameObject dialogueBox;

    public bool GameIsPaused = false;

    public Queue<string> names;
    public Queue<string> sentences;

    private EventHandler eventHandler;
    void Start()
    {
        eventHandler = FindObjectOfType<EventHandler>();
        names = new Queue<string>();
        sentences = new Queue<string>();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        if(eventHandler != null)
        {
            eventHandler.onFreeze();
        }
        

        dialogueBox.SetActive(true);

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

    private void Update()
    {
        if (!GameIsPaused)
        {
            if (Input.GetButtonDown("Jump"))
            {
                DisplayNextSentence();
            }
        }
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

        CharacterImage();
    }

    public void CharacterImage()
    {
        if (nameText.text == "Mort")
        {
            ShowMortImage();
        }
        else if(nameText.text == "Slime")
        {
            ShowSlimeImage();
        }
        else if (nameText.text == "Skeleton")
        {
            ShowSkeletonImage();
        }
    }

    public void ShowMortImage()
    {
        mortImage.SetActive(true);
        slimeImage.SetActive(false);
        skeletonImage.SetActive(false);
    }

    public void ShowSlimeImage()
    {
        mortImage.SetActive(false);
        slimeImage.SetActive(true);
        skeletonImage.SetActive(false);
    }

    public void ShowSkeletonImage()
    {
        mortImage.SetActive(false);
        slimeImage.SetActive(false);
        skeletonImage.SetActive(true);
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        eventHandler.onUnFreeze();
    }
}
