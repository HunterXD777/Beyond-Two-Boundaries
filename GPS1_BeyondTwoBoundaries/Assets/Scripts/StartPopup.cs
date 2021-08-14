using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPopup : MonoBehaviour
{
    public GameObject startPopupPanel;

    // Start is called before the first frame update
    void Start()
    {
        startPopupPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startPopupPanel.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startPopupPanel.SetActive(false);
        }
    }
}
