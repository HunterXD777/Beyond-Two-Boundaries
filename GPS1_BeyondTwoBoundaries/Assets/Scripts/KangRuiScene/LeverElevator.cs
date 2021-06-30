using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverElevator : MonoBehaviour
{
    public float speed;
    public float controltimer, cd;
    public Transform startPos;
    public Transform pos1, pos2;

    Vector3 nextPos;
    public GameObject platformControls;//the control button

    public GameObject floor2leverOn;
    public GameObject floor2leverOff;
    public GameObject floor1leverOff;
    public GameObject floor1leverOn;
    public GameObject ElevatorLeverOn;
    public GameObject ElevatorLeverOff;

    public bool OnStartFloor;
    public bool fromStart = true;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (platformControls.GetComponent<PlatformControl>().OnTouching == true)
        {
            checkPosition();//control the platform

        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        //floorleverActivated();


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
                if (transform.position == pos2.position)
                {
                    nextPos = pos1.position;
                    OnStartFloor = true;
                }
                if (transform.position == pos1.position)
                {
                    nextPos = pos2.position;
                    OnStartFloor = false;
                }
            }
        }
    }
   

    public void Leverelevator()
    {
        if(transform.position != pos1.position || transform.position != pos2.position)
        {

        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag ("Player"))
        {
            other.transform.parent = gameObject.transform;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }



}
