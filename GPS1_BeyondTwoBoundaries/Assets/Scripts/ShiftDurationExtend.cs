using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftDurationExtend : MonoBehaviour
{
   float resetFilterTimer;
    // Start is called before the first frame update
    public bool DBreachExtend;
    public bool DShiftExtend;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (DBreachExtend)//for dimension breach
        {
            GameObject DB = GameObject.Find("MAIN PLAYER");
            if (other.gameObject.name == "GhostPlayer")
            {
                DB.GetComponent<DimensionBreach>().timeStart += 3;
                resetFilterTimer = DB.GetComponent<DimensionBreach>().timeStart;
                DB.GetComponent<DimensionBreach>().filter.CrossFadeAlpha(1, resetFilterTimer, false);
                Destroy(this.gameObject);
            }
        }
        if (DShiftExtend)//for dimension shift
        {
            GameObject DS = GameObject.Find("MAIN PLAYER");
            if (other.gameObject.name == "GhostPlayer")
            {
                DS.GetComponent<DimensionShift>().timeStart += 3;
                resetFilterTimer = DS.GetComponent<DimensionShift>().timeStart;
                DS.GetComponent<DimensionShift>().filter.CrossFadeAlpha(1, resetFilterTimer, false);
                Destroy(this.gameObject);
            }
        }
    }

}
