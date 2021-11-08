using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// all this script does is make sure the prefab functionality works fine
public class PScore : MonoBehaviour
{
    // written by mohammed, audiomanager bit done by someone else
    AudioManager aM;
    Rigidbody2D rb;
    [SerializeField]
    // used for alternate item that maxes your pscore
    bool isThisAMaxItem;
    int pscoreWorth;
    // used for alternate item that maxes your pscore
    int pScoreMaxOut = 100;
    public float ySpeed;

    private void Start() {
        aM = FindObjectOfType<AudioManager>();
        // clamps pscore between 0-100
        pscoreWorth = Mathf.Clamp(pscoreWorth, 0, 100);
        rb = GetComponent<Rigidbody2D>();
        // to remove bloat 
        Destroy(gameObject,50);
    }
    // if collide, give player pscore and then go away
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player"){
            //print("YOU PICKED UP SOME P-SCORE");
            FindObjectOfType<AudioManager>().Play("Health pickup");
            pScoreRandomizeWorth();

            // special case for if this is a max item, maxes out your score to full
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
    // randomizes the value of our pscore
    private void pScoreRandomizeWorth() {
        pscoreWorth = Random.Range(5, 10);
    }
    // makes the p-score fall downwards
    private void Update() {
        rb.velocity = new Vector2(0,ySpeed*-1);
    }
}