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
    public float PlayerPreviewCamSmoothness;


    public float previewDuration;
    public float camPauseDuration = 2;
    public bool moveCamera = false;
    public bool playerCam = false;
    public bool playCutsceneAfterPreview;//kang rui code // play cutscene or not after preview
    bool cutScenePlayed = false;
    bool cutScenePlay = false;//kang rui code // check cutscene had play or not
    //bool cutSceneEnd = false;

    public float offsetX;
    public float offsetY;



    public float cutSceneduration;
    public bool overviewCam;

    public PlayableDirector cutScene;

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
            //player = GameObject.FindWithTag("Player");
            //Vector3 moveTo = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, -10f);
            //transform.position = Vector3.Lerp(transform.position, moveTo, smoothness * Time.deltaTime);
            
            //Kang Rui Code

            if (Input.GetKey(KeyCode.Mouse1))
                {
                    overviewCam = true;
                    mainCam.orthographicSize = cameraPreviewSize;
                }

                if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    overviewCam = false;
                    mainCam.orthographicSize = cameraPlaySize;
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


                    transform.position = Vector3.Lerp(transform.position, moveTo, PlayerPreviewCamSmoothness * Time.deltaTime);
                }
            

            
        }
        //Kang Rui code
        //if (cutScenePlay)
        //{
        //    //if (!cutScenePlayed)
        //    //{
        //    //    player = GameObject.FindWithTag("Player");
        //    //    Vector3 moveTo = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, -10f);
        //    //    transform.position = Vector3.Lerp(transform.position, moveTo, smoothness * Time.deltaTime);

        //    //}

        //   if (!cutScenePlayed)
        //    {
        //        cutScene.Play();
        //        cutScenePlayed = true;
        //    }
           
        //}
        //if (cutScene.GetComponent<CutScene>().cutSceneEnd)
        //{
        //    playerCam = true;
        //    player.GetComponent<PlatformerMovement>().enableMove = true;
        //    cutScenePlay = false;

        //}
       


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
        if (playCutsceneAfterPreview) {
            cutScenePlay = true;
        }
        else
        {
            playerCam = true;
        }

    }
   
  
}
