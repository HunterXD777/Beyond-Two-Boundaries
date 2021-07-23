using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;

    public Transform startPos;
    public Transform pos1, pos2;

    Vector3 nextPos;

    public GameObject player;
    public GameObject ghost;
    public GameObject Decoy;

    public GameObject block;



    public bool playerOnPlatform;
    public bool ghostOnPlatform;
    public bool decoyOnPlatform;
    public bool foroneway;
    public bool fornormal;

    public GameObject[] ElevatorLeverOn;
    public GameObject[] ElevatorLeverOff;


    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(foroneway == true)
        {
            foronewayPlatform();
        }
        if(fornormal == true)
        {
            fornormalPlatform();
        }
    }
        


    
    public void fornormalPlatform()
    {
        //elevatorlever[0] is the one on the platform       
        checkPosition();                      
        playeronplatform();
        ghostonplatform();
        decoyonplatform();
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        Leverelevator();
    }
    public void foronewayPlatform()//for model 3
    {                   
        checkPositionV2();                               
        playeronplatform();
        ghostonplatform();
        decoyonplatform();
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        LeverelevatorV2();
    }
    public void checkPosition()
    {                   
            foreach (GameObject elevatorLever in ElevatorLeverOff)
            {
                if (elevatorLever.GetComponent<PlatformControl>().OnTouching == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                    FindObjectOfType<SoundManager>().Play("Lever"); //play lever sound effect
                    if (transform.position == pos2.position)
                        {
                            nextPos = pos1.position;
                        }
                    if (transform.position == pos1.position)
                        {
                        nextPos = pos2.position;

                        }               
                    }
                }
                
        }
    }
   
    public void checkPositionV2()//for model 3 basic
    {       
        
        if (transform.position == pos1.position)
        {
            foreach (GameObject elevatorLever in ElevatorLeverOff)
            {
                if (elevatorLever.GetComponent<PlatformControl>().OnTouching == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                    FindObjectOfType<SoundManager>().Play("Lever"); //play lever sound effect
                    nextPos = pos2.position;

                    }
                }
            }
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;

        }
    }
    public void Leverelevator()
    {
        if(transform.position == pos1.position || transform.position == pos2.position)
        {
            foreach (GameObject lever in ElevatorLeverOn)
            {
                lever.SetActive(false);
            }
            foreach (GameObject lever in ElevatorLeverOff)
            {
                lever.SetActive(true);
            }
            block.SetActive(false);

        }
        else
        {
            foreach (GameObject lever in ElevatorLeverOn)
            {
                lever.SetActive(true);
            }
            foreach (GameObject lever in ElevatorLeverOff)
            {
                lever.SetActive(false);
            }
             block.SetActive(true);
        }
    }
    public void LeverelevatorV2()//for model 3 basic
    {
        if (transform.position == pos1.position)
        {
            foreach (GameObject lever in ElevatorLeverOn)
            {
                lever.SetActive(false);
            }
            foreach (GameObject lever in ElevatorLeverOff)
            {
                lever.SetActive(true);
            }
            block.SetActive(false);

        }
        else
        {
            foreach (GameObject lever in ElevatorLeverOn)
            {
                lever.SetActive(true);
            }
            foreach (GameObject lever in ElevatorLeverOff)
            {
                lever.SetActive(false);
            }
            block.SetActive(true);
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
        if (other.gameObject.name==("Player"))
        {
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
