using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField]
    private float timeBtwAttack;
    public float starttimeBTAttack;
    public float attackRange;
    public bool left;
    public bool right;


    public Transform shootingPoint;
    public GameObject bulletPab;

    // Use this for initialization
    void Start () {
        left = false;
        right = true;

        starttimeBTAttack = 2;

        //if (timeBtwAttack <= 0)
        //{
        //    if (Input.GetKey(KeyCode.Y))
        //    {
        //        Collider2D[] enemiestodamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, 0);
        //    }
        //    timeBtwAttack = starttimeBTAttack;
        //}
        //else
        //{
        //    timeBtwAttack -= Time.deltaTime;
        //}

    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            shoot();
        }


        if (left == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                left = true;
                right = false;
                shootingPoint.transform.Rotate(0f, 180f, 0f);
            }
        }

        
        if (left == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                left = false;
                right = true;
                shootingPoint.transform.Rotate(0f, 180f, 0f);
            }
        }



        //if (timeBtwAttack <= 0)
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        shoot();
        //    }

        //    timeBtwAttack = starttimeBTAttack;
        //}
        //else
        //{
        //    timeBtwAttack -= Time.deltaTime;
        //}
    }

    void shoot()
    {
        Instantiate(bulletPab, shootingPoint.position, shootingPoint.rotation);
    }

}
