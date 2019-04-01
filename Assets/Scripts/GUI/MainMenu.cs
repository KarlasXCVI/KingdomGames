using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject MainMenuCanvas;
    public GameObject OptionsMenuCanvas;
    public GameObject HelpMenuCanvas;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Continue()
    {
        //this.MainMenuCanvas.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Option()
    {
        this.MainMenuCanvas.SetActive(false);
        this.OptionsMenuCanvas.SetActive(true);
    }

    public void Help()
    {
        this.MainMenuCanvas.SetActive(false);
        this.HelpMenuCanvas.SetActive(true);
    }

    public void Exit()
    {
        this.MainMenuCanvas.SetActive(false);
        Application.Quit();
    }

}
