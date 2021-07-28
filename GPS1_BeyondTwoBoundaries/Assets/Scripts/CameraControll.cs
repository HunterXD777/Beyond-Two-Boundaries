using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PreviewCam;
    public GameObject MainCam;
    public string setplayerPreb;
    

    public bool resetPreview;
   
    void Start()
    {
        if (!PlayerPrefs.HasKey(setplayerPreb))
        {
            PreviewCam.SetActive(true);
            MainCam.SetActive(false);
            PlayerPrefs.SetString(setplayerPreb, setplayerPreb);

        }
        else
        {
            MainCam.SetActive(true);
            PreviewCam.SetActive(false);
        }
    }

    private void Update()
    {
        if (resetPreview == true)
        {
            resetPreviewCam();
        }
    }
    public void resetPreviewCam()
    {
        PlayerPrefs.DeleteKey(setplayerPreb);
    }

}
