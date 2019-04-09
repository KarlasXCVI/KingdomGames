using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bullet : MonoBehaviour {

    public float speed;
    public int damage;
    public float lifetime = 3.0f;

    public Rigidbody2D rb;
    private Player PlayerRef;

    private void Awake()
    {
        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
        }

        if ((rb == null))
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PlayerRef.Ishurt == false)
            {
                PlayerRef.Currenthealth--;
                Destroy(this.gameObject);
                PlayerRef.Ishurt = true;
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
