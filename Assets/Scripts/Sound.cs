using UnityEngine.Audio;
using System;
using UnityEngine;

[Serializable] 
public class Sound
{
    // This will allow us to name our clips in the Jukebox
    public string _name;

    // Here is where we will drag the clip into the JukeBox
    public AudioClip _clip;

    // This is where we can control the volume of the clip  
    [Range(0f, 1f)] public float _volume;
    
    // Here we can control the pitch of the sound/music
    [Range(.1f, 3f)] public float _pitch;

    // THis will allow us to loop the sound/music if we wish to
    public bool _loop;

    // This adds an audio source for the clip to be played, we hid it so that it doesn't show up in the inspector 
    [HideInInspector] public AudioSource _source;
}
