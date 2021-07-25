using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreLevelScreen : MonoBehaviour
{
    public float duration = 6;
    public float smoothness;
    public Text actText;
    public Text levelText;
    private bool move = false;
    
    
    public Transform endPos;

    
    
    void Start()
    {
        
        
        actText.CrossFadeAlpha(0, 0.01f, false);
        levelText.CrossFadeAlpha(0, 0.01f, false);
        StartCoroutine(PreLevelTimer());
    }

    
    void Update()
    {

        if (move)
        {
            Vector3 moveTo = new Vector3(endPos.transform.position.x, endPos.transform.position.y, -10f);
            transform.position = Vector3.Lerp(transform.position, moveTo, smoothness * Time.deltaTime);
        }
        
    }


    IEnumerator PreLevelTimer()
    {
        yield return new WaitForSeconds(1);
        actText.CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(1);
        levelText.CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(2);
        move = true;


    }
}
