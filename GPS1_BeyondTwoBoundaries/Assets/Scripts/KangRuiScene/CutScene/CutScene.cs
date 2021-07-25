using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
public class CutScene : MonoBehaviour
{
    public PlayableDirector cutScene;
    public GameObject[] dialogueManagement;
    bool press;
    public Animator player;
    public int dialogueRefer;
    void Start()
    {
        dialogueRefer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        forMultipleDialogue();
        dialogueContinue();
    }
    public void dialougePause()
    {
        cutScene.Pause();
        press = true;
        player.applyRootMotion = true;//make sure when cutscene pause the player wouldn't back to the original position
        //foreach (Animator animator in animator)
        //{
        //    animator.applyRootMotion = true;//make sure when cutscene pause the player wouldn't back to the original position
        //}
       
    }

    public void dialogueContinue()
    {
            //for cutScene Dialogue
            if (press == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                player.applyRootMotion = false;

                dialogueManagement[dialogueRefer].GetComponent<DialogueManagement>().DisplayNextSentence();
                
                    cutScene.Resume();
                    press = false;
                }
            }
        
    }
   public void forMultipleDialogue()
    {
        if (dialogueManagement.Length > dialogueRefer)
        {
            if (dialogueManagement[dialogueRefer].GetComponent<DialogueManagement>().DialogueEnd == true)
            {
                dialogueRefer += 1;
            }
        }
    }
}
