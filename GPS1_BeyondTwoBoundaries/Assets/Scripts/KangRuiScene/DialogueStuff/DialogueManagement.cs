using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagement : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue<string> sentences;
    private Queue<string> rnames;
    private Queue<string> lnames;
    private Queue<Color> textColor;

    public GameObject dimensionShift;

    public GameObject playerControl;

    public Text dialogue;
    public Text rightnametext;
    public Text leftnametext;
    public Text prompt;

    public Animator animator;

    public GameObject dialogueTrigger;

    public bool stopTrigger = false;//set one time trigger for dialogue

    public bool lockSoulSwap;
    public bool lockDimensionShift;
    public bool lockDimensionBreath;
    public bool DialogueEnd;

    void Start()
    {
        sentences = new Queue<string>();
        lnames = new Queue<string>();
        rnames = new Queue<string>();
        textColor = new Queue<Color>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (stopTrigger == false)
        //{
        //    if (dialogueTrigger.GetComponent<DialogueTrigger>().forCutScene == false)//determine for cutscene or not
        //    {
        //        if (dialogueTrigger.GetComponent<DialogueTrigger>().isTrigger == true)//determine had trigger dialogue or not
        //        {
        //            if (Input.GetKeyDown(KeyCode.E))
        //            {
        //                DisplayNextSentence();
        //            }
        //        }
        //    }
        //}
    }

    public void StartDialogue(Dialogue dialogue)
    {
        DialogueEnd = false;
        sentences.Clear();
       
        //for non cutscene used
        lockAbility();
        playerControl.GetComponent<Animator>().SetFloat("Speed", 0);//set to player_idle animation when trigger the dialogue box
        playerControl.GetComponent<PlatformerMovement>().enabled = false; //can't move during dialogue pop out
        if (dialogueTrigger.GetComponent<DialogueTrigger>().forCutScene == false)
        {                                                                 
            playerControl.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0); //can't move during dialogue pop out
        }
        //dialogue box in
        animator.SetBool("OpenDialogue", true);

        foreach(Color textColour in dialogue.textColor)
        {
            textColor.Enqueue(textColour);
        }
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string rname in dialogue.rightname)
        {
            rnames.Enqueue(rname);
        }
        foreach(string lname in dialogue.leftname)
        {
            lnames.Enqueue(lname);
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
        Color color = textColor.Dequeue();
        
        string sentence = sentences.Dequeue();
        string rnamess = rnames.Dequeue();
        string lnamess = lnames.Dequeue();
        //animate the sentence 
        prompt.color = color;
        rightnametext.color = color;
        leftnametext.color = color;
        rightnametext.text = rnamess;
        leftnametext.text = lnamess;
        StartCoroutine(Typesentence(sentence,color));

        //dialogue.text = sentence;
    }
    IEnumerator Typesentence(string sentence,Color color)
    {
        //animate the sentence 
        dialogue.color = color;
        dialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogue.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        Debug.Log("End");
        stopTrigger = true;
        DialogueEnd = true;
        unlockAbility();
        playerControl.GetComponent<PlatformerMovement>().enabled = true;   //can move after dialogue pop out
        
        //dialogue box out
        animator.SetBool("OpenDialogue", false);
    }

    void lockAbility()
    {
        if (lockDimensionShift == true)
        {
            dimensionShift.GetComponent<DimensionShift>().enabled = false;  //can't use dimension shift during dialogue pop out  
        }
        if (lockDimensionBreath == true)
        {
            dimensionShift.GetComponent<DimensionBreach>().enabled = false;  //can't use dimension breath during dialogue pop out  
        }
        if (lockSoulSwap == true)
        {
            dimensionShift.GetComponent<SoulsSwap>().enabled = false;  //can't use soul swap during dialogue pop out  
        }
    }

    void unlockAbility()
    {
        if (lockDimensionShift == true)
        {
            dimensionShift.GetComponent<DimensionShift>().enabled = true;  //can use dimension shift after dialogue pop out  
        }
        if (lockDimensionBreath == true)
        {
            dimensionShift.GetComponent<DimensionBreach>().enabled = true;  //can use dimension breath after dialogue pop out  
        }
        if (lockSoulSwap == true)
        {
            dimensionShift.GetComponent<SoulsSwap>().enabled = true;  //can use soul swap after dialogue pop out  
        }
    }
}
