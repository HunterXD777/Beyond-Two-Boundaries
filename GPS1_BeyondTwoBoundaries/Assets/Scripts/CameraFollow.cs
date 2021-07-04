using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    public float offsetY = 0;
    public float offsetX = 0;


    void Start()
    {
        
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player");
        Vector3 moveTo = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, -10f);
        transform.position = Vector3.Lerp(transform.position, moveTo, 10.0f * Time.deltaTime);
    }
}
