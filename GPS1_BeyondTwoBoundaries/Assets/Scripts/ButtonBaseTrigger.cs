using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBaseTrigger : MonoBehaviour
{
    private GameObject door;

    void Awake()
    {
        door = GameObject.FindWithTag("ElectricalDoor");
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Button"))
        {
            door.GetComponent<ElectricalDoor>().pressedButtons++;
            Debug.Log("ButtonPressed");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Button"))
        {
            door.GetComponent<ElectricalDoor>().pressedButtons--;
            Debug.Log("ButtonReleased");
        }
    }
}
