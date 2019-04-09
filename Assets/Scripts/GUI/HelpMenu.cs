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


    public void BacktoMainMenu()
    {
        //turn off help menu
        this.HelpMenuCanvas.SetActive(false);
        //turn on main menu menu
        this.MainMenuButtonsContainer.SetActive(true);
    }

    public void BacktoPausedMenu()
    {
        //turn off help menu menu
        this.HelpMenuCanvas.SetActive(false);
        //turn on pause menu menu
        this.PausedMenuCanvas.SetActive(true);
    }

    public void NextButton()
    {
        if (pagenumber >= 1 && pagenumber <=2)
        {
            pagenumber++;
        }

        switch(pagenumber)
        {

            case 1:
                //turn on pause menu menu
                this.CoinHelpCanvas.SetActive(true);
                break;
            case 2:
                //turn on pause menu menu
                this.CoinHelpCanvas.SetActive(false);
                //turn on pause menu menu
                this.EnemeyHelpCanvas.SetActive(true);
                break;
            case 3:
                //turn on pause menu menu
                this.EnemeyHelpCanvas.SetActive(false);
                //turn on pause menu menu
                this.HealthHelpCanvas.SetActive(true);
                break;
        }
    }

    public void PreviousButton()
    {
        if (pagenumber >= 1)
        {
            pagenumber--;
        }

        switch (pagenumber)
        {

            case 1:
                //turn on pause menu menu
                this.CoinHelpCanvas.SetActive(true);
                //turn on pause menu menu
                this.EnemeyHelpCanvas.SetActive(false);
                break;
            case 2:
                ////turn on pause menu menu
                //this.CoinHelpCanvas.SetActive(true);
                ////turn on pause menu menu
                //this.EnemeyHelpCanvas.SetActive(false);

                //turn on pause menu menu
                this.EnemeyHelpCanvas.SetActive(true);
                //turn on pause menu menu
                this.HealthHelpCanvas.SetActive(false);
                break;
            //case 3:
            //    //turn on pause menu menu
            //    this.EnemeyHelpCanvas.SetActive(true);
            //    //turn on pause menu menu
            //    this.HealthHelpCanvas.SetActive(false);
            //    break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
