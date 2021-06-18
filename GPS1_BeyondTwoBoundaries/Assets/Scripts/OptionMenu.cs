using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptionMenu : MonoBehaviour
{
 
   
   public void back()
    {
        SceneManager.LoadScene("MainMenu");
        //if (PauseMenu.GetComponent<PauseMenu>().fromPause == true)
        //{
        //    SceneManager.LoadScene("Alyf's Scene");
        //}
        //else
        //{
        //    SceneManager.LoadScene("MainMenu");
        //}
    }

    
}
