using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {


    public Dialogue dialogue;
    public bool activated;


    // Use this for initialization
    void Start()
    {
        activated = false;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && activated == false)
        {
            activated = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
