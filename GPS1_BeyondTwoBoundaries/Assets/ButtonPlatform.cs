using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ButtonPlatform : MonoBehaviour
{

    public GameObject defaultPos;
    public GameObject pressedPos;
    public bool isPressed = false;
    public float buttonSpeed = 1;

    private GameObject door;

    Vector3 nextPos;


    // Start is called before the first frame update
    void Awake()
    {
        transform.position = defaultPos.transform.position;
        door = GameObject.FindWithTag("ElectricalDoor");
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && transform.position != defaultPos.transform.position)
        {
            ReleaseButton();
        }


       
    }

    public void PressButton()
    {
        transform.position = Vector3.MoveTowards(transform.position, pressedPos.transform.position, buttonSpeed * Time.deltaTime);
       
    }

    public void ReleaseButton()
    {
        transform.position = Vector3.MoveTowards(transform.position, defaultPos.transform.position, buttonSpeed * Time.deltaTime);
        
    }

 

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Decoy"))
        {
            PressButton();
        }

        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Decoy"))
        {
            //door.GetComponent<ElectricalDoor>().pressedButtons++;
            isPressed = true;
            Debug.Log("ButtonPressed");
        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Decoy"))
        {
            //door.GetComponent<ElectricalDoor>().pressedButtons--;
            isPressed = false;
            Debug.Log("ButtonReleased");
        }
    }
}
