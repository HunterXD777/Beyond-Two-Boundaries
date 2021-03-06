using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DimensionBreach : MonoBehaviour
{

    public PlatformerMovement playerMovement;
    public GhostMovement ghostMovement;

    public bool AutoShfit;
    public bool shiftReady = true;


    public bool ghostState = false;
    public bool breachedGhost = false;
    
    public bool shiftBackBeforeTimerEnds = false; //Jane's Codes

    public GameObject MainPlayer;
    public GameObject GhostPlayer;
    public GameObject Decoy;

    GhostMovement ghostMove;

    private GameObject decoyTracking;
    private GameObject playerTracking;

    public GameObject[] ghostWalls;

     public GameObject SoulsPiece;

    //Timer Stuff
    public float TimerDuration = 10f;
    public float timeStart;
    public Text textBox;
    public bool timerActive = false;


    public Image SoulBar;
    public Image filter;

    void Awake()
    {
        textBox.text = timeStart.ToString("F2");
        ResetFilter();
        
        //textBox.text = timeStart.ToString();
    }


    void Update()
    {
        
            if (playerMovement.enableMove && ghostMovement.enableMove)//Kang Rui code add ghost enableMove to make sure when ghost die, ghost cant move or use dimension shift
            {
                ShiftDimension();
            }

        //Kang Rui code 
        //for charge ui
        if (shiftReady)
            {
                SoulsPiece.SetActive(true);
            }
            else
            {
                SoulsPiece.SetActive(false);
            }



        if (timerActive)
        {
            timeStart -= Time.deltaTime;
            textBox.text = timeStart.ToString("F2");
            //textBox.text = Mathf.Round(timeStart).ToString();
        }
        else
        {
            timeStart = 0;
            textBox.text = timeStart.ToString("F2");
        }

        SoulBar.fillAmount = timeStart / TimerDuration;
        
    }

    public void ShiftDimension()
    {
        ghostMove = GhostPlayer.GetComponent<GhostMovement>();
        playerTracking = GameObject.FindWithTag("Player");
        decoyTracking = GameObject.FindWithTag("Decoy");



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!ghostState && shiftReady)
            {
                ShiftToSoul();

            }
            
            else if (ghostState)
            {
                if (!ghostMove.isTouchingDecoy)
                {
                    AutoShiftToBody();
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.F) && ghostState)
        {
            Breach();
        }
       

        if (ghostState)
        {
            if (timeStart <= 0)
            {
                AutoShiftToBody();
                shiftBackBeforeTimerEnds = false; //Jane's Codes
            }
        }



    }

    public void ShiftToSoul()
    {
        ghostState = true;
        breachedGhost = true;


        //Set decoy position at main player position
        Decoy.transform.position = new Vector2(playerTracking.transform.position.x, playerTracking.transform.position.y);

        //Set ghost player position at main player position 
        GhostPlayer.transform.position = new Vector2(playerTracking.transform.position.x, playerTracking.transform.position.y);

        //Flipping Decoy if needed
        if (playerMovement.PlayerFacingRight == false)
        {
            Decoy.transform.Rotate(0f, 180f, 0f);
        }

        //Disable main player
        MainPlayer.SetActive(false);    

        //Enable decoy
        Decoy.SetActive(true);

        //Enable ghost player
        GhostPlayer.SetActive(true);

        //Reveal Ghost Walls
        ghostWalls[0].SetActive(false);
        ghostWalls[1].SetActive(false);
        ghostWalls[2].SetActive(true);// change later (this is filter)
        ghostWalls[3].SetActive(true);

        //Play Sound Effect
        FindObjectOfType<SoundManager>().Play("HeartBeat");

        //Start Filter Fade
        FilterFade();

        //Start Timer
        SetTimer();

        //Disable shift ready
        shiftReady = false;



    }

    public void Breach()
    {
        if (breachedGhost)
        //Breach to Human Form
        {
            //Set decoy position at GHOST player position
            Decoy.transform.position = new Vector2(playerTracking.transform.position.x, playerTracking.transform.position.y);


            //Flipping Decoy if needed
            if (playerMovement.PlayerFacingRight == false)
            {
                Decoy.transform.Rotate(0f, 180f, 0f);
            }

            //Disable ghost player 
            GhostPlayer.SetActive(false);

            //Enable main player
            MainPlayer.SetActive(true);

            //Hide Ghost Walls
            ghostWalls[0].SetActive(true);
            ghostWalls[1].SetActive(true);
            //ghostWalls[2].SetActive(false);// change later (this is filter)
            ghostWalls[3].SetActive(false);

            //Set Breach Ghost State
            breachedGhost = false;
        }
        else
        //Breach to Ghost Form
        {
            //Set decoy position at MAIN player position
            Decoy.transform.position = new Vector2(playerTracking.transform.position.x, playerTracking.transform.position.y);


            //Flipping Decoy if needed
            if (playerMovement.PlayerFacingRight == false)
            {
                Decoy.transform.Rotate(0f, 180f, 0f);
            }

            //Disable main player 
            MainPlayer.SetActive(false);

            //Enable ghost player
            GhostPlayer.SetActive(true);

            //Hide Ghost Walls
            ghostWalls[0].SetActive(false);
            ghostWalls[1].SetActive(false);
            //ghostWalls[2].SetActive(true);// change later (this is filter)
            ghostWalls[3].SetActive(true);

            //Set Breach Human State
            breachedGhost = true;
        }
        

      
    }

    public void AutoShiftToBody()
    {


        ghostState = false;

        //if in ghostform
        if (breachedGhost)
        {
            //Set main player position to decoy position
            MainPlayer.transform.position = new Vector2(decoyTracking.transform.position.x, decoyTracking.transform.position.y);

            //Disable ghost player
            GhostPlayer.SetActive(false);

            //Disable decoy
            Decoy.SetActive(false);

            MainPlayer.SetActive(true);

            //Flip back decoy if needed
            if (playerMovement.PlayerFacingRight == false)
            {
                Decoy.transform.Rotate(0f, 180f, 0f);
            }

            //Hide ghost walls
            ghostWalls[0].SetActive(true);
            ghostWalls[1].SetActive(true);
            ghostWalls[2].SetActive(false);
            ghostWalls[3].SetActive(false);
        }

        //if in human form
        else
        {
            //Set main player position to decoy position
            //MainPlayer.transform.position = new Vector2(decoyTracking.transform.position.x, decoyTracking.transform.position.y);

            //Disable ghost player
            GhostPlayer.SetActive(false);

            //Disable decoy
            Decoy.SetActive(false);

            //Flip back decoy if needed
            if (playerMovement.PlayerFacingRight == false)
            {
                Decoy.transform.Rotate(0f, 180f, 0f);
            }
        }



        //Reset Filter
        ResetFilter();

        //Stop Timer
        SetTimer();

        //Stop Heartbeat sound effect
        FindObjectOfType<SoundManager>().Stop("HeartBeat");

        //Play Sound Effect
        FindObjectOfType<SoundManager>().Play("BreathIn");

        shiftBackBeforeTimerEnds = true; //Jane's Codes

    }

    public void SetTimer()
    {
        timerActive = !timerActive;
        timeStart = TimerDuration;
        Debug.Log("Timer Called");
    }

    public void FilterFade()
    {
        filter.CrossFadeAlpha(1, TimerDuration, false);
    }

    public void ResetFilter()
    {
        filter.CrossFadeAlpha(0, 0.5f, false);
    }


}
