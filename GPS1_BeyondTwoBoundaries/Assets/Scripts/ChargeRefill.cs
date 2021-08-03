using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeRefill : MonoBehaviour
{
    GameObject soulSwap;
    GameObject soulPiece1;
    GameObject soulPiece2;
    public void Start()
    {

        soulSwap = GameObject.Find("MAIN PLAYER (Soul Swap)");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if(soulSwap.GetComponent<SoulsSwap>().shiftCharge == 1)
        {
            soulSwap.GetComponent<SoulsSwap>().shiftCharge++;
            soulSwap.GetComponent<SoulsSwap>().SoulPiece2.SetActive(true);
        }
        if(soulSwap.GetComponent<SoulsSwap>().shiftCharge == 0)
        {
            soulSwap.GetComponent<SoulsSwap>().shiftCharge+=2;
            soulSwap.GetComponent<SoulsSwap>().SoulPiece1.SetActive(true);
            soulSwap.GetComponent<SoulsSwap>().SoulPiece2.SetActive(true);
        }
    }
}
