using UnityEngine;
using System.Collections;
using System;

public class AudioFade
{
    public static IEnumerator FadeOut(Sound sound, float fadingTime, Func<float, float, float, float> Interpolate)
    {
        float startVolume = sound._source.volume;
        float frameCount = fadingTime / Time.deltaTime;
        float framesPassed = 0;

        while (framesPassed <= frameCount)
        {
            var t = framesPassed++ / frameCount;
            sound._source.volume = Interpolate(startVolume, 0, t);
            yield return null;
        }

        sound._source.volume = 0;
        sound._source.Pause();
    }
    public static IEnumerator FadeIn(Sound sound, float fadingTime, Func<float, float, float, float> Interpolate)
    {
        sound._source.Play();
        sound._source.volume = 0;

        float resultVolume = sound._volume;
        float frameCount = fadingTime / Time.deltaTime;
        float framesPassed = 0;

        while (framesPassed <= frameCount)
        {
            var t = framesPassed++ / frameCount;
            sound._source.volume = Interpolate(0, resultVolume, t);
            yield return null;
        }

        sound._source.volume = resultVolume;
    }
}