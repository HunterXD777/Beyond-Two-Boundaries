using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoulsSwap : MonoBehaviour
{
    public PlatformerMovement playerMovement;

    public bool ManualShift;
    public bool AutoShfit;
    public bool shiftReady = true;

     int shiftCharge;
    public int timecharge;
    public bool ghostState = false;

    public GameObject MainPlayer;
    public GameObject GhostPlayer;
    public GameObject SoulPiece1;
    public GameObject SoulPiece2;
    //public GameObject Decoy;

    GhostMovement ghostMove;

    private GameObject decoyTracking;
    private GameObject playerTracking;

    public GameObject[] ghostWalls;

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

        shiftCharge = timecharge;
        //textBox.text = timeStart.ToString();
    }


    void Update()
    {
        if (playerMovement.enableMove)
        {
            ShiftDimension();
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
        //playerTracking = GameObject.FindWithTag("Player");
        //decoyTracking = GameObject.FindWithTag("Decoy");



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!ghostState && shiftCharge >0)
            {
                ShiftToSoul();

            }
            else if (ghostState && AutoShfit && timeStart <= 4.5)
            {                                 
                AutoShiftToBody();
            }
        }

        if (ghostState && AutoShfit)
        {
            if (timeStart <= 0)
            {
                AutoShiftToBody();
            }
        }



    }

    public void ShiftToSoul()
    {
        ghostState = true;


        //Set decoy position at main player position
        //Decoy.transform.position = new Vector2(playerTracking.transform.position.x, playerTracking.transform.position.y);

        //Set ghost player position at main player position 
        GhostPlayer.transform.position = new Vector2(MainPlayer.transform.position.x, MainPlayer.transform.position.y);

        if (playerMovement.PlayerFacingRight == true && ghostMove.PlayerFacingRight == false)
        {
            ghostMove.transform.Rotate(0f, 180f, 0f);
            ghostMove.PlayerFacingRight = true;
        }
        if (playerMovement.PlayerFacingRight == false && ghostMove.PlayerFacingRight == true)
        {
            ghostMove.transform.Rotate(0f, 180f, 0f);
            ghostMove.PlayerFacingRight = false;
        }


        //Disable main player
        MainPlayer.SetActive(false);

        //Enable decoy
        //Decoy.SetActive(true);

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
        //shiftReady = false;
        shiftCharge--;

        chargeUI();

    }

    public void ManualShiftToBody()
    {
        ghostState = false;

        //Set main player position to ghost position
        MainPlayer.transform.position = new Vector2(GhostPlayer.transform.position.x, GhostPlayer.transform.position.y);

        //Disable ghost player
        GhostPlayer.SetActive(false);

        //Disable decoy
        //Decoy.SetActive(false);

        //Flip back decoy if needed
        if (playerMovement.PlayerFacingRight == false)
        {
            //Decoy.transform.Rotate(0f, 180f, 0f);
        }

        //Hide ghost walls
        ghostWalls[0].SetActive(true);
        ghostWalls[1].SetActive(true);
        ghostWalls[2].SetActive(false);
        ghostWalls[3].SetActive(false);

        //Enable main player
        MainPlayer.SetActive(true);

        //Reset Filter
        ResetFilter();

        //Stop Timer
        SetTimer();

        //Stop Heartbeat sound effect
        FindObjectOfType<SoundManager>().Pause("HeartBeat");

        //Play Sound Effect
        FindObjectOfType<SoundManager>().Play("BreathIn");
    }

    public void AutoShiftToBody()
    {
        ghostState = false;

        //Set main player position to ghost position
        MainPlayer.transform.position = new Vector2(GhostPlayer.transform.position.x, GhostPlayer.transform.position.y);

        //Disable ghost player
        GhostPlayer.SetActive(false);

        //Disable decoy
        //Decoy.SetActive(false);

        //make sure the ls facing the correct direction when shift back 
        if (ghostMove.PlayerFacingRight == true && playerMovement.PlayerFacingRight == false)
        {
            playerMovement.transform.Rotate(0f, 180f, 0f);
            playerMovement.PlayerFacingRight = true;
        }
        if(ghostMove.PlayerFacingRight == false && playerMovement.PlayerFacingRight == true)
        {
            playerMovement.transform.Rotate(0f, 180f, 0f);
            playerMovement.PlayerFacingRight = false;
        }

        //Hide ghost walls
        ghostWalls[0].SetActive(true);
        ghostWalls[1].SetActive(true);
        ghostWalls[2].SetActive(false);
        ghostWalls[3].SetActive(false);

        //Enable main player
        MainPlayer.SetActive(true);

        //Reset Filter
        ResetFilter();

        //Stop Timer
        SetTimer();

        //Stop Heartbeat sound effect
        FindObjectOfType<SoundManager>().Stop("HeartBeat");

        //Play Sound Effect
        FindObjectOfType<SoundManager>().Play("BreathIn");

    }

    public void chargeUI()//for charge ui
    {
        if (shiftCharge == 1)
        {
            SoulPiece2.SetActive(false);
        }
        if (shiftCharge == 0)
        {
            SoulPiece1.SetActive(false);
        }
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
