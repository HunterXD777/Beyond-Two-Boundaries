using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActivatedBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject leverOff;
    public GameObject Pos;
    public GameObject leverOn;
    public float speed;
    public bool move = false;
    Vector3 nextPos;
    void Start()
    {
        nextPos = Pos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Up();
        if (move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
            leverOff.SetActive(false);
            leverOn.SetActive(true);
        }
    }

    public void Up()
    {
        
        if(leverOff.GetComponent<PlatformControl>().OnTouching == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                move = true;

                //Jane's Codes
                FindObjectOfType<SoundManager>().Play("Lever"); //play lever sound effect
                FindObjectOfType<SoundManager>().Play("GateOpen"); //play gate open sound effect
            }

        }

        
    }
}
