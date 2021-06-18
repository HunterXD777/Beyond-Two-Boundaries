using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("MainMenu"); //load to MainMenu scene
    }
}
