using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControll : MonoBehaviour
{
    public bool isPaused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            isPaused = true;
        }
        PauseScene();
    }
    
    void PauseScene()
    {
        if (isPaused == true)
        {
            Time.timeScale = 0f;
        }
        else
            Time.timeScale =1f;
    }
}
