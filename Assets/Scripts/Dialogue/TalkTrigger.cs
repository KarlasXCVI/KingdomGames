using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}


    // enter trigger zone of something
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

        }

        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {

            }
        }

    }
}
