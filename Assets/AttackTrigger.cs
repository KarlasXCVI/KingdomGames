using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int sword = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" )
        {
           other.gameObject.SendMessageUpwards("Damage", sword);
        }
    }


}
