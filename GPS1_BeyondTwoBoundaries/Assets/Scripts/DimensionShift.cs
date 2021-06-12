using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionShift : MonoBehaviour
{
    
    PlatformerMovement playerMovement;
    public bool ghostState = false;  

    public GameObject MainPlayer;
    public GameObject GhostPlayer;
    public GameObject Decoy;

    GhostMovement ghostMove;

    private GameObject decoyTracking;
    private GameObject playerTracking;

    public GameObject[] ghostWalls;
    

    void Awake()
    {
        
    }

    
    void Update()
    {
        ShiftDimension();
    }

    public void ShiftDimension()
    {
        ghostMove = GhostPlayer.GetComponent<GhostMovement>();
        playerTracking = GameObject.FindWithTag("Player");
        decoyTracking = GameObject.FindWithTag("Decoy");


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!ghostState)
            {
                ghostState = true;


                //Set decoy position at main player position
                Decoy.transform.position = new Vector2(playerTracking.transform.position.x, playerTracking.transform.position.y); 

                //Set ghost player position at main player position 
                GhostPlayer.transform.position = new Vector2(playerTracking.transform.position.x, playerTracking.transform.position.y);

                //Disable main player
                MainPlayer.SetActive(false);  

                //Enable decoy
                Decoy.SetActive(true);

                //Enable ghost player
                GhostPlayer.SetActive(true);

                //Reveal Ghost Walls
                ghostWalls[0].SetActive(false);

            }
            if(ghostState && ghostMove.isTouchingDecoy)
            {
                
                ghostState = false;

                //Set main player position to decoy position
                MainPlayer.transform.position = new Vector2(decoyTracking.transform.position.x, decoyTracking.transform.position.y);

                //Disable ghost player
                GhostPlayer.SetActive(false);

                //Disable decoy
                Decoy.SetActive(false);

                //Hide ghost walls
                ghostWalls[0].SetActive(true);

                //Enable main player
                MainPlayer.SetActive(true);
                
                
                

            }
        }
              
    }


}
