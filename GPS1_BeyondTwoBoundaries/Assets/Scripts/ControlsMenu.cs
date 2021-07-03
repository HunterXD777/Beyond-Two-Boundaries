using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
{
    public GameObject PauseMenuUi;
    public GameObject ControlsMenuUi;

    public GameObject PauseMenuSystem;

    
    public void BackForMain()
    {
        SceneManager.LoadScene("MainMenu"); //load to MainMenu scene
    }
    public void BackForPause()
    {
        PauseMenuUi.SetActive(true);
        ControlsMenuUi.SetActive(false);

        PauseMenuSystem.GetComponent<PauseMenu>().inpausedMenu = true;
    }
}
