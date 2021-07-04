using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    public bool OnTouching;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnTouching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnTouching = false;
        }
    }
}
