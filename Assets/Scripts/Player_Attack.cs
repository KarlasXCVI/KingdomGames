using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    private float delayAttack;
    public float delay;

    public Animator player_Animator;

    public Transform pos;

    public float range;

    public LayerMask enemyLayer;

    public int dmg;

    // Update is called once per frame
    void Update()
    {
        if(delayAttack <= 0)
        {
            if(Input.GetKey(KeyCode.J))
            {
                player_Animator.SetTrigger("Attack");

                Collider2D[] enemies = Physics2D.OverlapCircleAll(pos.position, range, enemyLayer);
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<Enemy_Health>().DropHealth(dmg);
                }
            }

            delayAttack = delay;
        }
        else
        {
            delayAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pos.position, range);
    }
}
