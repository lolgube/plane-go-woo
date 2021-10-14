using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PScore : MonoBehaviour
{
    
    AudioManager aM;

    // will this p-score max your score out or give a little bit? 
    bool isThisAMaxItem;
    int pscoreWorth;
    int pScoreMaxOut;

    private void Start() {
        aM = FindObjectOfType<AudioManager>();
    }
    // if collide, give player pscore and then go away
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player"){
            //////////////////////////////////////////////////
            // CHANGE THIS SOUND FOR P-SCORE AT SOME POINT ///
            //////////////////////////////////////////////////
            FindObjectOfType<AudioManager>().Play("Health pickup");

            // randomizes our worth
            pScoreRandomizeWorth();
            // adds our randomized worth
            SpaceShip.PScore += pscoreWorth;
            Destroy(gameObject);
        }
    }

    private void pScoreRandomizeWorth() {
        pscoreWorth = Random.Range(1, 5);
    }
}