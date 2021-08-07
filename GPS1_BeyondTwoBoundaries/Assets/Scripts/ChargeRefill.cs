using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeRefill : MonoBehaviour
{
    GameObject soulSwap;
    GameObject soulSeperation;
   

    public bool forWallTutorial;
    public void Start()
    {

       
        if (forWallTutorial)
        {
            soulSeperation = GameObject.Find("MAIN PLAYER");
        }
        else
        {
            soulSwap = GameObject.Find("MAIN PLAYER (Soul Swap)");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        FindObjectOfType<SoundManager>().Play("Collected");
        if (forWallTutorial)
        {
            if (!soulSeperation.GetComponent<DimensionShift>().shiftReady)
            {
                soulSeperation.GetComponent<DimensionShift>().shiftReady = true;

            }
        }
        else
        {
            if (soulSwap.GetComponent<SoulsSwap>().shiftCharge == 1)
            {
                soulSwap.GetComponent<SoulsSwap>().shiftCharge++;
                soulSwap.GetComponent<SoulsSwap>().SoulPiece2.SetActive(true);
            }
            if (soulSwap.GetComponent<SoulsSwap>().shiftCharge == 0)
            {
                soulSwap.GetComponent<SoulsSwap>().shiftCharge += 2;
                soulSwap.GetComponent<SoulsSwap>().SoulPiece1.SetActive(true);
                soulSwap.GetComponent<SoulsSwap>().SoulPiece2.SetActive(true);
            }
        }
       
    }
}
