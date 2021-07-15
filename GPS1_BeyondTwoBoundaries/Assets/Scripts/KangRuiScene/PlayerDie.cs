using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
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
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Decoy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            FindObjectOfType<SoundManager>().Stop("HeartBeat");
        }
    }
}
