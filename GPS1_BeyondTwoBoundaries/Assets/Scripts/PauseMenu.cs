using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Player;
   
    public bool fromPause;

    
    public void Resume()
    {    
        
        PauseMenuControll pmc = FindObjectOfType<PauseMenuControll>();
        pmc.isPaused = false;
        SceneManager.UnloadSceneAsync("PauseMenu");
        //SceneManager.LoadScene("Alyf's Scene");

    }
    public void Option()
    {
        Debug.Log("Option");
        SceneManager.LoadScene("OptionMenu",LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("PauseMenu");
        //fromPause = true;
    }
    public void Quit()
    {
        Debug.Log("Quitgame");
        Application.Quit();
    }

}
