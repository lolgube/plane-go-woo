using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// all this script does is make sure the prefab functionality works fine
public class PScore : MonoBehaviour
{
    AudioManager aM;
    Rigidbody2D rb;
    [SerializeField]
    bool isThisAMaxItem;
    int pscoreWorth;
    // p-scoreMaxOut puts your p-score at the highest, could be a useful drop.
    int pScoreMaxOut = 100;
    // sets our y speed
    public float ySpeed;

    private void Start() {
        aM = FindObjectOfType<AudioManager>();
        pscoreWorth = Mathf.Clamp(pscoreWorth, 0, 100);
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,50);
    }
    // if collide, give player pscore and then go away
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player"){
            print("YOU PICKED UP SOME P-SCORE");
            /////////////////////////////////////////////////
            // CHANGE THIS SOUND FOR P-SCORE AT SOME POINT //
            /////////////////////////////////////////////////
            FindObjectOfType<AudioManager>().Play("Health pickup");

            // randomizes small p-score thingie worth
            pScoreRandomizeWorth();

            // special case for if this is a max item, maxes out your score to fullz
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
        pscoreWorth = Random.Range(5, 10);
    }
    private void Update() {
        rb.velocity = new Vector2(0,ySpeed*-1);
    }
}