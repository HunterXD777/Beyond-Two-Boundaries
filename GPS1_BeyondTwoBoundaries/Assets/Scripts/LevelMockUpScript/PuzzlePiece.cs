using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    bool touch;
    public GameObject puzzlePiece;

    private GameObject CheckPoint;

    LoadNextLevel pieceCheck;

    public GameObject puzzleParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        CheckPoint = GameObject.FindWithTag("CheckPoint");
        pieceCheck = CheckPoint.GetComponent<LoadNextLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    pieceCheck.collectedPieces++;
       
    //    GetComponent<ParticleSystem>().Play(); //play collected particle effect
        
    //    Destroy(this.gameObject, 0.3f); //added 0.3 seconds delay time before puzzlepiece got destroyed in order to let particle effect play first
    //    puzzlePiece.SetActive(true);

    //    //Jane's Codes
    //    FindObjectOfType<SoundManager>().Play("Collected"); //play collected sound effect
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Decoy"))
        {
            pieceCheck.collectedPieces++;

            GetComponent<ParticleSystem>().Play(); //play collected particle effect

            Instantiate(puzzleParticleEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject); 
            puzzlePiece.SetActive(true);

            //Jane's Codes
            FindObjectOfType<SoundManager>().Play("Collected"); //play collected sound effect
        }
    }
}
