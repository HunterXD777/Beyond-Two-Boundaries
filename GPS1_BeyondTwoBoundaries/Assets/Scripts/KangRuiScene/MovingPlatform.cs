using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
   
    public float speed;
    public float controltimer,cd;
    public Transform startPos;
    public Transform pos1, pos2, pos3;
   
    Vector3 nextPos;
    public GameObject platformControls;//the control button
    
    public GameObject player;
    public GameObject ghost;
    public GameObject Decoy;

    public bool playerOnPlatform;
    public bool ghostOnPlatform;
    public bool decoyOnPlatform;

    public bool OnPlatform;
    public bool fromStart = true;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
                  
       if(platformControls.GetComponent<PlatformControl>().OnTouching == true)
        {
         checkPosition();//control the platform
         
        }
       checkDirection();//determine the platform should move to where
       ghostonplatform();//check the ghost on platform or not
       playeronplatform();//check the player on platform or not
       decoyonplatform();//check the decoy on platform or not
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

       

        if (cd > 0f)
        {
            cd -= Time.deltaTime;
        }

       
    }
   
    public void checkPosition()
    {
    if (cd <= 0f)
        {
       if (Input.GetKeyDown(KeyCode.E))
        {
                cd = controltimer;
                if (transform.position == pos3.position)
                {
                    fromStart = false;
                }
                if (transform.position == pos1.position)
                {
                    fromStart = true;

                }
                nextPos = pos2.position;
            }
        }      
    }

    public void checkDirection()
    {
        if(transform.position == pos2.position)
        {
            if(fromStart == true)
            {
                nextPos = pos3.position;
            }
            else
                nextPos = pos1.position;
        }
    }

    void ghostonplatform()
    {
        if (ghostOnPlatform == true)
        {
            ghost.transform.parent = gameObject.transform;
        }
        else
        {
            ghost.transform.parent = null;
        }
    }

    void playeronplatform()
    {
        if (playerOnPlatform == true)
        {
            player.transform.parent = gameObject.transform;
  
        }
        else
        {
            player.transform.parent = null;
        }
    }
    void decoyonplatform()
    {
        if (decoyOnPlatform == true)
        {
            Decoy.transform.parent = gameObject.transform;
        }
        else
        {
            Decoy.transform.parent = null;
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == ("Player"))
        {
            //other.transform.parent = gameObject.transform;
            playerOnPlatform = true;
        }
        if (other.gameObject.name == ("GhostPlayer"))
        {
            ghostOnPlatform = true;
        }
        if (other.gameObject.name == ("Decoy"))
        {
            decoyOnPlatform = true;
        }

    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == ("Player"))
        {
            //other.transform.parent = gameObject.transform;
            playerOnPlatform = false;
        }
        if (other.gameObject.name == ("GhostPlayer"))
        {
            ghostOnPlatform = false;
        }
        if (other.gameObject.name == ("Decoy"))
        {
            decoyOnPlatform = false;
        }

    }


}
