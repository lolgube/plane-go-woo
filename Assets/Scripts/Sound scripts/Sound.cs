using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;

    //audio clip storar ljudfiler i sig, Johan.
    public AudioClip clip;

    //range ger ett minimum och ett maximum v�rde som tex h�r en max volum och en minimum volym, Johan.
    [Range(0.1f, 1f)]
    public float volume;

    [Range(0.1f, 2f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}