using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutSceneTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isTrigger;
    public PlayableDirector cutScene;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isTrigger == false)
        {
            cutScene.Play();
            isTrigger = true;
        }
    }
}
