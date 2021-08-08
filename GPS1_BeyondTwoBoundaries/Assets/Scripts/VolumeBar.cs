using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeBar : MonoBehaviour
{
    public Slider slider;
    public float musicVolume = 1f;
    // Start is called before the first frame update
    
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("volume", slider.value);
    }
}
