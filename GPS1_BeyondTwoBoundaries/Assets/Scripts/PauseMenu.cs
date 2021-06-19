using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    public bool gameispaused = false;
    public bool frompaused = false;
    public GameObject PauseMenuUi;
    public GameObject OptionMenuUi;
    public GameObject ControlsMenuUi;

    void Update()
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
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Option()
    {
        OptionMenuUi.SetActive(true);
        PauseMenuUi.SetActive(false);
        //SceneManager.LoadScene("OptionMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitgame");
        Application.Quit();
    }
   
}
