using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTrailPatrol : MonoBehaviour
{
    public float speed;
    public int targetPoint;
    //private float waitTime;
    //public float startWaitTime;

    public Transform[] moveSpots;
    //public Transform trailPoints;
    public Transform TrailStart;
    

    //private Transform nextTrailPoint;
    //private int randomSpot;

    void Start()
    {
        targetPoint = 0;
        //waitTime = startWaitTime;
        
        //randomSpot = Random.Range(0, moveSpots.Length);
    }

    
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[targetPoint].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[targetPoint].position) < 0.2f)
        {
            targetPoint++;
        }
        
        if (targetPoint == moveSpots.Length)
        {
            transform.position = TrailStart.position;
            targetPoint = 0;
        }
     

        
        
        

        
    }
}
