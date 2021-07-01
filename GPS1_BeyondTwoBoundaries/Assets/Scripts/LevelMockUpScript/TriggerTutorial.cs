using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public bool trigger;
    public bool playerEnter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerEnter == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                trigger = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerEnter = true;
    }

}
