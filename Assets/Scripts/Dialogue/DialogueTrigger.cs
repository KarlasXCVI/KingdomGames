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
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            Invoke("PauseToRead", 1);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            activated = true;
        }
    }

    void PauseToRead()
    {
        Time.timeScale = 0;
    }
}
