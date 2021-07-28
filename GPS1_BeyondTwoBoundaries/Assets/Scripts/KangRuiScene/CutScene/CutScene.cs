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
    public Animator playerAnim;
    public int dialogueRefer;
    public float skipTime;
  GameObject cutSceneObject;
   bool skip;
    GameObject player;
    void Start()
    {
        skip = false;
        dialogueRefer = 0;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        forMultipleDialogue();
        dialogueContinue();
        skipDialogue();
    }
    public void dialougePause()
    {
        cutScene.Pause();
        press = true;
        playerAnim.applyRootMotion = true;
       
            if (Input.GetKeyDown(KeyCode.H))
            {
                
                skip = true;
            }
        //make sure when cutscene pause the player wouldn't back to the original position
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
                playerAnim.applyRootMotion = false;

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
        else
        {
            player.GetComponent<PlatformerMovement>().enableMove = true;
        }
    }

    public void skipDialogue()
    {
        cutSceneObject = GameObject.Find("CutSceneObject");
        if (!skip)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                if (press == true)
                {
                    cutScene.Resume();
                }
                cutScene.time = skipTime;
                skip = true;
                cutSceneObject.SetActive(false);
                player.GetComponent<PlatformerMovement>().enableMove = true;
                playerAnim.applyRootMotion = false;
            }
        }
    }
}
