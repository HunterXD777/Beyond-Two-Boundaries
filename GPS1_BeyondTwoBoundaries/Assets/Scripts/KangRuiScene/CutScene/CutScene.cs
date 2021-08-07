using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutScene : MonoBehaviour
{
    public PlayableDirector cutScene;
    public GameObject[] dialogueManagement;
    bool press;
    public Animator playerAnim;
    public int dialogueRefer;

    public int nextSceneLoad;

    public GameObject previewCam;
    public GameObject Player;

   public bool forPrologue;

    public bool cutSceneEnd;
    void Start()
    {       
        dialogueRefer = 0;
        //previewCam = GameObject.Find("Camera Controller").gameObject.transform.Find("Preview Camera").gameObject;
        //Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        forMultipleDialogue();
        dialogueContinue();
        if (forPrologue)
        {
            skipCutscene();
        }
       
              
        //player.GetComponent<PlatformerMovement>().enableMove = false;
        
    }
    public void dialougePause()
    {
        cutScene.Pause();
        press = true;
       // playerAnim.applyRootMotion = true;
       
           
        //make sure when cutscene pause the player wouldn't back to the original position
        // foreach (Animator animator in animator)
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
                //playerAnim.applyRootMotion = false;                         
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
        //else
        //{
        //    player.GetComponent<PlatformerMovement>().enableMove = true;
        //}
    }

    public void skipCutscene()
    {
        //cutSceneObject = GameObject.Find("Level").gameObject.transform.Find("CutSceneObject").gameObject;
       
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(nextSceneLoad);
                //cutScene.Stop();
                //cutScene.time = skipTime;
                //skip = true;
                ////cutSceneObject.SetActive(false);
                //player.GetComponent<PlatformerMovement>().enableMove = true;
                //playerAnim.applyRootMotion = false;
            }
        
    }

    public void CutsceneEnd()
    {
        cutSceneEnd = true;
       // Player.GetComponent<PlatformerMovement>().enableMove = true;
    }

    public void CutsceneSoundEffect(string soundName, bool loop)
    {
        if (loop)
        {
            if (!dialogueManagement[dialogueRefer].GetComponent<DialogueManagement>().DialogueEnd)
            {
                FindObjectOfType<SoundManager>().Play(soundName);
            }
        }
        else
        {
            FindObjectOfType<SoundManager>().Play(soundName);
        }
    }
}
