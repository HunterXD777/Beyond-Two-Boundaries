using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene
        
    }

    public void QuitGame()
    {
        Debug.Log("GAME QUITTED!"); //to show this works as unity won't actually show us that it quitted the game
        Application.Quit(); //quit game
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionMenu"); //load to OptionMenu       
    }

    public void Controls()
    {
        SceneManager.LoadScene("ControlsMenu"); //load to ControlsMenu
    }

}
