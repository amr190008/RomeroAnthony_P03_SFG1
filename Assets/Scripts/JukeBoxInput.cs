using UnityEngine.Audio;
using System;
using UnityEngine;

public class JukeBoxInput : MonoBehaviour
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

    public static JukeBoxInput instance;

    public void Play (string _name)
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
        Play("BGM");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))

        {
            Play("Q Press");
        }

        if (Input.GetKeyDown(KeyCode.W))

        {
            Play("W Press");
        }

        if (Input.GetKeyDown(KeyCode.E))

        {
            Play("E Press");
        }
    }
}


























//StartCoroutine(AudioFade.FadeIn(sound, 3f, Mathf.SmoothStep));