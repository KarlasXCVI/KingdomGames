using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    private bool collected;
    public Player PlayerRef;
    public AudioClip DoorSound;

    public Transform TeleportGoal;
    public Transform Player;

    void Awake()
    {
        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
        }

        if ((TeleportGoal == null))
        {
            TeleportGoal = GameObject.FindWithTag("RespawnPoint").transform;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && collected == false)
        {
            PlayerRef.notificationtext.text = "Must collect key first";

        } else if (other.gameObject.tag == "Player" && collected == true)
        {
            PlayerRef.notificationtext.text = "Press E to the key to open the door";
            Player.position = TeleportGoal.position;
            collected = false;
            PlayerRef.CollectedKey = false;

            if (Input.GetKeyDown(KeyCode.E))
            {
                collected = false;
                Player.position = TeleportGoal.position;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerRef.UpdateBlankText();
        }
    }
}
