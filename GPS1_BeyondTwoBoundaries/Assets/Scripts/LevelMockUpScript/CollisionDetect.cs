using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public bool forPlace;
    public bool forDecoy;
    public bool ignoreDecoy;
    public GameObject ignoreCollision;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (forPlace)
        {
            Physics2D.IgnoreCollision(ignoreCollision.GetComponent<Collider2D>(), GetComponent<BoxCollider2D>());
        }
        if (forDecoy)
        {
            Physics2D.IgnoreCollision(ignoreCollision.GetComponent<Collider2D>(), GetComponent<CircleCollider2D>());
        }
        if (ignoreDecoy)
        {
            Physics2D.IgnoreCollision(ignoreCollision.GetComponent<CircleCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    
}
