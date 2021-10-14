using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PScore : MonoBehaviour
{
    AudioManager aM;
    private void Start()
    {
        aM = FindObjectOfType<AudioManager>();
    }
    // if collide, give player pscore and then go away
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player"){
            //////////////////////////////////////////////////
            // CHANGE THIS SOUND FOR P-SCORE AT SOME POINT ///
            //////////////////////////////////////////////////
            FindObjectOfType<AudioManager>().Play("Health pickup");
            SpaceShip.health++;
            Destroy(gameObject);
        }
    }
}