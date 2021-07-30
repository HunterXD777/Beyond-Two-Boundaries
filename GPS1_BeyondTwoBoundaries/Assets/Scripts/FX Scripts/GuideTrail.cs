using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideTrail : MonoBehaviour
{
    
    //private GameObject playerObj;
    public Transform TrailTarget;

   
    public float speed;
    public float offset;
    public float lifetime;

   


    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //playerObj = GameObject.FindWithTag("Player");
        //TrailTarget = playerObj.GetComponent<Transform>();

        TrailToPoints();


    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        moveTrail(movement);
    }




    void TrailToPoints()
    {
        Vector3 direction = TrailTarget.position - transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = rotZ;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        direction.Normalize();
        movement = direction;
    }

    void moveTrail(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}
