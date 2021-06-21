using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DimensionShift : MonoBehaviour
{
    
    PlatformerMovement playerMovement;

    public bool ManualShift;
    public bool AutoShfit;
    

    public bool ghostState = false;  

    public GameObject MainPlayer;
    public GameObject GhostPlayer;
    public GameObject Decoy;

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
        
        //textBox.text = timeStart.ToString();
    }

    
    void Update()
    {
        ShiftDimension();

        


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
            if (!ghostState && (AutoShfit || ManualShift))
            {
                ShiftToSoul();

            }
            else if(ghostState && ManualShift)
            {
                if (ghostMove.isTouchingDecoy)
                {
                    ManualShiftToBody();
                }
                         
            }
            else if(ghostState && AutoShfit)
            {
                if (!ghostMove.isTouchingDecoy)
                {
                    AutoShiftToBody();
                }

            }
        }

        if(ghostState && ManualShift)
        {
            if(timeStart <= 0)
            {      
                SceneManager.LoadScene("Alyf's Scene");
            }
        }

        if(ghostState && AutoShfit)
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
        ghostWalls[1].SetActive(false);
        ghostWalls[2].SetActive(true);// change later (this is filter)

        //Start Timer
        SetTimer();
    }

    public void ManualShiftToBody()
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
        ghostWalls[1].SetActive(true);
        ghostWalls[2].SetActive(false);

        //Enable main player
        MainPlayer.SetActive(true);

        //Reset Filter
        filter.canvasRenderer.SetAlpha(0);

        //Stop Timer
        SetTimer();
    }

    public void AutoShiftToBody()
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
        ghostWalls[1].SetActive(true);
        ghostWalls[2].SetActive(false);

        //Enable main player
        MainPlayer.SetActive(true);

        //Reset Filter
        filter.canvasRenderer.SetAlpha(0);

        //Stop Timer
        SetTimer();

    }

    public void SetTimer()
    { 
        timerActive = !timerActive;
        timeStart = TimerDuration;
        Debug.Log ("Timer Called");
    }

    public void FilterFade()
    {
        filter.canvasRenderer.SetAlpha(timeStart / TimerDuration);

    }

    
}