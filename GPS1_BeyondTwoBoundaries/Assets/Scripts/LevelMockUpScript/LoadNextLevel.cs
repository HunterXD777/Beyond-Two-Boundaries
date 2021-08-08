using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    public int requiredPieces;
    public int collectedPieces;
    public bool forPrologue;
    public bool specificLevel;
    GameObject deletePreb;
    private void Awake()
    {
        collectedPieces = 0;
    }
    public void Start()
    {
        //Kang Rui code
        if(forPrologue == true)
        {
            SceneManager.LoadScene(nextSceneLoad);
        }
        deletePreb = GameObject.FindWithTag("CameraControl");
    }
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //SceneManager.LoadScene("MileStoneLevelMockUP"); //load according to scene name

        if(collectedPieces == requiredPieces)
        {
            //Jane's Codes
            if (!specificLevel)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(nextSceneLoad);
            }//load next scene
            //SceneManager.LoadScene(nextSceneLoad);
            FindObjectOfType<SoundManager>().Play("Checkpoint"); //play checkpoint sound effect
            PlayerPrefs.DeleteKey(deletePreb.GetComponent<CameraControll>().setplayerPreb);

            //Kang Rui code
            FindObjectOfType<SoundManager>().Stop("HeartBeat");// stop the sound effect
        }

        
    }
    
}
