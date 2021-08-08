using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTrailController : MonoBehaviour
{
    public GameObject GuideTrail;
    
    //public GameObject particleEffect;

    public Transform[] spawnpoints;
    public float spawnRate;
    public bool enableSpawns = true;
    
    float nextFireTime = 0f;


    void Update()
    {

        //var input = Input.GetMouseButton(0);
        if (enableSpawns && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + spawnRate;
            SpawnGuideTrail();
            
        }
    }

    void SpawnGuideTrail()
    {
        int randPos = Random.Range(0, spawnpoints.Length - 1);
        Instantiate(GuideTrail, spawnpoints[randPos].position, Quaternion.identity);
        

    }

    
}
