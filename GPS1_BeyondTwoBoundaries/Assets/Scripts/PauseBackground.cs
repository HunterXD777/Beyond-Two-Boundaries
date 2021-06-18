using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBackground : MonoBehaviour
{
    public GameObject PauseBackGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseMenu pmc = FindObjectOfType<PauseMenu>();
        if (pmc.gameispaused == true)
        {
            PauseBackGround.SetActive(true);
        }
        else
            PauseBackGround.SetActive(false);
    }
    
}
