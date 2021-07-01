using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoulStateTutorial : MonoBehaviour
{
    public GameObject trigger;

    public GameObject SoulStateTutorials;
    public GameObject firstPage;
    public GameObject SecondPage;


    public bool Nexts = false;
    public bool endTutorial = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        check();
        if (!endTutorial)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!Nexts)
                    Next();
                else
                    ConGame();
            }
        }
    }

    public void check()
    {
        if (!endTutorial)
        {
            if(trigger.GetComponent<TriggerTutorial>().trigger == true)
            {
                SoulStateTutorials.SetActive(true);
                Time.timeScale = 0;
            }
        }

       
    }

    public void ConGame()
    {
        SoulStateTutorials.SetActive(false);
        Time.timeScale = 1;
        endTutorial = true;
    }

    public void Next()
    {
        firstPage.SetActive(false);
        SecondPage.SetActive(true);
        Nexts = true;
    }
}
