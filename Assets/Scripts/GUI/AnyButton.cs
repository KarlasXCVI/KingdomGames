using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.anyKeyDown)
        {
            Invoke("LoadMainMenu", 5);
        }
		
	}

    void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
