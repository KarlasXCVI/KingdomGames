using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public float speed;

    private Transform target;
    private Rigidbody2D enemy;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 5)
        {
            Vector2 velocity = new Vector2((transform.position.x - target.position.x) * speed, (transform.position.y - target.position.y) * speed);
            enemy.velocity = -velocity;
        }
    }
}
