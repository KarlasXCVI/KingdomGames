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
    // enter trigger zone of something
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerRef.CollectedKey = true;
            // play audio
            //GetComponent<AudioSource>().PlayOneShot(CoinCollectSound);
            Destroy(this.gameObject);
        }
    }
}
