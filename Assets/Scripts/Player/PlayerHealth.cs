using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    private int lives;

    public GameObject HealthBar1;
    public GameObject HealthBar2;
    public GameObject HealthBar3;
    public GameObject HealthBar4;
    public GameObject HealthBar5;

    Player PlayerRef;

    private void Awake()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Use this for initialization
    void Start () {

        Lives();
    }
	
	// Update is called once per frame
	void Update () {

        Lives();
        UpdatingLives();
    }

    void Lives()
    {
        lives = PlayerRef.Currenthealth;
    }

    void UpdatingLives()
    {
        if (lives <= 4)
        {
            this.HealthBar5.SetActive(false);
        }

        if (lives <= 3)
        {
            this.HealthBar4.SetActive(false);
        }

        if (lives <= 2)
        {
            this.HealthBar3.SetActive(false);
        }

        if (lives <= 1)
        {
            this.HealthBar2.SetActive(false);
        }

        if (lives == 0)
        {
            this.HealthBar1.SetActive(false);
        }
    }
}
