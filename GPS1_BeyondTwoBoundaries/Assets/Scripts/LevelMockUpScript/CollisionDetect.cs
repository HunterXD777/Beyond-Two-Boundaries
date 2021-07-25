using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public bool forPlace;
    public bool forDecoy;
    public GameObject ghostPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (forPlace)
        {
            Physics2D.IgnoreCollision(ghostPlayer.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (forDecoy)
        {
            Physics2D.IgnoreCollision(ghostPlayer.GetComponent<Collider2D>(), GetComponent<CircleCollider2D>());
        }
    }

    
}
