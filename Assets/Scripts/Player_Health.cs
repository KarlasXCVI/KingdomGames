using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public int hp;

    public GameObject particle;

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DropHealth(int dmg)
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        hp -= dmg;
        //Debug.Log("I am taking it");
    }
}
