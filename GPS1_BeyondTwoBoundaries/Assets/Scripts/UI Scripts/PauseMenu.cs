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
    GameObject CameraController;
    GameObject Previewcam;
    GameObject MainCam;
    GameObject player;
    GameObject CutsceneSystem;
    public bool forTutorial;
    public bool forPrologue;

    void Update()
    {
        if (!forTutorial) {
            PauseGameForPreview();
        }
        else
        {
            PauseGameForNonPreview();
        }
        
       
    }

    public void PauseGameForPreview()
    {

        CameraController = GameObject.Find("Camera Controller");
        //CutsceneSystem = GameObject.Find("Level").gameObject.transform.Find("Cutscene System").gameObject;

        Previewcam = CameraController.transform.Find("Preview Camera").gameObject;
        MainCam = CameraController.transform.Find("Main Camera").gameObject;

        player = GameObject.FindWithTag("Player");
        if (inpausedMenu == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Previewcam.GetComponent<PreviewCamera>().playerCam)
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
                else
                {
                    //Kang Rui Code- Skip Preview Camera
                    Previewcam.SetActive(false);
                    MainCam.SetActive(true);
                    Previewcam.GetComponent<PreviewCamera>().playerCam = true;
                    //CutsceneSystem.SetActive(false);
                   
                    player.GetComponent<PlatformerMovement>().enableMove = true;
                }
            }
        }
    }
    public void PauseGameForNonPreview()
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
    
    public void ResetButton()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
        FindObjectOfType<SoundManager>().Stop("HeartBeat");
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
        GameObject resetPreviewCam;
        resetPreviewCam = GameObject.FindWithTag("CameraControl");
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
        resetPreviewCam.GetComponent<CameraControll>().resetPreviewCam();
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
        GameObject resetPreviewCam;
        resetPreviewCam = GameObject.FindWithTag("CameraControl");
        Debug.Log("Quitgame");
        Application.Quit();
        resetPreviewCam.GetComponent<CameraControll>().resetPreviewCam();
    }
   
}
