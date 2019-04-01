using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    public bool collected;
    Player PlayerRef;

    public AudioClip CoinCollectSound;

    // Use this for initialization
    void Start () {
        collected = false;
        PlayerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update () {

        if (collected == true)
        {
            // Move the object upward in world space 1 unit/second.
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
            //transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
        }
    }

    // enter trigger zone of something
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && collected == false)
        {
            collected = true;
            PlayerRef.score++;
            //GetComponent<AudioSource>().PlayOneShot(CoinCollectSound);
            Destroy(this.gameObject,2);
        }
    }
}
