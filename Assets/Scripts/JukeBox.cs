using UnityEngine.Audio;
using System;
using UnityEngine;

public class JukeBox : MonoBehaviour
{
    public Sound[] sounds;

    public static Sound sound;

    // public static AudioFade FadeIn;

    //public string BGM;

    //public float fadeTime;

    //public static FadingScript FadeIn;


    void Awake()
    {
        // This is in case we don't have a JukeBox in our scene already
        if (instance == null)
            instance = this;

        else
        {
            // This prevents from creating another Jukebox in the scene
            // Having two Jukebox could cause the scene to have overlapping music
            Destroy(gameObject);
            return;
        }


        // This will allow us to use the Jukebox on multiple scenes 
        // This will also not let the 

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            // This is what we will be seeing in the inspector that will allow us to manipulate the sounds to our will
            s._source = gameObject.AddComponent<AudioSource>();

            s._source.clip = s._clip;

            s._source.volume = s._volume;

            s._source.pitch = s._pitch;

            s._source.loop = s._loop;
        }

    }

    public static JukeBox instance;

    public void Play(string _name)
    {
        // This will allow us to name a sound in the inspector and be able to get called from here
        // Meaning if we Name something like "Hit sound" in the inspector this will look for that string and play that sound 
        Sound s = Array.Find(sounds, sound => sound._name == _name);

        if (s == null)
        {

            // This warning message will play if you accidentally misspelled something or didn't name it correctly
            Debug.LogWarning("There is no sound called" + _name + "that exists");

            Debug.Log("Check your spelling ");


            return;


        }


        s._source.Play();


    }


    void Start()
    {
        // Here we are going to demonstrate background music every time we start the scene
        Play("BGM");

        //if (sound != null)
        //{

        //  MAYBE THIS   StartCoroutine("FadeIn", (sound));

        //}

        // StartCoroutine(FadingScript.FadeIn(BGM, 5f));

    }
}


























//StartCoroutine(AudioFade.FadeIn(sound, 3f, Mathf.SmoothStep));