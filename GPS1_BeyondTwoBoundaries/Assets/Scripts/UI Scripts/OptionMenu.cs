using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OptionMenu : MonoBehaviour
{
    public GameObject PauseMenuUi;
    public GameObject OptionMenuUi;

    public GameObject PauseMenuSystem;
  
   
    void Update()
    {
       
        
    }
    public void backForMain()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
    public void backForPause()
    {
        PauseMenuUi.SetActive(true);
        OptionMenuUi.SetActive(false);

        PauseMenuSystem.GetComponent<PauseMenu>().inpausedMenu = true;
    }
    
   

    
}
