using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour {

    public GameObject HelpMenuCanvas;
    public GameObject MainMenuButtonsContainer;
    public GameObject PausedMenuCanvas;

    public GameObject CoinHelpCanvas;
    public GameObject EnemeyHelpCanvas;
    public GameObject HealthHelpCanvas;
    public GameObject BossHelpCanvas;
    public GameObject DKHelpCanvas;
    public GameObject FireHelpCanvas;

    public int pagenumber;


    // Use this for initialization
    public void Start()
    {
        pagenumber = 1;

        //turn on help menu
        this.HelpMenuCanvas.SetActive(true);
        //turn off main menu menu
        this.MainMenuButtonsContainer.SetActive(false);
    }

    // The BacktoMainMenu function is activate when the exit button is pressed in the main menu scene
    public void BacktoMainMenu()
    {
        //turn off help menu
        this.HelpMenuCanvas.SetActive(false);
        //turn on main menu menu
        this.MainMenuButtonsContainer.SetActive(true);
    }

    // The BacktoPausedMenu function is activate when the exit button is pressed in the game scene
    public void BacktoPausedMenu()
    {
        //turn off help menu menu
        this.HelpMenuCanvas.SetActive(false);
        //turn on pause menu menu
        this.PausedMenuCanvas.SetActive(true);
    }

    // The NextButton function is activate when the Next button is pressed in the help menu
    public void NextButton()
    {
        if (pagenumber >= 1 && pagenumber <=5)
        {
            // increase page number by one
            pagenumber++;
        }

        switch(pagenumber)
        {
            // if pagenumber equals 1, case 1 is used
            case 1:
                //turn on pause menu menu
                this.CoinHelpCanvas.SetActive(true);
                break;
            // if pagenumber equals 2, case 2 is used
            case 2:
                //turn on pause menu menu
                this.CoinHelpCanvas.SetActive(false);
                //turn on pause menu menu
                this.EnemeyHelpCanvas.SetActive(true);
                break;
            // if pagenumber equals 3, case 3 is used
            case 3:
                //turn on pause menu menu
                this.EnemeyHelpCanvas.SetActive(false);
                //turn on pause menu menu
                this.HealthHelpCanvas.SetActive(true);
                break;
            // if pagenumber equals 4, case 4 is used
            case 4:
                //turn on pause menu menu
                this.HealthHelpCanvas.SetActive(false);
                //turn on pause menu menu
                this.BossHelpCanvas.SetActive(true);
                break;
            // if pagenumber equals 5, case 5 is used
            case 5:
                //turn on pause menu menu
                this.BossHelpCanvas.SetActive(false);
                //turn on pause menu menu
                this.DKHelpCanvas.SetActive(true);
                break;
            // if pagenumber equals 6, case 6 is used
            case 6:
                //turn on pause menu menu
                this.DKHelpCanvas.SetActive(false);
                //turn on pause menu menu
                this.FireHelpCanvas.SetActive(true);
                break;
        }
    }

    // The PreviousButton function is activate when the Previous button is pressed in the help menu
    public void PreviousButton()
    {
        // if the page number equals or less than 1, hide the 2nd heart
        if (pagenumber >= 1)
        {
            // decrease page number by one
            pagenumber--;
        }

        switch (pagenumber)
        {
            // if pagenumber equals 1, case 1 is used
            case 1:
                //turn on pause menu menu
                this.CoinHelpCanvas.SetActive(true);
                //turn on pause menu menu
                this.EnemeyHelpCanvas.SetActive(false);
                break;
            // if pagenumber equals 2, case 2 is used
            case 2:
                //turn on pause menu menu
                this.EnemeyHelpCanvas.SetActive(true);
                //turn on pause menu menu
                this.HealthHelpCanvas.SetActive(false);
                break;
            // if pagenumber equals 3, case 3 is used
            case 3:
                //turn on pause menu menu
                this.HealthHelpCanvas.SetActive(true);
                //turn on pause menu menu
                this.BossHelpCanvas.SetActive(false);
                break;
            // if pagenumber equals 4, case 4 is used
            case 4:
                //turn on pause menu menu
                this.BossHelpCanvas.SetActive(true);
                //turn on pause menu menu
                this.DKHelpCanvas.SetActive(false);
                break;
            // if pagenumber equals 5, case 5 is used
            case 5:
                //turn on pause menu menu
                this.DKHelpCanvas.SetActive(true);
                //turn on pause menu menu
                this.FireHelpCanvas.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
