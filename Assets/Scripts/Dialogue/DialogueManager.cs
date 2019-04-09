﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    private Queue<string> sentences;


    void Awake()
    {

    }

	// Use this for initialization
	void Start () {

        sentences = new Queue<string>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Time.timeScale = 1;
    }


    void Find()
    {
        if ((nameText == null))
        {
            nameText = GameObject.Find("Name").GetComponent<Text>();
        }
        if ((dialogueText == null))
        {
            dialogueText = GameObject.Find("Dialogue").GetComponent<Text>();
        }
    }
}
