using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = GlobalVariables.isMenuOpen ? horizontalMove : Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        

        if (Input.GetButtonDown("Jump") && !GlobalVariables.isMenuOpen)
        {
            if (!crouch && controller.CheckCeil())
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
        }

        if (Input.GetButtonDown("Crouch") && !GlobalVariables.isMenuOpen)
        {
            if (controller.m_Grounded)
                crouch = true;
            
        } else if (Input.GetButtonUp("Crouch") && !GlobalVariables.isMenuOpen) {
            crouch = false;
        } 
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", jump);
    }

    public void onCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
