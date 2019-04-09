using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject OptionsMenuCanvas;
    public GameObject MainMenuButtonsContainer;
    public GameObject PausedMenuCanvas;

    // Use this for initialization
    public void Start ()
    {

        this.OptionsMenuCanvas.SetActive(true);
        this.MainMenuButtonsContainer.SetActive(false);
    }

    // The BacktoMainMenu function is activate when the exit button is pressed in the main menu scene
    public void BacktoMainMenu()
    {
        //turn off Options menu
        this.OptionsMenuCanvas.SetActive(false);
        //turn on main menu menu
        this.MainMenuButtonsContainer.SetActive(true);
    }

    // The BacktoPausedMenu function is activate when the exit button is pressed in the game scene
    public void BacktoPausedMenu()
    {
        //turn off help menu menu
        this.OptionsMenuCanvas.SetActive(false);
        //turn on pause menu menu
        this.PausedMenuCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
