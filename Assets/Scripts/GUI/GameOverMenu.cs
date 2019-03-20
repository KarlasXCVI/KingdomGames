using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour {


    public GameObject GameOverCanvas;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }

    public void Gameover()
    {
        this.GameOverCanvas.SetActive(true);

    }

    public void Retry()
    {
        this.GameOverCanvas.SetActive(false);
        
    }

    public void Exit()
    {
        this.GameOverCanvas.SetActive(false);
        SceneManager.LoadScene(0);
    }


}
