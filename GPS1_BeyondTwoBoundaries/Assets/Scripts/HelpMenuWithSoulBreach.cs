using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuWithSoulBreach : MonoBehaviour
{
    public GameObject generalHelpMenu;
    public GameObject soulBreachHelpMenu;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            generalHelpMenu.SetActive(true);
            soulBreachHelpMenu.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            generalHelpMenu.SetActive(false);
            soulBreachHelpMenu.SetActive(false);
        }
    }
}
