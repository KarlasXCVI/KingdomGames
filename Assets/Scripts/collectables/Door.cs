using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private bool collected;
    public Player PlayerRef;
    public AudioClip DoorSound;

    public Transform TeleportGoal;
    public Transform Player;

    public GameObject YouWinMenuCanvas;

    void Awake()
    {
        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
        }

        if ((TeleportGoal == null))
        {
            TeleportGoal = GameObject.FindWithTag("RespawnNextLevel").transform;
        }

        if ((Player == null))
        {
            Player = GameObject.FindWithTag("PlayerRef").transform;
        }
    }

    // Use this for initialization
    void Start () {
        collected = PlayerRef.CollectedKey;

    }
	
	// Update is called once per frame
	void Update () {
        collected = PlayerRef.CollectedKey;
    }

    // enter trigger zone of the door
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && PlayerRef.CollectedKey == false)
        {
            // notification text
            PlayerRef.notificationtext.text = "Must collect key first";

        } else if (other.gameObject.tag == "Player" && PlayerRef.CollectedKey == true)
        {
            // notification text
            PlayerRef.notificationtext.text = "Press E to the key to open the door";
            // Teleports the player to a different location 
            Player.position = TeleportGoal.position;
            // player used key, and no longer has a key so CollectedKey is false
            PlayerRef.CollectedKey = false;
            // actives the Finish funcation after one second
            Invoke("Finish", 1);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerRef.UpdateBlankText();
        }
    }


    void Finish()
    {
        // pauses the game
        Time.timeScale = 0;
        // show the you win menu
        YouWinMenuCanvas.SetActive(true);
    }
}
