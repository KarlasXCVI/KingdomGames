using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {


    public Transform shootingPointL;
    public GameObject bulletPab;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // enter trigger zone of something
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerRef")
        {
            shoot();
        }

        if (other.gameObject.tag == "EnemyBullet")
        {

        }
    }

    void shoot()
    {
        Instantiate(bulletPab, shootingPointL.position, shootingPointL.rotation);
    }
}
