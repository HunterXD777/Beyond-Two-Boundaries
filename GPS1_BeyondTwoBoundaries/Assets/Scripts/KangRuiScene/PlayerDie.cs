using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDie : MonoBehaviour
{
    // Start is called before the first frame update
    public Image DieScene;
    public GameObject TextAButton;
    public GameObject ResetOnSceen;

    

    public static bool playerDie;

    public bool player;
    public bool Decoy;
    public bool GhostDie;
    private void Awake()
    {
        DieScene.CrossFadeAlpha(0, 0.2f, false);
    }
    void Start()
    {
        playerDie = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDie)
        {
            StartCoroutine(TextAndButton());
            
        }
        Debug.Log(playerDie);

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player)
        {
            if (collision.gameObject.name == ("Player"))
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                ResetOnSceen.SetActive(false);
                DieScene.CrossFadeAlpha(1, 1, false);
                playerDie = true;

                FindObjectOfType<SoundManager>().Stop("HeartBeat");
                FindObjectOfType<PauseMenu>().inpausedMenu = false;

            }
        }
        if (Decoy)
        {
            if (collision.gameObject.tag == "Decoy")
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                ResetOnSceen.SetActive(false);
                DieScene.CrossFadeAlpha(1, 1, false);
                playerDie = true;

                FindObjectOfType<SoundManager>().Stop("HeartBeat");
                FindObjectOfType<PauseMenu>().inpausedMenu = false;

            }
        }
        if (GhostDie)
        {
            if (collision.gameObject.name == ("GhostPlayer"))
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                ResetOnSceen.SetActive(false);
                DieScene.CrossFadeAlpha(1, 1, false);
                playerDie = true;

                FindObjectOfType<SoundManager>().Stop("HeartBeat");
                FindObjectOfType<PauseMenu>().inpausedMenu = false;

            }
        }

    }

   
    IEnumerator TextAndButton()
    {
        yield return new WaitForSeconds(1.3f);
        TextAButton.SetActive(true);
        Time.timeScale = 0f;
    }
}
