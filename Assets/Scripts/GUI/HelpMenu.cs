using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour {

    public GameObject HelpMenuCanvas;
    public GameObject MainMenuButtonsContainer;
    public GameObject PausedMenuCanvas;


    // Use this for initialization
    public void Start()
    {
        this.HelpMenuCanvas.SetActive(true);
        this.MainMenuButtonsContainer.SetActive(false);
    }


    public void BacktoMainMenu()
    {
        this.HelpMenuCanvas.SetActive(false);
        this.MainMenuButtonsContainer.SetActive(true);
    }

    public void BacktoPausedMenu()
    {
        this.HelpMenuCanvas.SetActive(false);
        this.PausedMenuCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
