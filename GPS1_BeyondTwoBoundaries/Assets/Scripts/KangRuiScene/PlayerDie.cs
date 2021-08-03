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
    private void Awake()
    {
        DieScene.CrossFadeAlpha(0, 0.2f, false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Decoy")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ResetOnSceen.SetActive(false);
            DieScene.CrossFadeAlpha(1, 1, false);
            StartCoroutine(TextAndButton());
            FindObjectOfType<SoundManager>().Stop("HeartBeat");
        }
    }
    
    IEnumerator TextAndButton()
    {
        yield return new WaitForSeconds(1.3f);
        TextAButton.SetActive(true);
    }
}
