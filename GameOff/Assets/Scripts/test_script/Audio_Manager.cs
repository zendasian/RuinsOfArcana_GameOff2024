using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
public class Audio_Manager : MonoBehaviour
{

    public Sound[] sounds;

    public static Audio_Manager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

            s.source.clip = s.Clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.MasterMixxer;

        }

    }
    private void Start()
    {
       Play("Intro_BG");

    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Play();

        if (s == null)
            return;
    }

    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Stop();

        if (s == null)
            return;
    }

}
