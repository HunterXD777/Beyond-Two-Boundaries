using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalDoor : MonoBehaviour
{
    public GameObject openedPos;
    public GameObject Button1;
    public GameObject Button2;

    public float doorSpeed = 3;
    private bool doorOpened = false;
    public int pressedButtons = 0;
    public int requiredButtons = 2;
    public bool button1Pressed = false;
    public bool button2Pressed = false;

    
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ButtonCheck();

        if(button1Pressed && button2Pressed)
        {
            transform.position = Vector3.MoveTowards(transform.position, openedPos.transform.position, doorSpeed * Time.deltaTime);
            doorOpened = true;
        }

    }

    public void ButtonCheck()
    {
        if(Button1.GetComponent<ButtonPlatform>().isPressed == true)
        {
            button1Pressed = true;
        }
        else
        {
            button1Pressed = false;
        }


        if (Button2.GetComponent<ButtonPlatform>().isPressed == true)
        {
            button2Pressed = true;
        }
        else
        {
            button2Pressed = false;
        }
    }
}
