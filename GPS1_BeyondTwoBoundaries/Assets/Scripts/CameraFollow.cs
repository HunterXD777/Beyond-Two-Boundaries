using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    public float offsetY = 0;
    public float offsetX = 0;
    public float smoothness;
    public float previewCamSmoothness;
    public float mainCamSize = 7;
    public float previewCamSize = 12;
    //public Vector3 minValues, maxValues;
    

    public bool overviewCam;

    private Camera mainCam;


    void Start()
    {
        overviewCam = false;
        mainCam = GetComponent<Camera>();
        mainCam.orthographicSize = mainCamSize;
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            overviewCam = true;
            mainCam.orthographicSize = previewCamSize;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            overviewCam = false;
            mainCam.orthographicSize = mainCamSize;
        }

        

        if (!overviewCam)
        {
            player = GameObject.FindWithTag("Player");
            Vector3 moveTo = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, -10f);
            transform.position = Vector3.Lerp(transform.position, moveTo, smoothness * Time.deltaTime);
        }
        else
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 moveTo = worldPosition;

            //Vector3 boundPosition = new Vector3(
                //Mathf.Clamp(moveTo.x, minValues.x, maxValues.x),
                //Mathf.Clamp(moveTo.y, minValues.y, maxValues.y),
                //Mathf.Clamp(moveTo.z, minValues.z, maxValues.z));

            
            transform.position = Vector3.Lerp(transform.position, moveTo, previewCamSmoothness * Time.deltaTime);
        }
        
    }
}
