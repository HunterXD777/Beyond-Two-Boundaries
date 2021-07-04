using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public int nextSceneLoad;
    public int requiredPieces;
    public int collectedPieces;

    private void Awake()
    {
        collectedPieces = 0;
    }

    void Update()
    {
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
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
