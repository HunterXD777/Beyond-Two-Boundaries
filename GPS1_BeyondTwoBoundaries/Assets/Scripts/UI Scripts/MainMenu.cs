using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool deleteSetVolumeMax;
    private void Awake()
    {//Kang rui code 
        if (!PlayerPrefs.HasKey("SetVolumeMax"))
        {
            PlayerPrefs.SetFloat("volume", 0.5f);
            PlayerPrefs.SetInt("SetVolumeMax", 1);
        }
    }

    private void Update()
    {
        if (deleteSetVolumeMax)
        {
            PlayerPrefs.DeleteKey("SetVolumeMax");
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene
        
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteKey("SetVolumeMax");
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
    public void LevelSelectMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }
}
