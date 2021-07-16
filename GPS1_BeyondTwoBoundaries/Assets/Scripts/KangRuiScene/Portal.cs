using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private GameObject player;
    public GameObject portal;
    public bool isToushcing;
    public bool onWorking;
   
    public bool twowayPortal;

    public GameObject enterPortalParticleEffect;
    public GameObject exitPortalParticleEffect;
    void Start()
    {
        onWorking = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");

        if (isToushcing == true)
        {
            player.transform.position = portal.transform.position;
            if (twowayPortal == true)
            {
                portal.GetComponent<Portal>().onWorking = false;
            }
            //Jane's Codes
            Instantiate(exitPortalParticleEffect, portal.transform.position, Quaternion.identity);
            Instantiate(enterPortalParticleEffect, transform.position, Quaternion.identity);
            FindObjectOfType<SoundManager>().Play("Portal"); //play portal sound effect
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (twowayPortal == true)
        {
            if (onWorking == true)
            {
                if (other.CompareTag("Player"))
                {
                    isToushcing = true;
                }
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                isToushcing = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (twowayPortal == true)
        {
            if (other.CompareTag("Player"))
            {
                isToushcing = false;
                onWorking = true;
            }
        }
        else
        {
            if (other.CompareTag("Player"))
            {
                isToushcing = false;
            }
        }
    }

   
    //IEnumerator Teleport()
    //{
    //    yield return new WaitForSeconds(0f);
    //    player.transform.position = portal.transform.position;
    //}
}
