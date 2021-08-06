using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public GameObject generalHelpMenu;
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))// || Input.GetKeyDown(KeyCode.Mouse0))
        {
            generalHelpMenu.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.H))// || Input.GetKeyUp(KeyCode.Mouse0))
        {
            generalHelpMenu.SetActive(false);
        }
    }
}
