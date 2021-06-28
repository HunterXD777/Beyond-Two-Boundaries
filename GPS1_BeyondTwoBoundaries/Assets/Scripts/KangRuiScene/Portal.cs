using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public GameObject portal;
    public bool isToushcing;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isToushcing == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = portal.transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isToushcing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isToushcing = false;
        }
    }

}