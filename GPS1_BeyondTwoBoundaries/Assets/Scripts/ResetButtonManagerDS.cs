using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonManagerDS : MonoBehaviour
{
    public DimensionShift dimensionShift;
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
        if (dimensionShift.shiftReady == false && dimensionShift.shiftBackBeforeTimerEnds == false && loadNextLevel.collectedPieces != loadNextLevel.requiredPieces) //if player shift back to LS when DStimer ends
        {
            Invoke("triggerParticle", particleTimeToAppear + dimensionShift.TimerDuration);
        }
        else if (dimensionShift.shiftReady == false && dimensionShift.shiftBackBeforeTimerEnds == true && loadNextLevel.collectedPieces != loadNextLevel.requiredPieces) //if player shift back to LS before DStimer ends
        {
            Invoke("triggerParticle", particleTimeToAppear);

        }
        else //if player still got shift charge(s)
        {
            encourageResetParticles.SetActive(false);
        }
    }
}
