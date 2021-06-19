using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptionMenu : MonoBehaviour
{
    public GameObject PauseMenuUi;
    public GameObject OptionMenuUi;


    public void backForMain()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
    public void backForPause()
    {
        PauseMenuUi.SetActive(true);
        OptionMenuUi.SetActive(false);
    }
    
    
}
