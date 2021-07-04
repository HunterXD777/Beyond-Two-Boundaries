using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    bool touch;
    public GameObject puzzlePiece;

    private GameObject CheckPoint;

    LoadNextLevel pieceCheck;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        pieceCheck.collectedPieces++;
        Destroy(this.gameObject);
        puzzlePiece.SetActive(true);

        //Jane's Codes
        FindObjectOfType<SoundManager>().Play("Collected"); //play collected sound effect
    }
}
