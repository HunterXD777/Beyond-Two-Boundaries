using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PreviewCamera : MonoBehaviour
{

    public Transform startPos;
    public Transform endPos;

    
    private float smoothness;

    public float previewCamSmoothness;
    public float playerCamSmoothness;
    public float cameraPreviewSize;
    public float cameraPlaySize;

    public float previewDuration;
    public float camPauseDuration = 2;
    public bool moveCamera = false;
    public bool playerCam = false;
    //public bool playCutsceneAfterPreview;//kang rui code // play cutscene or not after preview
    //bool cutScenePlay = false;//kang rui code // check cutscene had play or not


    public float offsetX;
    public float offsetY;

   
    
    private GameObject player;
    private Camera mainCam;

    
    void Start()
    {
        mainCam = GetComponent<Camera>();
        mainCam.orthographicSize = cameraPreviewSize;
        smoothness = previewCamSmoothness;
        transform.position = startPos.transform.position;
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlatformerMovement>().enableMove = false;
        StartCoroutine(PauseCountDown());
        StartCoroutine(PreviewDuration());
        
       
    }


    void Update()
    {
        
        if (moveCamera)
        {
            Vector3 moveTo = new Vector3(endPos.transform.position.x, endPos.transform.position.y, -10f);
            transform.position = Vector3.Lerp(transform.position, moveTo, smoothness * Time.deltaTime);
        }

        if (playerCam)
        {
            player = GameObject.FindWithTag("Player");
            Vector3 moveTo = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, -10f);
            transform.position = Vector3.Lerp(transform.position, moveTo, smoothness * Time.deltaTime);

        }
        


    }


    IEnumerator PauseCountDown()
    {
        yield return new WaitForSeconds(camPauseDuration);
        moveCamera = true;
    }

    IEnumerator PreviewDuration()
    {
        yield return new WaitForSeconds(previewDuration);
        mainCam.orthographicSize = cameraPlaySize;
        smoothness = playerCamSmoothness;
        moveCamera = false;
        playerCam = true;       
        player.GetComponent<PlatformerMovement>().enableMove = true;
        
    }
    
    

}
