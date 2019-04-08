using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour {

    public GameObject GameOverCanvas;
    public Transform respawnPoint;
    public Transform Player;
    public AudioClip RespawnSound;
    private Player PlayerRef;

    // Use this for initialization
    void Start () {

        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
        }

        if ((Player == null))
        {
            Player = GameObject.FindWithTag("PlayerRef").transform;
        }

        if ((respawnPoint == null))
        {
            respawnPoint = GameObject.FindWithTag("RespawnPoint").transform;
        }
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
        //Invoke("respawn", 2);
        this.GameOverCanvas.SetActive(false);
        //GameManager.Create(this);
        Time.timeScale = 1f;
        //SceneManager.LoadScene(2);
        PlayerRef.Currenthealth = 3;
        Player.position = respawnPoint.position;
        // play audio
        //GetComponent<AudioSource>().PlayOneShot(RespawnSound);
    }

    public void Exit()
    {
        this.GameOverCanvas.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    private void respawn()
    {
        this.GameOverCanvas.SetActive(false);
        //GameManager.Create(this);
        Time.timeScale = 1f;
        //SceneManager.LoadScene(2);
        PlayerRef.Currenthealth = 3;
        Player.position = respawnPoint.position;
    }

}
