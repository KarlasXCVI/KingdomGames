using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    private float delayAttack;
    public float delay;

    public Transform pos;

    public float range;

    public LayerMask PlayerLayer;

    public int dmg;

    // Update is called once per frame
    void Update()
    {
        if (delayAttack <= 0)
        {
                Collider2D[] player = Physics2D.OverlapCircleAll(pos.position, range, PlayerLayer);
                for (int i = 0; i < player.Length; i++)
                {
                    player[i].GetComponent<Player_Health>().DropHealth(dmg);
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos.position, range);
    }
}
