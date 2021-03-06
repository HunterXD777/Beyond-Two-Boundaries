using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public Animator animator;

    Rigidbody2D rb;

    public float speed;
    public float flySpeed;
    public float jumpForce;

    public float glideForce;
    public float defaultGravity;

    public float fallMultiplier = 2.5f;

    public bool isTouchingDecoy = false;
    public bool isGrounded = false;
    
    public bool enableMove = true;

    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public static bool GhostStatePause;//Kang Rui code

    GameObject pauseMenu;
    
    //Jane's codes
    public bool PlayerFacingRight = true;  // For determining which way the player is currently facing.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = defaultGravity;

        pauseMenu = GameObject.Find("UI").gameObject.transform.Find("PauseSystem").gameObject.transform.Find("PauseMenuSystem").gameObject;
       
    }


    void Update()
    {
        checkPause();
        PauseForSFX();//Kang Rui code
        if (enableMove)
        {
            Move();
            //BetterJump();
            Jump();
            Glide();
            //Fly();
            CheckIfGrounded();
            Interact(); //Jane's codes
            
        }
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
    void checkPause()//Kang Rui code
    {
        
            GameObject Cameracontrol = GameObject.FindWithTag("CameraControl");
            GameObject previewCam = Cameracontrol.transform.Find("Preview Camera").gameObject;
            if (previewCam.GetComponent<PreviewCamera>().playerCam || !previewCam.activeSelf)
            {
                if (pauseMenu.GetComponent<PauseMenu>().gameispaused)
                {
                    enableMove = false;
                }
                else
                {
                    enableMove = true;
                }

            }        
        
        if (PlayerDie.playerDie)
        {
            enableMove = false;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }
    void PauseForSFX()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseMenu.GetComponent<PauseMenu>().gameispaused)
            {
                GhostStatePause = true;
                FindObjectOfType<SoundManager>().Stop("HeartBeat");
            }
            else
            {
                GhostStatePause = false;
                //FindObjectOfType<SoundManager>().Play("HeartBeat");
            }
        }
    }
}
