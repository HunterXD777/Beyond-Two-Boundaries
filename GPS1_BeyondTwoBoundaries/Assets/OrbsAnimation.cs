using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject activeSouls;
    Animator activeSoulsAim;
    Animator selfAnimation;
    void Start()
    {
        activeSoulsAim = activeSouls.GetComponent<Animator>();
        selfAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeSouls.activeSelf)
        {
            activeSoulsAim.SetBool("Start", true);
            selfAnimation.SetBool("Start", true);
        }
        else
        {
            activeSoulsAim.SetBool("Start", false);
            selfAnimation.SetBool("Start", false);
        }
    }
}
