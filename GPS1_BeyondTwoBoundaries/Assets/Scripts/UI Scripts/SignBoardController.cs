using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignBoardController : MonoBehaviour
{

    public GameObject InteractTrigger;
    public GameObject ShiftBackTrigger;
    public GameObject ShiftTrigger;

    public DimensionShift dimensionShift;

    public Image LeftRightSign;
    public Image JumpSign;
    public Image ShiftSign;
    public Image LevitateSign;
    public Image InteractSign;
    public Image ShiftBackSign;
    //Kang Rui code
    public Image GoalSign;

    public bool leverOn;


    private void Awake()
    {
        LeftRightSign.CrossFadeAlpha(0, 0.2f, false);
        JumpSign.CrossFadeAlpha(0, 0.2f, false);
        ShiftSign.CrossFadeAlpha(0, 0.2f, false);
        LevitateSign.CrossFadeAlpha(0, 0.2f, false);
        InteractSign.CrossFadeAlpha(0, 0.2f, false);
        ShiftBackSign.CrossFadeAlpha(0, 0.2f, false);
        GoalSign.CrossFadeAlpha(0, 0.2f, false);
        leverOn = false;
    }

    void Update()
    {


        if (!dimensionShift.ghostState && leverOn)
        {
            ShiftBackTrigger.SetActive(false);
        }
    }

    public void InteractLever()
    {
        InteractTrigger.SetActive(false);
        ShiftBackTrigger.SetActive(true);
        ShiftTrigger.SetActive(false);
        leverOn = true;
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LeftRightTrigger"))
        {
            LeftRightSign.CrossFadeAlpha(1, 1, false);
        }
    

        if (other.CompareTag("JumpTrigger"))
        {
            JumpSign.CrossFadeAlpha(1, 1, false);
        }

        if (other.CompareTag("ShiftTrigger"))
        {
            ShiftSign.CrossFadeAlpha(1, 1, false);
        }

        if (other.CompareTag("LevitateTrigger"))
        {
            LevitateSign.CrossFadeAlpha(1, 1, false);
        }

        if (other.CompareTag("JumpTrigger"))
        {
            JumpSign.CrossFadeAlpha(1, 1, false);
        }

        if (other.CompareTag("InteractTrigger"))
        {
            InteractSign.CrossFadeAlpha(1, 1, false);
        }

        if (other.CompareTag("ShiftBackTrigger"))
        {
            ShiftBackSign.CrossFadeAlpha(1, 1, false);

            
        }
        //Kang Rui code
        if (other.CompareTag("GoalSignTrigger"))
        {
            GoalSign.CrossFadeAlpha(1, 1, false);


        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LeftRightTrigger"))
        {
            LeftRightSign.CrossFadeAlpha(0, 1, false);
        }

        if (other.CompareTag("JumpTrigger"))
        {
            JumpSign.CrossFadeAlpha(0, 1, false);
        }

        if (other.CompareTag("ShiftTrigger"))
        {
            ShiftSign.CrossFadeAlpha(0, 1, false);
        }

        if (other.CompareTag("LevitateTrigger"))
        {
            LevitateSign.CrossFadeAlpha(0, 1, false);
        }

        if (other.CompareTag("JumpTrigger"))
        {
            JumpSign.CrossFadeAlpha(0, 1, false);
        }

        if (other.CompareTag("InteractTrigger"))
        {
            InteractSign.CrossFadeAlpha(0, 1, false);
        }

        if (other.CompareTag("ShiftBackTrigger"))
        {
            ShiftBackSign.CrossFadeAlpha(0, 1, false);
        }
        //Kang Rui code
        if (other.CompareTag("GoalSignTrigger"))
        {
            GoalSign.CrossFadeAlpha(0, 1, false);


        }
    }
}
