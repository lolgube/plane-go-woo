using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// mohammed
public class PScoreUI : MonoBehaviour
{
    // if i was smarter i'd just put this in the pscore script 
    // but it's easier to find it this way so who cares

    private void Update() { 
        //print(score);
        // fancy thing that replaces 100 with the text "FULL"
        if(SpaceShip.PScore >= 100){
            GetComponent<TMP_Text>().text = "Power: FULL"; 
        }else{
        // displays our normal score
        GetComponent<TMP_Text>().text = "Power: " + SpaceShip.PScore.ToString();
        }
    }
}