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


    public void BacktoMainMenu()
    {
        this.OptionsMenuCanvas.SetActive(false);
        this.MainMenuButtonsContainer.SetActive(true);
    }

    public void BacktoPausedMenu()
    {
        this.OptionsMenuCanvas.SetActive(false);
        this.PausedMenuCanvas.SetActive(true);
    }



    // Update is called once per frame
    void Update () {
		
	}
}
