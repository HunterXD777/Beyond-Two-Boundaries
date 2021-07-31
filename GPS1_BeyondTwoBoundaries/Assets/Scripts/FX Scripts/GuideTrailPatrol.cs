using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTrailPatrol : MonoBehaviour
{
    public float speed;
    public int targetPoint;
  
    public Transform[] moveSpots; 
    public Transform TrailStart;


    void Start()
    {
        targetPoint = 0;     
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
