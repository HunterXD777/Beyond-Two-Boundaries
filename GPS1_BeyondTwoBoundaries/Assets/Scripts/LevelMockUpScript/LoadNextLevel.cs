using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //SceneManager.LoadScene("MileStoneLevelMockUP"); //load according to scene name

        //Jane's Codes
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene
        FindObjectOfType<SoundManager>().Play("Checkpoint"); //play checkpoint sound effect
    }
}
