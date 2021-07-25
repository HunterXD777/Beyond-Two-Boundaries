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
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene
            SceneManager.LoadScene(nextSceneLoad);
            FindObjectOfType<SoundManager>().Play("Checkpoint"); //play checkpoint sound effect
        }

        
    }
    
}
