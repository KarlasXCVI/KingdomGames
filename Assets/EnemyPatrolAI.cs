﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolAI : MonoBehaviour {

    public float speed;

    public bool Moveright;

    void Update()
    {
        if (Moveright)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(2, 2);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-2, 2);
        }

        
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {
            if (Moveright)
            {
                Moveright = false;
            }
            else
            {
                Moveright = true;
            }
        }
    }
}
