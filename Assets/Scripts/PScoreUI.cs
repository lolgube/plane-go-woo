using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// mohammed
public class PScoreUI : MonoBehaviour
{
    // if i was smarter i'd just put this in the pscore script 
    private void Update() { 
        //print(score);
//        if(SpaceShip.PScore >= 100){
//            GetComponent<TMP_Text>().text = "Power: FULL"; 
//        }else{
        // display score
        GetComponent<TMP_Text>().text = "Power: " + SpaceShip.PScore.ToString();
//        }

// MAKE SURE TO REMOVE THE // WHEN ACTUALLY PUSHING, THIS IS JUST FOR DEV RN
    }
}