using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    private int lives;
    private Player PlayerRef;

    public GameObject HealthBar1;
    public GameObject HealthBar2;
    public GameObject HealthBar3;
    public GameObject HealthBar4;
    public GameObject HealthBar5;

    private void Awake()
    {
        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
        }

        FindHearts();
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

        // if the player lives equals or less than 4, hide the 5th heart
        if (lives <= 4)
        {
            this.HealthBar5.SetActive(false);
        }
        else
        {
            // higher than 4, show the 5th heart
            this.HealthBar5.SetActive(true);
        }

        // if the player lives equals or less than 3, hide the 4th heart
        if (lives <= 3)
        {
            this.HealthBar4.SetActive(false);
        }
        else
        {
            // higher than 3, show the 4th heart
            this.HealthBar4.SetActive(true);
        }

        // if the player lives equals or less than 2, hide the 3rd heart
        if (lives <= 2)
        {
            this.HealthBar3.SetActive(false);
        }
        else
        {
            // higher than 2, show the 3rd heart
            this.HealthBar3.SetActive(true);
        }

        // if the player lives equals or less than 1, hide the 2nd heart
        if (lives <= 1)
        {
            this.HealthBar2.SetActive(false);
        }
        else
        {
            // higher than 1, show the 2nd heart
            this.HealthBar2.SetActive(true);
        }

        // if the player lives equals to 0, hide the 1st heart
        if (lives == 0)
        {
            this.HealthBar1.SetActive(false);
        }
        else
        {
            // higher than 0, show the 1st heart
            this.HealthBar1.SetActive(true);
        }
    }

    void FindHearts()
    {
        if ((HealthBar1 == null))
        {
            HealthBar1 = GameObject.Find("Heart 1");
        }
        if ((HealthBar2 == null))
        {
            HealthBar2 = GameObject.Find("Heart 2");
        }
        if ((HealthBar3 == null))
        {
            HealthBar3 = GameObject.Find("Heart 3");
        }
        if ((HealthBar4 == null))
        {
            HealthBar4 = GameObject.Find("Heart 4");
        }
          if ((HealthBar5 == null))
        {
            HealthBar5 = GameObject.Find("Heart 5");
        }
    }
}
