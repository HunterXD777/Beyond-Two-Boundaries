using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    public bool gameispaused = false;
    public bool inpausedMenu = true;
    public GameObject PauseMenuUi;
    public GameObject OptionMenuUi;
    public GameObject ControlsMenuUi;



    void Update()
    {
        if (inpausedMenu == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameispaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }
    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        gameispaused = false;
    }
    public void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        gameispaused = true;
    }
    public void control()
    {
        ControlsMenuUi.SetActive(true);
        PauseMenuUi.SetActive(false);
        //SceneManager.LoadScene("ControlsMenu");
        inpausedMenu = false;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void Option()
    {
        OptionMenuUi.SetActive(true);
        PauseMenuUi.SetActive(false);
        //SceneManager.LoadScene("OptionMenu");
        inpausedMenu = false;
    }
    public void QuitGame()
    {
        Debug.Log("Quitgame");
        Application.Quit();
    }
   
}
