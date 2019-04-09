using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public CharacterController2D controller;
    public Animator animator;

    float horizontalMove = 0f;

    public float runSpeed = 40f;

    bool jump = false;

    private float canJump = 0f;

    //bool attack = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && Time.time > canJump)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            canJump = Time.time + 0.5f;
        }

        /*if(Input.GetButtonDown("Attack"))
        {
            attack = true;
            animator.SetBool("IsAttacking", true);
        } else if(Input.GetButtonUp("Attack"))
        {
            attack = false;
        }*/


    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        

        jump = false;
        




    }
}
