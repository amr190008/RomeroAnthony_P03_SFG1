using UnityEngine.Audio;
using System;
using UnityEngine;

public class JukeBox : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            // This is what we will be seeing in the inspector that will allow us to manipulate the sounds to our will
            s._source = gameObject.AddComponent<AudioSource>();

            s._source.clip = s._clip;

            s._source.volume = s._volume;

            s._source.pitch = s._pitch;
        }
    }

    public void Play (string _name)
    {
        // This will allow us to name a sound in the inspector and be able to get called from here
        // Meaning if we Name something like "Hit sound" in the inspector this will look for that string and play that sound 
        Sound s = Array.Find(sounds, sound => sound._name == _name);
        s._source.Play();
    }

    // Update is called once per frame
    void Start()
    {
        Play("BGM");
    }
}
