using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSign : MonoBehaviour
{
    public GameObject infoSign;
    LoadNextLevel pieceCheck;

    private void Awake()
    {
        infoSign.SetActive(false);
        pieceCheck = GetComponent<LoadNextLevel>();
    }

    
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (pieceCheck.collectedPieces != pieceCheck.requiredPieces)
            {
                infoSign.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (pieceCheck.collectedPieces != pieceCheck.requiredPieces)
            {
                infoSign.SetActive(false);
            }
        }
    }
}
