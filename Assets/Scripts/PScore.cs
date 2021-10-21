using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// all this script does is make sure the prefab functionality works fine

public class PScore : MonoBehaviour
{
    AudioManager aM;
    [SerializeField]
    bool isThisAMaxItem;
    int pscoreWorth;
    // p-scoreMaxOut puts your p-score at the highest, could be a useful drop.
    int pScoreMaxOut = 100;

    private void Start() {
        aM = FindObjectOfType<AudioManager>();
        pscoreWorth = Mathf.Clamp(pscoreWorth, 0, 100);
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

            // special case for if this is a max item, trying to make it put your score to "full"
            if(isThisAMaxItem == true){
                SpaceShip.PScore += pScoreMaxOut;
                // clamps our value to 100
                SpaceShip.PScore = Mathf.Clamp(SpaceShip.PScore, 0, 100);
                Destroy(gameObject);
            }else{
                // adds our randomized worth
                SpaceShip.PScore += pscoreWorth;
                // clamps our value to 100
                SpaceShip.PScore = Mathf.Clamp(SpaceShip.PScore, 0, 100);
                Destroy(gameObject);
            }
            
        }
    }

    private void pScoreRandomizeWorth() {
        pscoreWorth = Random.Range(1, 5);
    }
}