using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    private bool collected;

    private Player PlayerRef;
    public AudioClip CoinCollectSound;

    // Use this for initialization
    void Start () {
        collected = false;

        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update () {

        if (collected == true)
        {
            // Move the object upward in world space 1 unit/second.
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
    }

    // enter trigger zone of the coin
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && collected == false)
        {
            collected = true;
            // increase player score
            PlayerRef.score++;
            // play audio
            GetComponent<AudioSource>().PlayOneShot(CoinCollectSound);
            // destroy coin object
            Destroy(this.gameObject);
        }
    }
}
