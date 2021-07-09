using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagement : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue<string> sentences;

    public GameObject dimensionS;
    public GameObject playerControl;

    public Text dialogue;
    public Text prompttext;

    public Animator animator;

    public GameObject dialogueTrigger;

    public bool stopTrigger = false;//set one time trigger for dialogue
    void Start()
    {
        sentences = new Queue<string>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTrigger == false)
        {
            if (dialogueTrigger.GetComponent<DialogueTrigger>().isTrigger == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DisplayNextSentence();
                }
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
       
        //sentences.Clear();
        prompttext.text = dialogue.prompt;
        
        playerControl.GetComponent<Animator>().SetFloat("Speed",0);//set to player_idle animation when trigger the dialogue box
        playerControl.GetComponent<PlatformerMovement>().enabled = false; //can't move during dialogue pop out

        playerControl.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0); //can't move during dialogue pop out

        animator.SetBool("OpenDialogue", true);//dialogue box pop out


        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();        
        //animate the sentence 
        StartCoroutine(Typesentence(sentence));

        //dialogue.text = sentence;
    }
    IEnumerator Typesentence(string sentence)
    {
        dialogue.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        Debug.Log("End");
        stopTrigger = true;

        //dimensionS.GetComponent<DimensionShift>().enabled = true;  //can't use dimension shift during dialogue pop out
        playerControl.GetComponent<PlatformerMovement>().enabled = true;   //can't move during dialogue pop out
      
        animator.SetBool("OpenDialogue", false);
    }
}
