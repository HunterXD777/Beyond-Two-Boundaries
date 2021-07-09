using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    // Start is called before the first frame update
    public GameObject dialogueManagement;
    public bool isTrigger = false;
   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerDialogue(Dialogue dialogue)
    {
        dialogueManagement.GetComponent<DialogueManagement>().StartDialogue(dialogue);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (dialogueManagement.GetComponent<DialogueManagement>().stopTrigger == false)
        {
            if (collision.CompareTag("Player"))
            {
                TriggerDialogue(dialogue);
                isTrigger = true;
            }
        }
    }
}
