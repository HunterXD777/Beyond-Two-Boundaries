using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    public Animator animator;

    Rigidbody2D rb;

    public float speed;
    public float jumpForce;

    public float fallMultiplier = 2.5f;

    public bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    //Jane's codes
    public bool PlayerFacingRight = true;  // For determining which way the player is currently facing.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {

        Move();
        BetterJump();
        Jump();
        CheckIfGrounded();
        Interact(); //Jane's codes
    }


    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;

        //Jane's codes
        //Debug.Log("moveBy is " + moveBy); //testing

        rb.velocity = new Vector2(moveBy, rb.velocity.y);



        //Jane's codes
        animator.SetFloat("Speed", Mathf.Abs(moveBy)); //set animator's speed as the speed of the player, use math absolute so its always positive and is not affected when player move to the left that creates a negative value

        if (moveBy > 0 && !PlayerFacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (moveBy < 0 && PlayerFacingRight)
        {
            // ... flip the player.
            Flip();
        }

        //if (Mathf.Abs(moveBy) > 0)
        //{
        //    FindObjectOfType<SoundManager>().Play("PlayerFootsteps"); //play footsteps sound effect
        //}
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;

            animator.SetBool("IsJumping", false); //when player is grounded meaning player is not jumping yet therefore set animator's isjumping to false
        }
        else
        {
            isGrounded = false;

            animator.SetBool("IsJumping", true); //when player is not grounded meaning the player is jumping therefore animator's isjumping is set to true
        }
    }

    void Flip() //Jane's codes
    {
        PlayerFacingRight = !PlayerFacingRight; //switch the way the player is labelled as facing
        transform.Rotate(0f, 180f, 0f);
    }

    void Interact() //Jane's codes
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            animator.SetBool("IsInteracting", true);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("IsInteracting", false);
        }
    }
}
