using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour {


    public GameObject PausedMenuCanvas;
    public GameObject OptionsMenuCanvas;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Pause()
    {
        // Show Paused Menu Canvas
        this.PausedMenuCanvas.SetActive(true);
        // pause the game
        Time.timeScale = 0f;
    }

    // The Resume function is activate when the resume button is pressed 
    public void Resume()
    {
        // Hide paused Menu Canvas
        this.PausedMenuCanvas.SetActive(false);
        // unpause the game
        Time.timeScale = 1f;
    }

    // The Option function is activate when the Option button is pressed 
    public void Option()
    {
        // Hide Paused Menu Canvas
        this.PausedMenuCanvas.SetActive(false);
        // Show Options Menu Canvas
        this.OptionsMenuCanvas.SetActive(true);
    }

    // The Exit function is activate when the Exit button is pressed 
    public void Exit()
    {
        // Hide Paused Menu Canvas
        this.PausedMenuCanvas.SetActive(false);
        // Load the main main
        SceneManager.LoadScene(1);
    }

}
