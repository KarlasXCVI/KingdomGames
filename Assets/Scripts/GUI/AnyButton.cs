using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyButton : MonoBehaviour {

    public Animator BlinkingAnimator;

    // Use this for initialization
    void Start () {
        BlinkingAnimator.SetBool("IsPressed", false);
    }

    // Update is called once per frame
    void Update () {

        if (Input.anyKeyDown)
        {
            Pressed();
        }
	}

    void Pressed()
    {
        BlinkingAnimator.SetBool("IsPressed", true);
        Invoke("LoadMainMenu", 3);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
