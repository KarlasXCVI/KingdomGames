using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    private bool collected;
    private Player PlayerRef;

    public AudioClip KeyCollectSound;

    // Use this for initialization
    void Start () {

        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // enter trigger zone of the key
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // player collects key, so the key icon will appear on screen 
            PlayerRef.CollectedKey = true;
            //play audio
            GetComponent<AudioSource>().PlayOneShot(KeyCollectSound);
            // destroy key object
            Destroy(this.gameObject);
        }
    }
}
