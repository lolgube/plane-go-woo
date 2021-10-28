using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    //audiosource ur inspectorn
    public new AudioSource audio;
    //Nummer för varje låt
    public int songIndex;
    //array med olika låtar
    public AudioClip[] audioClips;

    private void Start()
    {
        //starta coroutine som startar låten
        StartCoroutine(PlaySong());
    }
    IEnumerator PlaySong()
    {
        //lägg in den låten vi har valt med index
        audio.clip = audioClips[songIndex];
        //spela ljudet(låten)
        audio.Play();
        //vänta så många sekunder som låten är lång
        yield return new WaitForSeconds(audio.clip.length);
        //starta om coroutine vilket loopar songen
        StartCoroutine(PlaySong());
    }
}
//Alfred