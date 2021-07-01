using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds; 
    public static SoundManager instance;

  


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            
        }
    }

    void Start()
    {
        Play("ThemeSong");
    }

    
    // 200 IQ audio finder: finds the name of the specific sound from 
    // sound library and plays it.
    // Use this code anywhere to call : FindObjectOfType<SoundManager>().Play("AudioName");
    // *********************VERY USEFULL CODE!!! ********************
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }

    
}

