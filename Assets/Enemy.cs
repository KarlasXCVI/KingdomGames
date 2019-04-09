using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;

    //public Transform shootingPoint;
    //public GameObject bulletPab;

    private Animator enemyAnim;
    public GameObject bloodEffect;

	// Use this for initialization
	void Start () {
        enemyAnim = GetComponent<Animator>();


        if ((bloodEffect == null))
        {
            bloodEffect = GameObject.FindWithTag("BoosBlood").GetComponent<GameObject>();
        }

    }
	
	// Update is called once per frame
	void Update () {
        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Dead");
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);

	}

    public void Damage(int damage)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("Damage Taken");
    }

    //void shoot()
    //{
    //    Instantiate(bulletPab, shootingPointL.position, shootingPointL.rotation);
    //}
}
