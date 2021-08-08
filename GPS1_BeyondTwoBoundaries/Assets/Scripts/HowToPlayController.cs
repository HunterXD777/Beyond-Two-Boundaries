using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayController : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject backButton;
    public GameObject nextButton;
    private int currentPanel;

    // Start is called before the first frame update
    void Start()
    {


        panels[0].SetActive(true);
        panels[1].SetActive(false);
        panels[2].SetActive(false);
        panels[3].SetActive(false);
        panels[4].SetActive(false);
        panels[5].SetActive(false);

        nextButton.SetActive(true);
        backButton.SetActive(false);
        currentPanel = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        
        
    }

    public void NextPanel()
    {
        if(currentPanel == 0)
        {
            backButton.SetActive(true);
        }

        currentPanel++;
        panels[currentPanel - 1].SetActive(false);
        panels[currentPanel].SetActive(true);

        if(currentPanel == panels.Length-1)
        {
            nextButton.SetActive(false);
        }
    }

    public void PrevPanel()
    {
        if(currentPanel == panels.Length-1)
        {
            nextButton.SetActive(true);
        }

        currentPanel--;
        panels[currentPanel + 1].SetActive(false);
        panels[currentPanel].SetActive(true);

        if(currentPanel == 0)
        {
            backButton.SetActive(false);
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
