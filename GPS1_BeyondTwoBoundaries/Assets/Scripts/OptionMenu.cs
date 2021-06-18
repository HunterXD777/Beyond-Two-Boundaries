using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptionMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    //public GameObject MainMenu;
   public void back()
    {
        //if(PauseMenu.GetComponent<PauseMenu>().fromPause == true)
        
            Debug.Log("Back");
            //SceneManager.LoadScene("PauseMenu");
        SceneManager.UnloadSceneAsync("OptionMenu");
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);

    }
}
