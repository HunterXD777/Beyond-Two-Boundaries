using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButtonManagerDB : MonoBehaviour
{
    public DimensionBreach dimensionBreach;
    public GameObject encourageResetParticles;
    public float particleTimeToAppear = 3f;

    public void triggerParticle()
    {
        encourageResetParticles.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(dimensionBreach.shiftReady == false && dimensionBreach.shiftBackBeforeTimerEnds == false) //if player shift back to LS when DBtimer ends
        {
            Invoke("triggerParticle", particleTimeToAppear + dimensionBreach.TimerDuration);
        }
        else if(dimensionBreach.shiftReady == false && dimensionBreach.shiftBackBeforeTimerEnds == true) //if player shift back to LS before DBtimer ends
        {
            Invoke("triggerParticle", particleTimeToAppear);
        }
        else //if player still got shift charge(s)
        {
            encourageResetParticles.SetActive(false);
        }
    }
}
