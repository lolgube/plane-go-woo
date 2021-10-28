using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    //audiosource ur inspectorn
    public new AudioSource audio;
    //Nummer f�r varje l�t
    public int songIndex;
    //array med olika l�tar
    public AudioClip[] audioClips;

    private void Start()
    {
        //starta coroutine som startar l�ten
        StartCoroutine(PlaySong());
    }
    IEnumerator PlaySong()
    {
        //l�gg in den l�ten vi har valt med index
        audio.clip = audioClips[songIndex];
        //spela ljudet(l�ten)
        audio.Play();
        //v�nta s� m�nga sekunder som l�ten �r l�ng
        yield return new WaitForSeconds(audio.clip.length);
        //starta om coroutine vilket loopar songen
        StartCoroutine(PlaySong());
    }
}
//Alfred