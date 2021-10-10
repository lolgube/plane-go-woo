using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; // det h�r �r en lista som ska ineh�lla ljudfiler fr�n det andra scriptet som heter sound, Johan.

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name) // Denna funktion �r gjord s� att n�r man kallar det s� skriver man namnet p� ljudfilen i arrayn som finns i detta skript ns� spelas det ljudet, Johan.
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

}
