using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public new AudioSource audio;
    public int songIndex;
    // Start is called before the first frame update

    public AudioClip[] audioClips;

    private void Start()
    {
        StartCoroutine(PlaySong());
    }
    IEnumerator PlaySong()
    {
        
        audio.clip = audioClips[songIndex];
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        StartCoroutine(PlaySong());
    }
}
