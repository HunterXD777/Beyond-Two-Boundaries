using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{

    Rigidbody2D rb;

    public float speed;
    public float flySpeed;
    public float jumpForce;

    public float glideForce;
    public float defaultGravity;

    public float fallMultiplier = 2.5f;

    public bool isTouchingDecoy = false;
    public bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = defaultGravity;
        
    }

    
    void Update()
    {
        Move();
        //BetterJump();
        Jump();
        Glide();
        //Fly();
        CheckIfGrounded();
    }


    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jumping");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void Glide()
    {
        if (Input.GetKey(KeyCode.Space) && !isGrounded)
        {
            rb.gravityScale = glideForce;
        }
        else
        {
            rb.gravityScale = defaultGravity;
        }
    }

    void Fly()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, flySpeed) * Time.deltaTime);
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

        if(collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Decoy"))
        {
            isTouchingDecoy = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Decoy"))
        {
            isTouchingDecoy = false;
        }
    }
}
