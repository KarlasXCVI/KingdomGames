using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    public float speed;
    public int damage;
    public float lifetime = 3.0f;

    public Rigidbody2D rb;
    Player PlayerRef;
    BossAI Boss;
    BasicAI Enemy;

    // Use this for initialization
    void Start () {

        speed = 10f;
        rb.velocity = transform.right * speed;
        PlayerRef = GameObject.FindGameObjectWithTag("Player").GetComponent <Player>();
    }
	
	// Update is called once per frame
	void Update () {

        damage = PlayerRef.AttackDamage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BossAI Boss = other.GetComponent<BossAI>();
        BasicAI Enemy = other.GetComponent<BasicAI>();

        if (other.gameObject.tag == "Boss")
        {
            Boss.takedamage(damage);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Enemy.takedamage(damage);
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
