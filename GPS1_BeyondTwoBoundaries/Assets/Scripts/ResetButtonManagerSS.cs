using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButtonManagerSS : MonoBehaviour
{
    public SoulsSwap soulswap;
    public GameObject encourageResetParticles;
    public float particleTimeToAppear = 3f;

    public LoadNextLevel loadNextLevel;

    public void triggerParticle()
    {
        encourageResetParticles.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (soulswap.shiftCharge == 0 && soulswap.shiftBackBeforeTimerEnds == false && loadNextLevel.collectedPieces != loadNextLevel.requiredPieces) //if player shift back to LS when SStimer ends
        {
            Invoke("triggerParticle", particleTimeToAppear + soulswap.TimerDuration);
        }
        else if (soulswap.shiftCharge == 0 && soulswap.shiftBackBeforeTimerEnds == true && loadNextLevel.collectedPieces != loadNextLevel.requiredPieces) //if player shift back to LS before SStimer ends
        {
            Invoke("triggerParticle", particleTimeToAppear);
        }
        else //if player still got shift charge(s)
        {
            encourageResetParticles.SetActive(false);
        }
    }
}