using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
  
    public GameObject player;
    public GameObject ghost;
    public GameObject Decoy;

    public bool playerOnPlatform;
    public bool ghostOnPlatform;
    public bool decoyOnPlatform;

    Vector3 nextPos;
    
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        checkPosition();
        playeronplatform();
        ghostonplatform();
        decoyonplatform();
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
      
    }  

    void checkPosition()
    {
        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;//go to the position 2 if this platform arrival position 1
        }
        if (transform.position == pos2.position)
        {
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
