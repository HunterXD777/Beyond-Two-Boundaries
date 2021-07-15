using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class CutScene : MonoBehaviour
{
    public PlayableDirector cutScene;
    public GameObject dialogueManagement;
    bool press;
    public Animator player;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dialogueContinue();
    }
    public void dialougePause()
    {
        player.applyRootMotion = true;//make sure when cutscene pause the dialogue wouldn't back to the original position
        cutScene.Pause();
        press = true;
        //dialogueManagement.GetComponent<DialogueManagement>().DisplayNextSentence();
    }

    public void dialogueContinue()
    {
        //for cutScene Dialogue
        if (press == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueManagement.GetComponent<DialogueManagement>().DisplayNextSentence();
                cutScene.Resume();
                press = false;
                player.applyRootMotion = false;
                

            }
        }
    }
   
}
